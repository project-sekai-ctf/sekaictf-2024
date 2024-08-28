using AsmResolver;
using AsmResolver.PE.File;

namespace license_server;

public class ChallengeVm(SystemConfiguration configuration)
{
	private static readonly byte[] ProgramHash = new byte[32];
	
	private static ulong _drxAdd;
	private static ulong _drxSub;
	private static ulong _drxMul;
	private static ulong _drxXor;
	
	private static ulong _textSectionStart;
	private static uint _textSectionSize;
	
    private enum Opcode
    {
        // Register operations.
        Load,
        
        // Basic arithmetic operations.
        Add,
        Sub,
        Mul,
        Xor,
        Rol,
        Ror,
        
        // HWID operations.
        LoadCpuid,
        LoadNumberOfProcessors,
        LoadFirmwareType,
        UpdateBootGuid,
        LoadNtMinorVersion,
        LoadNtMajorVersion,
        LoadNtBuildNumber,
        
        // Program hash operations.
        UpdateProgramHash,
        
        // Cryptographic operations.
        StartHash,
        UpdateHash,
        EndHash,
        
        Return
    }

    private enum OpcodeEncoding
    {
        Reg1,
        Reg1Reg2,
        Reg1Reg2Op3,
        Reg1Op3
    }

    private class OpcodeObfuscation(ushort op, Func<ulong, SystemConfiguration, ulong> obfuscation)
    {
        public ushort ObfOpcode { get; } = op;
        public Func<ulong, SystemConfiguration, ulong> Obfuscation { get; } = obfuscation;
    }

    private class OpcodeContext(OpcodeEncoding encoding, List<OpcodeObfuscation> obfuscations)
    {
        public OpcodeEncoding Encoding { get; } = encoding;
        public List<OpcodeObfuscation> Obfuscations { get; } = obfuscations;
    }

