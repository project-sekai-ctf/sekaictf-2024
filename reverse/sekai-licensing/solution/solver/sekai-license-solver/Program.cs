using AsmResolver;
using AsmResolver.PE.File;
using Iced.Intel;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

namespace sekai_license_solver
{
    public class Program
    {
#if DEBUG
        private const LogEventLevel MinimumLevel = LogEventLevel.Debug;
#else
        private const LogEventLevel MinimumLevel = LogEventLevel.Information;
#endif

        // Syscall hash: 0x6BC417DC
        private const ulong NtQuerySystemInformationSyscallId = 0xa1010 /* Address of syscall ID. Find via bytes above. */ - 0x1000 /* RVA of .text section */;

        public class PatchData(ulong offset, byte[] patch)
        {
            public ulong Offset { get; set; } = offset;
            public byte[] Patch { get; set; } = patch;
        }

        public class FoundOffsets
        {
            public readonly List<ulong> CpuidOffsets = [];
            public readonly List<ulong> SyscallOffsets = [];
            public readonly List<PatchData> Patches = [];
        }

        public static FoundOffsets Offsets = new();

        private static void SetupLogger()
        {
            var logConfig = new LoggerConfiguration();
            logConfig.WriteTo.Console(MinimumLevel);
            logConfig.MinimumLevel.Is(MinimumLevel);

            Log.Logger = logConfig.CreateLogger();
        }
        
        private static void TestCpuid(Decoder decoder, ISegment segment)
        {
            var ip = decoder.IP;
            var cpuId = decoder.Decode();
            if (cpuId.Code != Code.Cpuid)
                return;

            Offsets.CpuidOffsets.Add(ip + segment.Rva);
            Log.Information("Found CPUID at offset 0x{0:x}", ip + segment.Rva);
        }
        
        private static void TestNtQsi(Decoder decoder, ISegment segment)
        {
            var movSysId = decoder.Decode();
            if (movSysId.Mnemonic != Mnemonic.Mov || movSysId.IPRelativeMemoryAddress != NtQuerySystemInformationSyscallId)
                return;

            while (true)
            {
                var ip = decoder.IP;
                var sysCall = decoder.Decode();
                if (sysCall.Mnemonic != Mnemonic.Syscall)
                    continue;

                Offsets.SyscallOffsets.Add(ip + segment.Rva);
                Log.Information("Found NtQuerySystemInformation at offset 0x{0:x}", ip + segment.Rva);
                break;
            }
        }

        private static void AssemblePatch8(ulong ip, Instruction instr, byte replacement)
        {
            var register = instr.Op0Register switch
            {
                Register.AL => AssemblerRegisters.al,
                Register.BL => AssemblerRegisters.bl,
                Register.CL => AssemblerRegisters.cl,
                Register.DL => AssemblerRegisters.dl,
                _ => throw new Exception("Unsupported register")
            };

            var c = new Assembler(64);
            switch (instr.Mnemonic)
            {
                case Mnemonic.Mov:
                case Mnemonic.Movzx:
                    c.mov(register, replacement);
                    break;
                case Mnemonic.Add:
                    c.add(register, replacement);
                    break;
                case Mnemonic.Sub:
                    c.sub(register, replacement);
                    break;
                case Mnemonic.Xor:
                    c.xor(register, replacement);
                    break;
                default: throw new Exception("Unsupported instruction");
            }

            var stream = new MemoryStream();
            c.Assemble(new StreamCodeWriter(stream), ip);
            if (instr.Length < stream.Length)
                throw new Exception("Patch is too long");

            while (stream.Length != instr.Length)
                stream.WriteByte(0x90); // nop (0x90)

            Offsets.Patches.Add(new PatchData(ip, stream.ToArray()));
        }

