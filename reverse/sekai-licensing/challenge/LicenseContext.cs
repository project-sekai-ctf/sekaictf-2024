//#define USE_MOCK_INFO
#define REQUIRE_CORRECT_CONFIGURATION

using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Serilog;
using vtortola.WebSockets;

namespace license_server;

public class LicenseContext(WebSocket webSocket, CancellationToken token)
{
    private static KeyPair _serverKeyPair = new()
    {
        publicKey = Convert.FromBase64String("LBQWLIlNxru/1d43mpvO/u/in6N61rXUo+m0kiv5NAM="),
        secretKey = Convert.FromBase64String("clzE+GRN1G0B4kqKkHYluFtoeJUiPh2GStp4KPpnVMA=")
    };

    private static readonly byte[] CorrectLicenseKey =
        Convert.FromHexString("21D4BA14519138F6E0FE409C6EE31EC59496E4DE18F17FD4949306FA7FE5CE79");

    private static readonly SystemConfiguration CorrectConfiguration =
        JsonConvert.DeserializeObject<SystemConfiguration>(
            """{"NumberOfProcessors":192,"FirmwareType":1,"BootGuid":"8108Na/PsUbrbatP4uAMwg==","NtMinorVersion":42,"NtMajorVersion":9,"NtBuildNumber":4919,"CpuBrandString1":[779510849,1802063136,1698963573,1701013878],"CpuBrandString2":[1817518195,543257204,758266161,1701998403],"CpuBrandString3":[1869762592,1936942435,538997359,538976288],"ImageBaseAddress":140700337635328}""") ??
        throw new InvalidOperationException();
    
    private bool ValidatedConfiguration { get; set; }
    private bool ReadyForClose { get; set; }
    private WebSocket WebSocket { get; } = webSocket;
    private CancellationToken Token { get; } = token;
    
    private SessionKeyPair? _keyPair;
    private byte[]? _correctChallengeResult;
    private DateTime? _correctChallengeDueTime;

    private enum PacketType
    {
        LicenseKeyRequest,
        LicenseKeyResponse,
        ChallengeRequest,
        ChallengeResponse,
        Message
    }

    private void ProcessKeyExchange(byte[] packet)
    {
        // Process key exchange packet.
        if (packet.Length != HydrogenLibrary.PacketBytes)
            throw new InvalidOperationException("Invalid key exchange packet length.");
        if (!HydrogenLibrary.N2(out var keyPair, packet, ref _serverKeyPair))
            throw new InvalidOperationException("Invalid key exchange packet.");
        
        _keyPair = keyPair;
    }
    
    private byte[] EncryptMessage(byte[] message)
    {
        // Check if key pair is initialized.
        if (_keyPair == null)
            throw new InvalidOperationException("Key pair not initialized.");
        
        // Encrypt message.
        var encrypted = new byte[message.Length + HydrogenLibrary.HeaderBytes];
        if (!HydrogenLibrary.Encrypt(encrypted, message, message.Length, "SekaiCTF", _keyPair.Value.sendKey))
            throw new InvalidOperationException("Failed to encrypt message.");

        return encrypted;
    }

    private BinaryReader DecryptMessage(byte[] encrypted)
    {
        // Check if key pair is initialized.
        if (_keyPair == null)
            throw new InvalidOperationException("Key pair not initialized.");
        
        // Check if message meets minimum length.
        if (encrypted.Length <= HydrogenLibrary.HeaderBytes)
            throw new InvalidOperationException("Invalid message length.");

        // Decrypt message.
        var decrypted = new byte[encrypted.Length - HydrogenLibrary.HeaderBytes];
        if (!HydrogenLibrary.Decrypt(decrypted, encrypted, encrypted.Length, "SekaiCTF", _keyPair.Value.receiveKey))
            throw new InvalidOperationException("Failed to decrypt message.");

        // Return decrypted message as binary reader.
        var memStream = new MemoryStream(decrypted);
        return new BinaryReader(memStream, Encoding.UTF8);
    }

    private async Task ProcessInitialConnection()
    {
        // Request license key
        var stream = new MemoryStream();
        var writer = new BinaryWriter(stream, Encoding.UTF8);
        
        writer.Write((byte) PacketType.LicenseKeyRequest);
        
        var encrypted = EncryptMessage(stream.ToArray());
        await WebSocket.WriteBytesAsync(encrypted, Token);
    }
    