    private static readonly Dictionary<Opcode, OpcodeContext> Contexts = new()
    {
	    {
		    Opcode.Load, new OpcodeContext(OpcodeEncoding.Reg1Op3, [
			    new(18253, Obfuscations.Load_0_Obf),
			    new(40098, Obfuscations.Load_1_Obf),
			    new(60873, Obfuscations.Load_2_Obf),
			    new(33297, Obfuscations.Load_3_Obf),
			    new(636, Obfuscations.Load_4_Obf),
			    new(61867, Obfuscations.Load_5_Obf),
		    ])
	    },

	    {
		    Opcode.Add, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(2715, Obfuscations.Add_0_Obf),
			    new(45127, Obfuscations.Add_1_Obf),
			    new(52056, Obfuscations.Add_2_Obf),
			    new(37347, Obfuscations.Add_3_Obf),
			    new(7753, Obfuscations.Add_4_Obf),
		    ])
	    },

	    {
		    Opcode.Sub, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(26527, Obfuscations.Sub_0_Obf),
			    new(65082, Obfuscations.Sub_1_Obf),
			    new(32666, Obfuscations.Sub_2_Obf),
			    new(18721, Obfuscations.Sub_3_Obf),
			    new(46815, Obfuscations.Sub_4_Obf),
			    new(10219, Obfuscations.Sub_5_Obf),
			    new(55531, Obfuscations.Sub_6_Obf),
			    new(31733, Obfuscations.Sub_7_Obf),
		    ])
	    },

	    {
		    Opcode.Mul, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(24440, Obfuscations.Mul_0_Obf),
			    new(35689, Obfuscations.Mul_1_Obf),
			    new(46629, Obfuscations.Mul_2_Obf),
			    new(38358, Obfuscations.Mul_3_Obf),
			    new(45309, Obfuscations.Mul_4_Obf),
			    new(47489, Obfuscations.Mul_5_Obf),
			    new(30740, Obfuscations.Mul_6_Obf),
			    new(57601, Obfuscations.Mul_7_Obf),
		    ])
	    },

	    {
		    Opcode.Xor, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(26798, Obfuscations.Xor_0_Obf),
			    new(36687, Obfuscations.Xor_1_Obf),
			    new(13493, Obfuscations.Xor_2_Obf),
			    new(33049, Obfuscations.Xor_3_Obf),
			    new(44995, Obfuscations.Xor_4_Obf),
			    new(47706, Obfuscations.Xor_5_Obf),
			    new(48697, Obfuscations.Xor_6_Obf),
		    ])
	    },

	    {
		    Opcode.Rol, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(45613, Obfuscations.Rol_0_Obf),
			    new(48896, Obfuscations.Rol_1_Obf),
			    new(43231, Obfuscations.Rol_2_Obf),
			    new(26401, Obfuscations.Rol_3_Obf),
			    new(20219, Obfuscations.Rol_4_Obf),
			    new(36560, Obfuscations.Rol_5_Obf),
			    new(50351, Obfuscations.Rol_6_Obf),
		    ])
	    },

	    {
		    Opcode.Ror, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(29344, Obfuscations.Ror_0_Obf),
			    new(2856, Obfuscations.Ror_1_Obf),
			    new(8584, Obfuscations.Ror_2_Obf),
			    new(48030, Obfuscations.Ror_3_Obf),
			    new(19290, Obfuscations.Ror_4_Obf),
			    new(9436, Obfuscations.Ror_5_Obf),
			    new(17896, Obfuscations.Ror_6_Obf),
		    ])
	    },

	    {
		    Opcode.LoadCpuid, new OpcodeContext(OpcodeEncoding.Reg1Reg2Op3, [
			    new(25064, Obfuscations.LoadCpuid_0_Obf),
			    new(14702, Obfuscations.LoadCpuid_1_Obf),
			    new(19989, Obfuscations.LoadCpuid_2_Obf),
			    new(56385, Obfuscations.LoadCpuid_3_Obf),
			    new(42187, Obfuscations.LoadCpuid_4_Obf),
			    new(27532, Obfuscations.LoadCpuid_5_Obf),
			    new(11993, Obfuscations.LoadCpuid_6_Obf),
		    ])
	    },

	    {
		    Opcode.LoadNumberOfProcessors, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(27840, Obfuscations.LoadNumberOfProcessors_0_Obf),
			    new(13879, Obfuscations.LoadNumberOfProcessors_1_Obf),
			    new(39625, Obfuscations.LoadNumberOfProcessors_2_Obf),
			    new(29742, Obfuscations.LoadNumberOfProcessors_3_Obf),
			    new(8361, Obfuscations.LoadNumberOfProcessors_4_Obf),
		    ])
	    },

	    {
		    Opcode.LoadFirmwareType, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(34076, Obfuscations.LoadFirmwareType_0_Obf),
			    new(34527, Obfuscations.LoadFirmwareType_1_Obf),
			    new(30782, Obfuscations.LoadFirmwareType_2_Obf),
			    new(54876, Obfuscations.LoadFirmwareType_3_Obf),
			    new(31432, Obfuscations.LoadFirmwareType_4_Obf),
			    new(47151, Obfuscations.LoadFirmwareType_5_Obf),
		    ])
	    },

	    {
		    Opcode.UpdateBootGuid, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(30020, Obfuscations.UpdateBootGuid_0_Obf),
			    new(49308, Obfuscations.UpdateBootGuid_1_Obf),
			    new(2177, Obfuscations.UpdateBootGuid_2_Obf),
			    new(23321, Obfuscations.UpdateBootGuid_3_Obf),
			    new(13330, Obfuscations.UpdateBootGuid_4_Obf),
			    new(48565, Obfuscations.UpdateBootGuid_5_Obf),
		    ])
	    },

	    {
		    Opcode.LoadNtMinorVersion, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(58509, Obfuscations.LoadNtMinorVersion_0_Obf),
			    new(14002, Obfuscations.LoadNtMinorVersion_1_Obf),
			    new(13046, Obfuscations.LoadNtMinorVersion_2_Obf),
			    new(61079, Obfuscations.LoadNtMinorVersion_3_Obf),
			    new(22770, Obfuscations.LoadNtMinorVersion_4_Obf),
			    new(10361, Obfuscations.LoadNtMinorVersion_5_Obf),
		    ])
	    },

	    {
		    Opcode.LoadNtMajorVersion, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(37806, Obfuscations.LoadNtMajorVersion_0_Obf),
			    new(16325, Obfuscations.LoadNtMajorVersion_1_Obf),
			    new(24048, Obfuscations.LoadNtMajorVersion_2_Obf),
			    new(20741, Obfuscations.LoadNtMajorVersion_3_Obf),
			    new(19784, Obfuscations.LoadNtMajorVersion_4_Obf),
		    ])
	    },

	    {
		    Opcode.LoadNtBuildNumber, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(3932, Obfuscations.LoadNtBuildNumber_0_Obf),
			    new(32619, Obfuscations.LoadNtBuildNumber_1_Obf),
			    new(46178, Obfuscations.LoadNtBuildNumber_2_Obf),
			    new(41959, Obfuscations.LoadNtBuildNumber_3_Obf),
			    new(2691, Obfuscations.LoadNtBuildNumber_4_Obf),
			    new(42853, Obfuscations.LoadNtBuildNumber_5_Obf),
		    ])
	    },

	    {
		    Opcode.UpdateProgramHash, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(53185, Obfuscations.UpdateProgramHash_0_Obf),
		    ])
	    },

	    {
		    Opcode.StartHash, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(12207, Obfuscations.StartHash_0_Obf),
			    new(42844, Obfuscations.StartHash_1_Obf),
			    new(52997, Obfuscations.StartHash_2_Obf),
			    new(19026, Obfuscations.StartHash_3_Obf),
			    new(35725, Obfuscations.StartHash_4_Obf),
		    ])
	    },

	    {
		    Opcode.UpdateHash, new OpcodeContext(OpcodeEncoding.Reg1Reg2, [
			    new(46072, Obfuscations.UpdateHash_0_Obf),
			    new(59589, Obfuscations.UpdateHash_1_Obf),
			    new(61085, Obfuscations.UpdateHash_2_Obf),
			    new(10281, Obfuscations.UpdateHash_3_Obf),
			    new(10890, Obfuscations.UpdateHash_4_Obf),
		    ])
	    },

	    {
		    Opcode.EndHash, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(1544, Obfuscations.EndHash_0_Obf),
			    new(63777, Obfuscations.EndHash_1_Obf),
			    new(57607, Obfuscations.EndHash_2_Obf),
			    new(21332, Obfuscations.EndHash_3_Obf),
			    new(16415, Obfuscations.EndHash_4_Obf),
			    new(40716, Obfuscations.EndHash_5_Obf),
			    new(42158, Obfuscations.EndHash_6_Obf),
			    new(10650, Obfuscations.EndHash_7_Obf),
		    ])
	    },

	    {
		    Opcode.Return, new OpcodeContext(OpcodeEncoding.Reg1, [
			    new(32540, Obfuscations.Return_0_Obf),
			    new(22143, Obfuscations.Return_1_Obf),
			    new(47880, Obfuscations.Return_2_Obf),
			    new(55210, Obfuscations.Return_3_Obf),
			    new(44673, Obfuscations.Return_4_Obf),
			    new(47324, Obfuscations.Return_5_Obf),
			    new(24923, Obfuscations.Return_6_Obf),
		    ])
	    }
    };

    private class Insn(Opcode op, byte r1 = 0, byte o2 = 0, ulong op3 = 0)
    {
        private OpcodeContext Context { get; } = Contexts[op];
        private byte Register1 { get; } = r1;
        private byte Operand2 { get; } = o2;
        private ulong Operand3 { get; } = op3;

        public void Serialize(BinaryWriter writer, SystemConfiguration configuration, Random random)
        {
	        var index = random.Next(Context.Obfuscations.Count);
	        var obf = Context.Obfuscations[index];
	        
            writer.Write(obf.ObfOpcode);
            
            switch (Context.Encoding)
            {
                case OpcodeEncoding.Reg1:
                    writer.Write(obf.Obfuscation(Register1, configuration));
                    break;
                case OpcodeEncoding.Reg1Reg2:
                    writer.Write(obf.Obfuscation(Register1, configuration));
                    writer.Write(obf.Obfuscation(Operand2, configuration));
                    break;
                case OpcodeEncoding.Reg1Reg2Op3:
                    writer.Write(obf.Obfuscation(Register1, configuration));
                    writer.Write(obf.Obfuscation(Operand2, configuration));
                    writer.Write(obf.Obfuscation(Operand3, configuration));
                    break;
                case OpcodeEncoding.Reg1Op3:
                    writer.Write(obf.Obfuscation(Register1, configuration));
                    writer.Write(obf.Obfuscation(Operand3, configuration));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    private SystemConfiguration Configuration { get; } = configuration;
    private Random Random { get; } = new();

    public static void SetupImage(PEFile peFile)
    {
	    var textSection = peFile.Sections.First(sec => sec.Name == ".text");
	    var sectionContents = textSection.ToArray();
	    Array.Resize(ref sectionContents, (int) textSection.GetVirtualSize());

	    _textSectionStart = textSection.Rva;
	    _textSectionSize = textSection.GetVirtualSize();
            
	    var sekaiSection = peFile.Sections.First(sec => sec.Name == ".sekai");
	    var sekaiContents = sekaiSection.ToArray();

	    var sekaiStream = new MemoryStream(sekaiContents);
	    var sekaiReader = new BinaryReader(sekaiStream);
            
	    _drxAdd = (uint) (sekaiReader.ReadUInt64() - peFile.OptionalHeader.ImageBase);
	    _drxSub = (uint) (sekaiReader.ReadUInt64() - peFile.OptionalHeader.ImageBase);
	    _drxMul = (uint) (sekaiReader.ReadUInt64() - peFile.OptionalHeader.ImageBase);
	    _drxXor = (uint) (sekaiReader.ReadUInt64() - peFile.OptionalHeader.ImageBase);

	    HydrogenLibrary.Hash(ProgramHash, ProgramHash.Length, sectionContents, sectionContents.Length, "Miku:3:3");
    }

    private static List<Opcode> GetPossibleHwidOperations()
    {
        return
        [
            Opcode.LoadCpuid, Opcode.LoadNumberOfProcessors, Opcode.LoadFirmwareType, Opcode.UpdateBootGuid,
            Opcode.LoadNtMinorVersion, Opcode.LoadNtMajorVersion, Opcode.LoadNtBuildNumber, Opcode.UpdateProgramHash
        ];
    }

    private (ulong cpuIdIndex, byte cpuIdRegister, ulong correctValue) GenerateCpuid()
    {
        var cpuIdIndex = (ulong) Random.Next(0, 3);
        var cpuIdRegister = (byte) Random.Next(0, 4);

        return cpuIdIndex switch
        {
            0 => (0x80000002ul, cpuIdRegister, Configuration.CpuBrandString1[cpuIdRegister]),
            1 => (cpuIdIndex + 0x80000002ul, cpuIdRegister, Configuration.CpuBrandString2[cpuIdRegister]),
            2 => (cpuIdIndex + 0x80000002ul, cpuIdRegister, Configuration.CpuBrandString3[cpuIdRegister]),
            _ => throw new InvalidOperationException($"Invalid CPUID index. {cpuIdIndex}")
        };
    }

    private ulong Rebase(ulong rva) => Configuration.ImageBaseAddress + rva;

    private static ulong MurmurHash3_64(ulong[] key, ulong seed = 0)
    {
	    const ulong m = 0xc6a4a7935bd1e995;
	    const int r = 47;
	    var hash = seed;

	    foreach (var k in key)
	    {
		    var kLocal = k;
		    kLocal *= m;
		    kLocal ^= kLocal >> r;
		    kLocal *= m;

		    hash ^= kLocal;
		    hash *= m;
	    }

	    hash ^= hash >> r;
	    hash *= m;
	    hash ^= hash >> r;

	    return hash;
    }
    
    public (byte[] bytecode, byte[] correctResult) GenerateChallenge()
    {
        var instructions = new List<Insn> {
            // Initial load.
            new(Opcode.StartHash)
        };
        
        var hashStream = new MemoryStream();
        var hashWriter = new BinaryWriter(hashStream);
        
        // DRX registers are hashed here.
        hashWriter.Write(Rebase(_drxAdd)); // Dr0
        hashWriter.Write(Rebase(_drxSub)); // Dr1
        hashWriter.Write(Rebase(_drxMul)); // Dr2
        hashWriter.Write(Rebase(_drxXor)); // Dr3

        var remainingHwidOps = GetPossibleHwidOperations();
        List<Opcode> randomOps = [
            Opcode.Add, Opcode.Sub, Opcode.Mul, Opcode.Xor, Opcode.Rol, Opcode.Ror
        ];
        
        var amountHwidOperations = Random.Next(750, 1000);
        for (var i = 0; i < amountHwidOperations; i++)
        {
            if (remainingHwidOps.Count == 0)
                remainingHwidOps = GetPossibleHwidOperations();

            var index = Random.Next(remainingHwidOps.Count);
            var op = remainingHwidOps[index];
            remainingHwidOps.RemoveAt(index);
            
            // Special case for Update* opcodes, we can't perform any other operations on them.
            if (op is Opcode.UpdateBootGuid or Opcode.UpdateProgramHash)
            {
	            if (op == Opcode.UpdateBootGuid)
	            {
		            hashWriter.Write(Configuration.BootGuid);
	            }
	            else
	            {
		            // Text start/size.
		            hashWriter.Write(Rebase(_textSectionStart));
		            hashWriter.Write(_textSectionSize);
		            
		            // Program hash.
		            hashWriter.Write(ProgramHash);
		            
		            // Text start/size again.
		            hashWriter.Write(Rebase(_textSectionStart));
		            hashWriter.Write(_textSectionSize);
		            
		            // Anti-Debug Check.
		            hashWriter.Write((ulong) 1);
		            hashWriter.Write(Rebase(_drxAdd)); // Dr0
		            hashWriter.Write(Rebase(_drxSub)); // Dr1
		            hashWriter.Write(Rebase(_drxMul)); // Dr2
		            hashWriter.Write(Rebase(_drxXor)); // Dr3
		            
		            ulong[] toDrxHash = [ Rebase(_drxAdd), Rebase(_drxSub), Rebase(_drxMul), Rebase(_drxXor) ];
		            hashWriter.Write(MurmurHash3_64(toDrxHash, Configuration.ImageBaseAddress)); // DrxHash
	            }
	            
	            instructions.Add(new Insn(op));
                continue;
            }

            ulong currentValue;
            switch (op)
            {
                case Opcode.LoadCpuid:
                {
                    var (cpuIdIndex, cpuIdRegister, correctValue) = GenerateCpuid();
                    instructions.Add(new Insn(Opcode.LoadCpuid, 1, cpuIdRegister, cpuIdIndex));
                    currentValue = correctValue;
                    break;
                }
                case Opcode.LoadNumberOfProcessors:
                    instructions.Add(new Insn(Opcode.LoadNumberOfProcessors, 1));
                    // Sign-extend to 64-bits.
                    currentValue = Configuration.NumberOfProcessors;
                    if (Configuration.NumberOfProcessors > 0x7f)
                        currentValue |= 0xffffffffffffff00;
                    break;
                case Opcode.LoadFirmwareType:
                    instructions.Add(new Insn(Opcode.LoadFirmwareType, 1));
                    currentValue = Configuration.FirmwareType;
                    break;
                case Opcode.LoadNtMinorVersion:
                    instructions.Add(new Insn(Opcode.LoadNtMinorVersion, 1));
                    currentValue = Configuration.NtMinorVersion;
                    break;
                case Opcode.LoadNtMajorVersion:
                    instructions.Add(new Insn(Opcode.LoadNtMajorVersion, 1));
                    currentValue = Configuration.NtMajorVersion;
                    break;
                case Opcode.LoadNtBuildNumber:
                    instructions.Add(new Insn(Opcode.LoadNtBuildNumber, 1));
                    currentValue = Configuration.NtBuildNumber;
                    break;
                default: throw new InvalidOperationException($"Invalid load opcode. {op}");
            }
            
            // Perform a series of random operations on the result.
            var amountOperations = Random.Next(5, 25);
            for (var j = 0; j < amountOperations; j++)
            {
                var randomOp = randomOps[Random.Next(randomOps.Count)];
                var operand = (ulong) Random.NextInt64();
                if (randomOp is Opcode.Rol or Opcode.Ror)
                    operand %= 64;
                
                instructions.Add(new Insn(Opcode.Load, 2, 0, operand));
                instructions.Add(new Insn(randomOp, 1, 2));

                switch (randomOp)
                {
                    case Opcode.Add:
                        currentValue += operand;
                        break;
                    case Opcode.Sub:
                        currentValue -= operand;
                        break;
                    case Opcode.Mul:
                        currentValue *= operand;
                        break;
                    case Opcode.Xor:
                        currentValue ^= operand;
                        break;
                    case Opcode.Rol:
                        currentValue = Mathematics.RotateLeft(currentValue, (int) operand);
                        break;
                    case Opcode.Ror:
                        currentValue = Mathematics.RotateRight(currentValue, (int) operand);
                        break;
                    default: throw new InvalidOperationException($"Invalid random opcode. {randomOp}");
                }
            }
            
            // Add to the final hash.
            instructions.Add(new Insn(Opcode.UpdateHash, 0, 1));
            hashWriter.Write(currentValue);
        }
        
        // Finalize hash and return.
        instructions.Add(new Insn(Opcode.EndHash));
        instructions.Add(new Insn(Opcode.Return));
        
        // Get final hash.
        hashWriter.Write((byte) 1); // Anti-debug in OpCode.EndHash.
        hashWriter.Flush();

        var toHash = hashStream.ToArray();
        var hash = new byte[32];
        if (!HydrogenLibrary.Hash(hash, hash.Length, toHash, toHash.Length, "SekaiCTF"))
            throw new InvalidOperationException("Failed to hash challenge result.");
        
        // Get final bytecode.
        var bytecodeStream = new MemoryStream();
        var bytecodeWriter = new BinaryWriter(bytecodeStream);
        
        foreach (var insn in instructions)
            insn.Serialize(bytecodeWriter, Configuration, Random);
        
        bytecodeWriter.Flush();
        
        return (bytecodeStream.ToArray(), hash);
    }
}