        // We want to replace reads from KUSER_SHARED_DATA to our correct configuration we found.
        private static void AssemblePatch32(ulong ip, Instruction instr, uint replacement)
        {
            if (instr.Op0Register is Register.AL or Register.BL or Register.CL or Register.DL)
            {
                AssemblePatch8(ip, instr, (byte) replacement);
                return;
            }
            
            var register = instr.Op0Register switch
            {
                Register.EAX => AssemblerRegisters.eax,
                Register.EBX => AssemblerRegisters.ebx,
                Register.ECX => AssemblerRegisters.ecx,
                Register.EDX => AssemblerRegisters.edx,
                Register.EDI => AssemblerRegisters.edi,
                Register.ESI => AssemblerRegisters.esi,
                Register.R8D => AssemblerRegisters.r8d,
                Register.R9D => AssemblerRegisters.r9d,
                Register.R10D => AssemblerRegisters.r10d,
                Register.R11D => AssemblerRegisters.r11d,
                Register.R12D => AssemblerRegisters.r12d,
                Register.R13D => AssemblerRegisters.r13d,
                Register.R14D => AssemblerRegisters.r14d,
                Register.R15D => AssemblerRegisters.r15d,
                _ => throw new Exception("Unsupported register")
            };

            var c = new Assembler(64);
            switch (instr.Mnemonic)
            {
                case Mnemonic.Mov:
                case Mnemonic.Movzx:
                    c.mov(register, replacement);
                    break;
                case Mnemonic.Add:
                    c.add(register, replacement);
                    break;
                case Mnemonic.Sub:
                    c.sub(register, replacement);
                    break;
                case Mnemonic.And:
                    c.and(register, replacement);
                    break;
                case Mnemonic.Or:
                    c.or(register, replacement);
                    break;
                case Mnemonic.Xor:
                    c.xor(register, replacement);
                    break;
                case Mnemonic.Imul:
                    c.imul(register, register, replacement);
                    break;
                default: throw new Exception("Unsupported instruction");
            }

            var stream = new MemoryStream();
            c.Assemble(new StreamCodeWriter(stream), ip);
            if (instr.Length < stream.Length)
                throw new Exception("Patch is too long");

            while (stream.Length != instr.Length)
                stream.WriteByte(0x90); // nop (0x90)

            Offsets.Patches.Add(new PatchData(ip, stream.ToArray()));
        }
        
        private static void TestKUed(Decoder decoder, ISegment segment)
        {
            var ip = decoder.IP;
            var instr = decoder.Decode();
            switch (instr.IPRelativeMemoryAddress)
            {
                case 0x7ffe0000 + 0x260:
                    Log.Information("Found NtBuildNumber at offset 0x{0:x} ({mov})", ip + segment.Rva, instr);
                    AssemblePatch32(ip + segment.Rva, instr, 0x1337);
                    break;
                case 0x7ffe0000 + 0x26C:
                    Log.Information("Found NtMajorVersion at offset 0x{0:x} ({mov})", ip + segment.Rva, instr);
                    AssemblePatch32(ip + segment.Rva, instr, 9);
                    break;
                case 0x7ffe0000 + 0x270:
                    Log.Information("Found NtMinorVersion at offset 0x{0:x} ({mov})", ip + segment.Rva, instr);
                    AssemblePatch32(ip + segment.Rva, instr, 42);
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            SetupLogger();
            
            if (args.Length != 1)
            {
                Log.Error("Usage: sekai-license-solver <file>");
                return;
            }
            
            var peFile = PEFile.FromFile(args[0]);
            
            var textSection = peFile.Sections.First(s => s.Name == ".text");
            var textData = textSection.ToArray();
            
            var reader = new ByteArrayCodeReader(textData);
            var decoder = Decoder.Create(64, reader);
            
            Log.Information("Finding CPUID offsets...");

            decoder.IP = 0;
            reader.Position = 0;

            while (decoder.IP < (ulong) textData.Length - 0x20)
                TestCpuid(decoder, textSection);
            
            Log.Information("Finding NtQuerySystemInformation offsets...");

            decoder.IP = 0;
            reader.Position = 0;

            while (decoder.IP < (ulong)textData.Length - 0x20)
                TestNtQsi(decoder, textSection);
            
            Log.Information("Finding KiUED offsets...");

            decoder.IP = 0;
            reader.Position = 0;

            while (decoder.IP < (ulong)textData.Length - 0x20)
                TestKUed(decoder, textSection);

            File.WriteAllText("offsets.json", JsonConvert.SerializeObject(Offsets));
        }
    }
}