    private static ulong DecodeSerialKeyPart(ulong part, ulong modInvKey)
    {
        part = Mathematics.ReverseBits(part) - 0xcec942ea3098af2cul;
        part *= modInvKey;
        part ^= Mathematics.RotateLeft(part, 16) ^ Mathematics.RotateRight(part, 42);
        return part;
    }
    
    private static ulong DecodeMiscPart(ulong part, ulong modInvKey)
    {
        part ^= Mathematics.RotateRight(part, 8) ^ Mathematics.RotateLeft(part, 14);
        part ^= 0x9dac012771735241;
        part *= modInvKey;
        part = Mathematics.ReverseBits(part);
        return part;
    }
    
    private static ulong DecodeCpuidPart(ulong part, ulong modInvKey)
    {
        part += 0x87e3189b7d1f5464;
        part ^= Mathematics.RotateRight(part, 12) ^ Mathematics.RotateLeft(part, 36);
        part = Mathematics.ReverseBits(part);
        part *= modInvKey;
        return part;
    }

    private async Task ProcessLicenseKeyResponse(BinaryReader reader)
    {
        var modInvKey = ~reader.ReadUInt64();

        var licenseKey = new byte[32];
        for (var i = 0; i < 4; i++)
        {
            var part = DecodeSerialKeyPart(reader.ReadUInt64(), modInvKey);
            Array.Copy(BitConverter.GetBytes(part), 0, licenseKey, i * 8, 8);
        }

        if (!CryptographicOperations.FixedTimeEquals(licenseKey, CorrectLicenseKey))
        {
            var messageStream = new MemoryStream();
            var messageWriter = new BinaryWriter(messageStream, Encoding.UTF8);
            
            messageWriter.Write((byte) PacketType.Message);
            messageWriter.Write("Invalid license key.");
            messageWriter.Flush();
            
            var encrypted = EncryptMessage(messageStream.ToArray());
            await WebSocket.WriteBytesAsync(encrypted, Token);
        
            ReadyForClose = true;

            return;
        }

        var systemConfig = new SystemConfiguration
        {
            NumberOfProcessors = (byte) DecodeMiscPart(reader.ReadUInt64(), modInvKey),
            FirmwareType = (uint) DecodeMiscPart(reader.ReadUInt64(), modInvKey)
        };
        
        if (reader.Read(systemConfig.BootGuid, 0, 16) != 16)
            throw new InvalidOperationException("Failed to read boot GUID.");

        systemConfig.NtMinorVersion = (uint) DecodeMiscPart(reader.ReadUInt64(), modInvKey);
        systemConfig.NtMajorVersion = (uint) DecodeMiscPart(reader.ReadUInt64(), modInvKey);
        systemConfig.NtBuildNumber = (uint) DecodeMiscPart(reader.ReadUInt64(), modInvKey);

        systemConfig.ImageBaseAddress = DecodeMiscPart(reader.ReadUInt64(), modInvKey);
        
        for (var i = 0; i < 4; i++)
            systemConfig.CpuBrandString1[i] = (uint) DecodeCpuidPart(reader.ReadUInt64(), modInvKey);
        for (var i = 0; i < 4; i++)
            systemConfig.CpuBrandString2[i] = (uint) DecodeCpuidPart(reader.ReadUInt64(), modInvKey);
        for (var i = 0; i < 4; i++)
            systemConfig.CpuBrandString3[i] = (uint) DecodeCpuidPart(reader.ReadUInt64(), modInvKey);

#if REQUIRE_CORRECT_CONFIGURATION
        var incorrectConfiguration = systemConfig.NumberOfProcessors != CorrectConfiguration.NumberOfProcessors ||
                                     systemConfig.FirmwareType != CorrectConfiguration.FirmwareType ||
                                     !CryptographicOperations.FixedTimeEquals(systemConfig.BootGuid,
                                         CorrectConfiguration.BootGuid) ||
                                     systemConfig.NtMinorVersion != CorrectConfiguration.NtMinorVersion ||
                                     systemConfig.NtMajorVersion != CorrectConfiguration.NtMajorVersion ||
                                     systemConfig.NtBuildNumber != CorrectConfiguration.NtBuildNumber ||
                                     !systemConfig.CpuBrandString1.SequenceEqual(CorrectConfiguration
                                         .CpuBrandString1) ||
                                     !systemConfig.CpuBrandString2.SequenceEqual(CorrectConfiguration
                                         .CpuBrandString2) ||
                                     !systemConfig.CpuBrandString3.SequenceEqual(CorrectConfiguration.CpuBrandString3);
        
        ValidatedConfiguration = !incorrectConfiguration;
        Log.Information(ValidatedConfiguration ? "Configuration validated." : "Invalid configuration.");
#else
        ValidatedConfiguration = true;
#endif
        
#if USE_MOCK_INFO
        var testConfiguration = JsonConvert.DeserializeObject<SystemConfiguration>(
            """{"NumberOfProcessors":32,"FirmwareType":2,"BootGuid":"bwVZB04Z7xGrkdNdYIPjcw==","NtMinorVersion":0,"NtMajorVersion":10,"NtBuildNumber":22631,"CpuBrandString1":[541347137,1702525266,540614766,808794421],"CpuBrandString2":[909189208,1919894317,1917853797,1936024431],"CpuBrandString3":[544370547,538976288,538976288,2105376],"ImageBaseAddress":140697879379968}""");
        testConfiguration.ImageBaseAddress = systemConfig.ImageBaseAddress;
        
        systemConfig = testConfiguration;
#endif
        
        // Send challenge.
        var challengeVm = new ChallengeVm(systemConfig);
        var (bytecode, correctResult) = challengeVm.GenerateChallenge();
        _correctChallengeResult = correctResult;
        
        var challengeStream = new MemoryStream();
        var challengeWriter = new BinaryWriter(challengeStream);
        
        challengeWriter.Write((byte) PacketType.ChallengeRequest);
        challengeWriter.Write(bytecode);
        challengeWriter.Flush();
        
        _correctChallengeDueTime = DateTime.UtcNow.AddMinutes(2);
        
        var encryptedChallenge = EncryptMessage(challengeStream.ToArray());
        await WebSocket.WriteBytesAsync(encryptedChallenge, Token);
    }

    private async Task ProcessChallengeResponse(BinaryReader reader)
    {
        var challengeResult = new byte[32];
        if (reader.Read(challengeResult, 0, 32) != 32)
            throw new InvalidOperationException("Failed to read challenge result.");

        var message = "Failed to authenticate hardware tied to license key.";
        if (DateTime.UtcNow > _correctChallengeDueTime)
        {
            message = "Challenge expired.";
        }
        else if (ValidatedConfiguration)
        {
            message = CryptographicOperations.FixedTimeEquals(challengeResult, _correctChallengeResult)
                ? "Successfully authenticated user of license key. Flag: SEKAI{m1ku_l0ves_cpu1d_and_ku3r_shar3d_data}"
                : "Hardware challenge/response failed.";
        }
        
        var messageStream = new MemoryStream();
        var messageWriter = new BinaryWriter(messageStream, Encoding.UTF8);
            
        messageWriter.Write((byte) PacketType.Message);
        messageWriter.Write(message);
        messageWriter.Flush();
            
        var encrypted = EncryptMessage(messageStream.ToArray());
        await WebSocket.WriteBytesAsync(encrypted, Token);
        
        ReadyForClose = true;
    }

    private async Task ProcessDecryptedMessage(BinaryReader reader)
    {
        var packetId = (PacketType) reader.ReadByte();
        switch (packetId)
        {
            case PacketType.LicenseKeyResponse:
            {
                await ProcessLicenseKeyResponse(reader);
                break;
            }
            case PacketType.ChallengeResponse:
            {
                await ProcessChallengeResponse(reader);
                break;
            }
            case PacketType.LicenseKeyRequest:
            case PacketType.ChallengeRequest:
            case PacketType.Message:
                throw new InvalidOperationException("Packet not handled by server.");
            default:
                throw new InvalidOperationException("Invalid packet type.");
        }
    }

    public async Task<bool> ProcessMessageAsync(WebSocketMessageReadStream rawMessageStream)
    {
        if (ReadyForClose)
            return true;
        
        var rawMessage = await rawMessageStream.ReadAllBytesAsync(Token);
        if (_keyPair == null)
        {
            ProcessKeyExchange(rawMessage);
            await ProcessInitialConnection();
            return false;
        }
        
        var message = DecryptMessage(rawMessage);
        await ProcessDecryptedMessage(message);
        return false;
    }
}