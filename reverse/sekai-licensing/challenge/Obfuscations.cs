using System.Buffers.Binary;

namespace license_server
{
    public static class Obfuscations
    {
		public static ulong Load_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xe39f2960e6126ec5ul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v3 = BinaryPrimitives.ReverseEndianness(Input_v2);
			ulong Input_v4 = Input_v3 | (0x583f65e73f3fef2aul);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0xc72af306874bf673ul;
			ulong v1_v2 = v1_v1 | (0x69df3113574a2ff1ul);
			ulong v1_v3 = v1_v2 << (int) (((0x88a7dbb2a18414a1ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 << (int) (((0xa2824cbaa208dde0ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0x5d6785ed7eeac0f9ul;
			ulong v2_l_v2 = v2_l_v1 - (0xa1fdc42de81e34ebul);
			ulong v2_l_v3 = v2_l_v2 * (0x5316e7911fe8291bul);
			ulong v2_l_v4 = ~v2_l_v3;

			ulong v2_r_v1 = 0x748028ac534612a4ul;
			ulong v2_r_v2 = v2_r_v1 ^ (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v2_r_v3 = ~v2_r_v2;
			ulong v2_r_v4 = v2_r_v3 << (int) (((0xc90c5054b0d3fe4eul) % 64ul) | 1ul);
			ulong v2_r_v5 = ~v2_r_v4;

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x133307d6f5682b40ul;
			ulong v3_v2 = v3_v1 & (0xb1fda31f0fc42ae3ul);
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 + (0x76a5a3489cd9c9e9ul);
			ulong v3_v5 = Mathematics.RotateRight(v3_v4, (int) (((0x5b58149089d83e00ul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xb07bc37020e48416ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 ^ (Configuration.CpuBrandString1[2] & 0xffffffff);
			ulong v4_v4 = v4_v3 & (0x53b22381bc51ce7bul);
			ulong v4_v5 = Mathematics.RotateRight(v4_v4, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0xa711d3a164681366ul;
			ulong v5_l_v2 = v5_l_v1 * (0x24701fc3213e743ul);
			ulong v5_l_v3 = v5_l_v2 & (0x3c9d288a0332ac66ul);
			ulong v5_l_v4 = v5_l_v3 - (0xa17360bf5affac56ul);

			ulong v5_r_v1 = 0x18023a8a9c45caa3ul;
			ulong v5_r_v2 = v5_r_v1 * (0x37556c95c9daa321ul);
			ulong v5_r_v3 = v5_r_v2 & (0x454cde4c98f23111ul);
			ulong v5_r_v4 = v5_r_v3 >> (int) (((0x4f6acbff786e610cul) % 64ul) | 1ul);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Load_1_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = ~Input;
			ulong v1_l_v1 = 0x9cbe8f6a2ad5d88eul;
			ulong v1_l_v2 = v1_l_v1 << (int) (((0x900a5154a8228e95ul) % 64ul) | 1ul);
			ulong v1_l_v3 = ~v1_l_v2;
			ulong v1_l_v4 = BinaryPrimitives.ReverseEndianness(v1_l_v3);
			ulong v1_l_v5 = ~v1_l_v4;

			ulong v1_r_v1 = 0x8f54fd794a4d6e54ul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = v1_r_v2 + (0xf1546bb2fcf5eaf2ul);
			ulong v1_r_v4 = v1_r_v3 << (int) (((0x200a622978cb7c27ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xba243809b06174d1ul;
			ulong v2_l_v2 = ~v2_l_v1;
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0x6bcf908d04c179e4ul) % 64ul) | 1ul));
			ulong v2_l_v4 = Mathematics.RotateRight(v2_l_v3, (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_l_v5 = v2_l_v4 | (Configuration.CpuBrandString2[1] & 0xffffffff);

			ulong v2_r_v1 = 0x683cf2d348a502d9ul;
			ulong v2_r_v2 = v2_r_v1 & (0xd28771e367092e89ul);
			ulong v2_r_v3 = Mathematics.RotateRight(v2_r_v2, (int) (((0xc53bdfedd7e1f4e4ul) % 64ul) | 1ul));
			ulong v2_r_v4 = v2_r_v3 * (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v2_r_v5 = v2_r_v4 - (0x55980f75a15dee13ul);

			ulong v3 = Mathematics.InverseRotationRightLeft(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x2efd387480e725b0ul;
			ulong v3_v2 = v3_v1 * (0x7184dcbbe242c9bful);
			ulong v3_v3 = ~v3_v2;
			ulong v3_v4 = v3_v3 | (0xd3f688c93af84492ul);
			ulong v3_v5 = v3_v4 + (0x6c7c028cf516745cul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xc945b4d07195b4b3ul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 ^ (0xf486d70dff0ce61ful);
			ulong v4_v4 = v4_v3 + (0x5404fe99293365b5ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(((v4_v4 | 1ul)));

			return v5;
		}

		public static ulong Load_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xa8e8b962b9ee0251ul;
			ulong Input_v2 = Input_v1 ^ (0xb582bbb397bb2643ul);
			ulong Input_v3 = Input_v2 + (0x68af45030febcebbul);
			ulong Input_v4 = Input_v3 | (Configuration.NtMajorVersion);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v4 | 1ul)));
			ulong v1_v1 = 0xfa06565996e41bbul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0xf2b2960b41f35818ul) % 64ul) | 1ul));
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 >> (int) (((0xe3297127f132b613ul) % 64ul) | 1ul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_v1 = 0xa574034c31f324f5ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((0x92c6e769f061e464ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 >> (int) (((0x6998d7b1ebb13211ul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 & (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);


			ulong v5 = ~v4;

			ulong v5_v1 = 0x2994137d6ea6a23aul;
			ulong v5_v2 = v5_v1 + (0xeaa42dccc28c0ca1ul);
			ulong v5_v3 = v5_v2 & (0x2aaf3f8c0f8be0f3ul);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Load_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xf61cddefc1270dful;
			ulong Input_l_v2 = Input_l_v1 >> (int) (((0x64a6b9d3abf30178ul) % 64ul) | 1ul);
			ulong Input_l_v3 = Input_l_v2 ^ (0x4d4c7e6dd4952157ul);
			ulong Input_l_v4 = Input_l_v3 + (Configuration.NtMinorVersion);
			ulong Input_l_v5 = Input_l_v4 * (0xf960e731329b2414ul);

			ulong Input_r_v1 = 0x958a6f9e7d76be5dul;
			ulong Input_r_v2 = Input_r_v1 ^ (0xe877e5685ce00c8dul);
			ulong Input_r_v3 = Input_r_v2 >> (int) (((0x186007fe08368b5aul) % 64ul) | 1ul);
			ulong Input_r_v4 = Input_r_v3 ^ (0x5f7fdd711b809e38ul);

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x2b86eab1b3aa7a3cul;
			ulong v1_v2 = v1_v1 + (0x2266e1769a0f0464ul);
			ulong v1_v3 = v1_v2 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v1_v4 = Mathematics.RotateLeft(v1_v3, (int) (((0x457ca0105fdc45a9ul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xbf865189f209640eul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 << (int) (((0xa1121cf5b93fcf6ul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 * (0x13270488dde9ca96ul);
			ulong v2_v5 = v2_v4 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);

			ulong v3 = v2 - ((v2_v5));

			ulong v3_v1 = 0xed81ef3d972660dbul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 ^ (0x1f0fc21df9dd5c2cul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x4baa898a40dc9ae0ul;
			ulong v4_v2 = Mathematics.RotateRight(v4_v1, (int) (((0x33ef00e5aa14a116ul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 * (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v4_v4 = v4_v3 >> (int) (((0x9d2b54578bc70fd1ul) % 64ul) | 1ul);

			ulong v5 = v4 + ((v4_v4));

			ulong v5_v1 = 0xde8c9f1c7d380a35ul;
			ulong v5_v2 = v5_v1 | (0xdf5c3a1cfd01dc46ul);
			ulong v5_v3 = v5_v2 - (0xada50fea8c3e0b71ul);
			ulong v5_v4 = Mathematics.RotateLeft(v5_v3, (int) (((0x47ae0983e1b37baaul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseShiftRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0xb1a4adcb56459e1bul;
			ulong v6_v2 = v6_v1 & (0x34d3f1210fb85d29ul);
			ulong v6_v3 = v6_v2 + (0xb29f9a92f0aab366ul);
			ulong v6_v4 = ~v6_v3;

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			return v7;
		}

		public static ulong Load_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x3f213a8689a6ee97ul;
			ulong Input_v2 = Input_v1 & (0xb87e6a49eee1208cul);
			ulong Input_v3 = Input_v2 + (0x6a8ec6c8caedcf7cul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseShiftLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));

			ulong v2 = ~v1;

			ulong v2_v1 = 0x9624d1f9be4600d7ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((0x91cee2e716405d40ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 & (0xfab705a187ce40d5ul);
			ulong v2_v4 = v2_v3 - (0xade4f6206d4ea283ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v4 % 64ul) | 1ul))));

			ulong v3_v1 = 0x3b69edf7ea29bd54ul;
			ulong v3_v2 = v3_v1 ^ (0x3419f0ea8f8f208ful);
			ulong v3_v3 = v3_v2 - (0x5715791aa852d13eul);
			ulong v3_v4 = ~v3_v3;
			ulong v3_v5 = v3_v4 - (0xb8602bd0dc8ef418ul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x40299d759d775e9bul;
			ulong v4_l_v2 = v4_l_v1 + (0xcb00b95280489d6ful);
			ulong v4_l_v3 = Mathematics.RotateLeft(v4_l_v2, (int) (((0x4394763bae04530cul) % 64ul) | 1ul));
			ulong v4_l_v4 = v4_l_v3 << (int) (((0x902bdbdc9fe676a6ul) % 64ul) | 1ul);
			ulong v4_l_v5 = v4_l_v4 + (0xd0026d62dd404673ul);

			ulong v4_r_v1 = 0x5cb1142e372d9a7dul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((0xcc76d318ec84db4bul) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 * (0x9fb272b4ebfc24d1ul);
			ulong v4_r_v4 = v4_r_v3 ^ (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v4_r_v5 = v4_r_v4 + (Configuration.NtMinorVersion);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0xdc3c35e815a88fedul;
			ulong v5_v2 = v5_v1 * (0x97701d52f5850bcful);
			ulong v5_v3 = v5_v2 | (0x13f47a75bc44025dul);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Load_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x7726e1464e4f8ffcul;
			ulong Input_v2 = Input_v1 * (0x96a3f6d3f0dcda67ul);
			ulong Input_v3 = BinaryPrimitives.ReverseEndianness(Input_v2);
			ulong Input_v4 = Input_v3 >> (int) (((0xc3a4a230d57b180eul) % 64ul) | 1ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v4 | 1ul)));
			ulong v1_v1 = 0xc9e369fa1ee7ab89ul;
			ulong v1_v2 = v1_v1 & (0x3e247e90d1cf14d3ul);
			ulong v1_v3 = v1_v2 * (0x6523a8aac73d386ul);
			ulong v1_v4 = v1_v3 | (0x6cd6154ee4ff110ul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0x18ef8bb6e62e26eaul;
			ulong v2_l_v2 = BinaryPrimitives.ReverseEndianness(v2_l_v1);
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0x82d6615b7f1ccb55ul) % 64ul) | 1ul));
			ulong v2_l_v4 = Mathematics.RotateRight(v2_l_v3, (int) (((0xd2979765cb0d2479ul) % 64ul) | 1ul));
			ulong v2_l_v5 = v2_l_v4 & (0x1b74d678ad0605feul);

			ulong v2_r_v1 = 0x14f7b42dd6b21486ul;
			ulong v2_r_v2 = v2_r_v1 << (int) (((0x254763958360e471ul) % 64ul) | 1ul);
			ulong v2_r_v3 = ~v2_r_v2;
			ulong v2_r_v4 = v2_r_v3 - (0x9e0780ccd94f440aul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x65da6b6bd35f9db4ul;
			ulong v3_v2 = v3_v1 << (int) (((0x7b74ed4a26864308ul) % 64ul) | 1ul);
			ulong v3_v3 = v3_v2 * (0x700f7ef5e33f274ful);
			ulong v3_v4 = v3_v3 + (0x7a2d94e17cd66bccul);
			ulong v3_v5 = ~v3_v4;

			ulong v4 = Mathematics.InverseShiftRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x2f269a602b6f6f17ul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 - (0x41f1e4a030d61683ul);
			ulong v4_v4 = v4_v3 & (0xe9c7d2018428b002ul);
			ulong v4_v5 = v4_v4 << (int) (((0x5dd290e392d4b99ul) % 64ul) | 1ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_v1 = 0x1982d0847a390978ul;
			ulong v5_v2 = Mathematics.RotateRight(v5_v1, (int) (((0x83b0088ae347ef1aul) % 64ul) | 1ul));
			ulong v5_v3 = v5_v2 * (0x40f26e50447885b4ul);
			ulong v5_v4 = v5_v3 + (0x753b56f9f164e3b9ul);
			ulong v5_v5 = Mathematics.RotateRight(v5_v4, (int) (((0x4d3d19f726f4787bul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseShiftRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0x37914d48ba36d3ul;
			ulong v6_v2 = Mathematics.RotateLeft(v6_v1, (int) (((0xa568ec046b12af4cul) % 64ul) | 1ul));
			ulong v6_v3 = v6_v2 - (0x2db1769fcf4e134cul);
			ulong v6_v4 = v6_v3 ^ (0x7f5d5ee0ef4c6ce0ul);

			ulong v7 = Mathematics.RotateLeft(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Add_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x6fd8f78af4b74e0bul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 << (int) (((0x1487f109d351e8fdul) % 64ul) | 1ul);
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((Configuration.CpuBrandString2[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x5a45daa06f3dee89ul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 | (0x9e2cbf564a15b2e9ul);
			ulong v1_v4 = Mathematics.RotateLeft(v1_v3, (int) (((0x90487fdb5c385d2aul) % 64ul) | 1ul));

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0x4b628ba00fa45320ul;
			ulong v2_l_v2 = v2_l_v1 + (0x1b4f52256a598cedul);
			ulong v2_l_v3 = v2_l_v2 - (Configuration.NtMinorVersion);
			ulong v2_l_v4 = v2_l_v3 + (0x4edcfd72ed1ec64cul);

			ulong v2_r_v1 = 0x9f4464be8bd81ecful;
			ulong v2_r_v2 = v2_r_v1 << (int) (((0x8bb5940beebfb0f5ul) % 64ul) | 1ul);
			ulong v2_r_v3 = v2_r_v2 ^ (0x6e36cbcc0b166ff9ul);
			ulong v2_r_v4 = v2_r_v3 >> (int) (((0xbdfe1bb3e423133eul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationRightRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0xcd669efa745740e6ul;
			ulong v3_l_v2 = ~v3_l_v1;
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((0xbcb5560e119b49ebul) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (0xb47b14e7aa95a1ful);

			ulong v3_r_v1 = 0x95cf8213c4e42d02ul;
			ulong v3_r_v2 = Mathematics.RotateLeft(v3_r_v1, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v3_r_v3 = v3_r_v2 * (0x5de9c63af3a47be5ul);
			ulong v3_r_v4 = v3_r_v3 + (0xdcf92822728b712bul);
			ulong v3_r_v5 = v3_r_v4 | (0xf15cb4505ce69c0bul);

			ulong v4 = Mathematics.InverseRotationRightLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xe33fd038f20ab4c1ul;
			ulong v4_v2 = v4_v1 | (0x8b81ce2d23ea1256ul);
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = v4_v3 & (0x21fdf79df6434dc2ul);
			ulong v4_v5 = v4_v4 ^ (Configuration.CpuBrandString1[1] & 0xffffffff);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x2c1651f977bd748eul;
			ulong v5_l_v2 = ~v5_l_v1;
			ulong v5_l_v3 = v5_l_v2 << (int) (((0xeef89d4c04bf10c7ul) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 | (0x69807ee854f53aa8ul);

			ulong v5_r_v1 = 0xdaf97e35282d72edul;
			ulong v5_r_v2 = ~v5_r_v1;
			ulong v5_r_v3 = v5_r_v2 * (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v5_r_v4 = v5_r_v3 >> (int) (((0x3853b0b78c147e24ul) % 64ul) | 1ul);
			ulong v5_r_v5 = v5_r_v4 + (0xbe154d425a623621ul);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0xc3ae938d7ee9f5e4ul;
			ulong v6_v2 = v6_v1 << (int) (((0xb555c0e8324879aful) % 64ul) | 1ul);
			ulong v6_v3 = ~v6_v2;
			ulong v6_v4 = v6_v3 & (0x9d3aed7ce3c6fd25ul);
			ulong v6_v5 = v6_v4 - (0x3add7f7dddd0b00ul);

			ulong v7 = Mathematics.RotateRight(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Add_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xf464ca81458ad382ul;
			ulong Input_l_v2 = Input_l_v1 & (0xafdd1fa902e4103aul);
			ulong Input_l_v3 = Input_l_v2 ^ (0x4dbfa36322b5d5b9ul);
			ulong Input_l_v4 = ~Input_l_v3;

			ulong Input_r_v1 = 0x46302d95053e94cbul;
			ulong Input_r_v2 = Mathematics.RotateRight(Input_r_v1, (int) (((0xa0c171e2e41a53d4ul) % 64ul) | 1ul));
			ulong Input_r_v3 = Mathematics.RotateLeft(Input_r_v2, (int) (((0x5fdfec1e88ae8cbbul) % 64ul) | 1ul));
			ulong Input_r_v4 = Input_r_v3 * (0xf9d3883549d74ee5ul);

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x472a5bb73f0882c1ul;
			ulong v1_v2 = v1_v1 - (Configuration.CpuBrandString3[2] & 0xffffffff);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0xadf04c48726c403dul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 | (0x627ba8e5cca4b7f1ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x981ef2ebbc74c94ul;
			ulong v2_v2 = v2_v1 + (0x8ef0815f70040d34ul);
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = v2_v3 * (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v2_v5 = v2_v4 << (int) (((0x3c5b71c24b61e7d5ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x696e463de1ca665ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((0xcb86b3ddd4e3b395ul) % 64ul) | 1ul));
			ulong v3_v4 = ~v3_v3;

			ulong v4 = Mathematics.InverseShiftRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0xf447aac1b07a0f3ful;
			ulong v4_l_v2 = v4_l_v1 ^ (0xd4d4c2c98d54477ful);
			ulong v4_l_v3 = v4_l_v2 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v4_l_v4 = ~v4_l_v3;

			ulong v4_r_v1 = 0x93966afeb05e1431ul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((0x6f0a6adb52209e7ul) % 64ul) | 1ul);
			ulong v4_r_v3 = ~v4_r_v2;
			ulong v4_r_v4 = v4_r_v3 << (int) (((0x71d9db9e97d52449ul) % 64ul) | 1ul);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x5e2f84d55c3831eeul;
			ulong v5_v2 = v5_v1 + (0x251d1450f4295f82ul);
			ulong v5_v3 = Mathematics.RotateLeft(v5_v2, (int) (((0x58c7d520582ecca3ul) % 64ul) | 1ul));
			ulong v5_v4 = ~v5_v3;
			ulong v5_v5 = v5_v4 | (0xf1a8cd058e10c30aul);

			ulong v6 = v5 + ((v5_v5));

			return v6;
		}

		public static ulong Add_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xc9eba5bd3d3a5cb6ul;
			ulong Input_l_v2 = Mathematics.RotateLeft(Input_l_v1, (int) (((0xdb3d69904acac9dul) % 64ul) | 1ul));
			ulong Input_l_v3 = Input_l_v2 ^ (0xb1a6c6d7469c3d7ul);
			ulong Input_l_v4 = Mathematics.RotateRight(Input_l_v3, (int) (((0x1151c6298f2bd1daul) % 64ul) | 1ul));
			ulong Input_l_v5 = Input_l_v4 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);

			ulong Input_r_v1 = 0x79c1335ab8ac2fcdul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 * (Configuration.NtMinorVersion);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x509f7926717dbe3bul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x6886b016240171d7ul) % 64ul) | 1ul));

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));


			ulong v3 = ~v2;

			ulong v3_l_v1 = 0x37fcb313df44b8edul;
			ulong v3_l_v2 = ~v3_l_v1;
			ulong v3_l_v3 = v3_l_v2 << (int) (((0x9a1870369cb6eebul) % 64ul) | 1ul);
			ulong v3_l_v4 = Mathematics.RotateLeft(v3_l_v3, (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v3_l_v5 = v3_l_v4 & (0x26d5921e9146f542ul);

			ulong v3_r_v1 = 0x33f6a505384ea3a2ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = v3_r_v2 - (0x321147ea413569ceul);
			ulong v3_r_v4 = v3_r_v3 & (0x79c059a89b83eb0dul);
			ulong v3_r_v5 = v3_r_v4 * (0x94e5de8771f0031eul);

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xe812e2a793df42caul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((0x729ac1bca4bea206ul) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 << (int) (((0x7bf490eadd68ac26ul) % 64ul) | 1ul);
			ulong v4_v5 = ~v4_v4;

			ulong v5 = v4 - ((v4_v5));

			ulong v5_v1 = 0x9da56ef255a5120eul;
			ulong v5_v2 = v5_v1 + (0x485154e39d02d5cdul);
			ulong v5_v3 = v5_v2 << (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v5_v4 = Mathematics.RotateRight(v5_v3, (int) (((0xca93b18b95a9c809ul) % 64ul) | 1ul));

			ulong v6 = v5 ^ ((v5_v4));

			return v6;
		}

		public static ulong Add_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xb75cc5615f30349dul;
			ulong Input_l_v2 = Input_l_v1 * (0xb465700dddcf9775ul);
			ulong Input_l_v3 = Input_l_v2 - (0xae1105be7efe3968ul);
			ulong Input_l_v4 = Mathematics.RotateRight(Input_l_v3, (int) (((0xbf16444a091f7035ul) % 64ul) | 1ul));
			ulong Input_l_v5 = ~Input_l_v4;

			ulong Input_r_v1 = 0xfaab425afd3e0123ul;
			ulong Input_r_v2 = Input_r_v1 ^ (0x457f2b39a8d539fdul);
			ulong Input_r_v3 = Mathematics.RotateLeft(Input_r_v2, (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_r_v4 = Input_r_v3 << (int) (((0xcc6956fece6dda7bul) % 64ul) | 1ul);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x952c5467183385a7ul;
			ulong v1_l_v2 = v1_l_v1 & (0x5a8d30f5a7275b89ul);
			ulong v1_l_v3 = v1_l_v2 >> (int) (((0x37ba8d8eac467a16ul) % 64ul) | 1ul);
			ulong v1_l_v4 = v1_l_v3 - (0x454a25e0fbeaf3f8ul);

			ulong v1_r_v1 = 0x87a6433e0177a0f5ul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = Mathematics.RotateRight(v1_r_v2, (int) (((0x2a911612539f40e7ul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 & (0x635bcc5247373b38ul);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x4f8911e9d5695bd0ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((0xf3d2d63db3191251ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 - (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v2_v4 = v2_v3 << (int) (((0x75148500a4559b28ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_v1 = 0x88a275dc95855db9ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 ^ (0x9ac9a9c0cbd4e6daul);
			ulong v4_v4 = v4_v3 | (Configuration.CpuBrandString3[2] & 0xffffffff);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			ulong v6_v1 = 0xcc336489f71a276ful;
			ulong v6_v2 = v6_v1 - (0x1aa91980df99eeb5ul);
			ulong v6_v3 = v6_v2 << (int) (((0x46c0c77b4234b67ful) % 64ul) | 1ul);
			ulong v6_v4 = v6_v3 | (0xe50bbf8b006cf256ul);
			ulong v6_v5 = v6_v4 + (0xe20f46c618795a6bul);

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v6_v5 % 64ul) | 1ul))));

			ulong v7_v1 = 0xdba6c29d146df17cul;
			ulong v7_v2 = ~v7_v1;
			ulong v7_v3 = Mathematics.RotateLeft(v7_v2, (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v7_v4 = Mathematics.RotateRight(v7_v3, (int) (((0xf6804c2261cd5f84ul) % 64ul) | 1ul));
			ulong v7_v5 = ~v7_v4;

			ulong v8 = Mathematics.RotateRight(v7, (int) (((v7_v5 % 64ul) | 1ul)));

			return v8;
		}

		public static ulong Add_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x3a154ab156abee25ul;
			ulong Input_l_v2 = Input_l_v1 - (0x69f0c05a98988464ul);
			ulong Input_l_v3 = Input_l_v2 * (0x9c74adf045d78ee3ul);
			ulong Input_l_v4 = Input_l_v3 & (0x4a743d5f47c0c227ul);

			ulong Input_r_v1 = 0xc023cd51e65bff85ul;
			ulong Input_r_v2 = Input_r_v1 & (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong Input_r_v3 = Input_r_v2 + (Configuration.NtBuildNumber);
			ulong Input_r_v4 = Mathematics.RotateRight(Input_r_v3, (int) (((0x5c1932b41e0e52a1ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));

			ulong v2 = ~v1;

			ulong v2_v1 = 0xe9ac03a25db1b7fbul;
			ulong v2_v2 = v2_v1 >> (int) (((0x651d5b5bbc46f2aful) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 ^ (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v2_v4 = v2_v3 | (0x60d9bfac1699015aul);
			ulong v2_v5 = v2_v4 - (Configuration.CpuBrandString1[2] & 0xffffffff);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x75be6084ee5e515ul;
			ulong v3_v2 = v3_v1 ^ (0x68d53c03cd02eea9ul);
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 & (0xf6d26fd1aab91369ul);

			ulong v4 = v3 - ((v3_v4));

			ulong v4_l_v1 = 0xea07b03ad5652db4ul;
			ulong v4_l_v2 = Mathematics.RotateLeft(v4_l_v1, (int) (((0x55d04564737150d3ul) % 64ul) | 1ul));
			ulong v4_l_v3 = ~v4_l_v2;
			ulong v4_l_v4 = v4_l_v3 >> (int) (((0x7c2f4ff5c7b02ae0ul) % 64ul) | 1ul);

			ulong v4_r_v1 = 0x99283618b54b6dd8ul;
			ulong v4_r_v2 = Mathematics.RotateRight(v4_r_v1, (int) (((0x7f27df3c1a5df29ul) % 64ul) | 1ul));
			ulong v4_r_v3 = BinaryPrimitives.ReverseEndianness(v4_r_v2);
			ulong v4_r_v4 = v4_r_v3 - (0x9db47ff4fc767235ul);
			ulong v4_r_v5 = BinaryPrimitives.ReverseEndianness(v4_r_v4);

			ulong v5 = Mathematics.InverseRotationRightRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Sub_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x6f37baadd5ec1c9bul;
			ulong Input_v2 = BinaryPrimitives.ReverseEndianness(Input_v1);
			ulong Input_v3 = Input_v2 + (0xd3efcda07ae18c4ul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0xd328c514d8549e03ul) % 64ul) | 1ul));
			ulong Input_v5 = Mathematics.RotateRight(Input_v4, (int) (((0x288ae66135162486ul) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x9c56851382443fedul;
			ulong v1_v2 = v1_v1 | (0x95f07cea260d3f5bul);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0x392abfc3cbb77387ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 & (Configuration.NtMajorVersion);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));


			ulong v3 = ~v2;

			ulong v3_v1 = 0xc7cf99da3721a5a0ul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0xfe87ad9edf2e1c92ul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 + (0x361db162e1353877ul);
			ulong v3_v4 = v3_v3 << (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 - (Configuration.CpuBrandString3[2] & 0xffffffff);

			ulong v4 = v3 ^ ((v3_v5));

			ulong v4_v1 = 0x5b4e94d5b6dcec4ful;
			ulong v4_v2 = v4_v1 << (int) (((0x9b00e204ef899f82ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 >> (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 | (Configuration.CpuBrandString3[3] & 0xffffffff);
			ulong v4_v5 = v4_v4 * (0xd1a42f05efe87fcbul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(((v4_v5 | 1ul)));

			ulong v5_v1 = 0xc70bc8a75bb84113ul;
			ulong v5_v2 = v5_v1 | (0x6bc37bc79100d328ul);
			ulong v5_v3 = Mathematics.RotateLeft(v5_v2, (int) (((0xeaafdedbe7bbdf7bul) % 64ul) | 1ul));
			ulong v5_v4 = v5_v3 >> (int) (((0x8f805f360a094a69ul) % 64ul) | 1ul);
			ulong v5_v5 = BinaryPrimitives.ReverseEndianness(v5_v4);

			ulong v6 = Mathematics.RotateLeft(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Sub_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x172069b756d94b9bul;
			ulong Input_l_v2 = Input_l_v1 - (0x6bc6a94102f48d0eul);
			ulong Input_l_v3 = Input_l_v2 ^ (0x18b0015595bb44b9ul);
			ulong Input_l_v4 = Input_l_v3 & (0xf82c4aafc7ca0593ul);
			ulong Input_l_v5 = Input_l_v4 - (0xaafe1c4b0882da7aul);

			ulong Input_r_v1 = 0x212547fc0631a984ul;
			ulong Input_r_v2 = Mathematics.RotateLeft(Input_r_v1, (int) (((0x8cbcef82f1c87926ul) % 64ul) | 1ul));
			ulong Input_r_v3 = Input_r_v2 << (int) (((0xced062012a5d1ef1ul) % 64ul) | 1ul);
			ulong Input_r_v4 = BinaryPrimitives.ReverseEndianness(Input_r_v3);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xc1e8427bff70cd0aul;
			ulong v1_l_v2 = v1_l_v1 & (0x6e7bdf89f0405456ul);
			ulong v1_l_v3 = v1_l_v2 + (0x3d8f108e7d72b860ul);
			ulong v1_l_v4 = v1_l_v3 & (0xb5cd5d8cef202ef0ul);
			ulong v1_l_v5 = BinaryPrimitives.ReverseEndianness(v1_l_v4);

			ulong v1_r_v1 = 0x586eba2e93f64fc2ul;
			ulong v1_r_v2 = v1_r_v1 << (int) (((0x1b0f5847a2d63ac0ul) % 64ul) | 1ul);
			ulong v1_r_v3 = v1_r_v2 * (0xceb7761bf4630ful);
			ulong v1_r_v4 = v1_r_v3 << (int) (((0x59ab82c7044bbcc9ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x7e04b4a6f7c56588ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 << (int) (((0x8199fc18a2d5f8a0ul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 * (0x13854d6e15f91781ul);
			ulong v2_v5 = v2_v4 + (0x21bfb22042ea4fd6ul);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0x3d3f3324cd2efbf5ul;
			ulong v3_v2 = v3_v1 & (0xf85c80fbae5ea775ul);
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 + (0x4667a17ec6ecfb3aul);
			ulong v3_v5 = v3_v4 ^ (Configuration.NtMajorVersion);

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v5 | 1ul)));

			ulong v4_v1 = 0x886d77a4078b3d1aul;
			ulong v4_v2 = v4_v1 & (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v4_v3 = v4_v2 - (Configuration.NtMajorVersion);
			ulong v4_v4 = v4_v3 >> (int) (((0xc00e53b236b5552bul) % 64ul) | 1ul);
			ulong v4_v5 = v4_v4 & (0x18b2cdf82696eee2ul);

			ulong v5 = v4 ^ ((v4_v5));

			ulong v5_v1 = 0xecfd58a0e7eaa906ul;
			ulong v5_v2 = v5_v1 ^ (0x28f2c7675dc74b1ul);
			ulong v5_v3 = v5_v2 & (0x41f3b7801f342cecul);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);
			ulong v5_v5 = ~v5_v4;

			ulong v6 = Mathematics.InverseShiftRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0x26a16f6dd7e1cfc1ul;
			ulong v6_l_v2 = Mathematics.RotateRight(v6_l_v1, (int) (((0xc2ddd62b529c14e4ul) % 64ul) | 1ul));
			ulong v6_l_v3 = ~v6_l_v2;
			ulong v6_l_v4 = v6_l_v3 | (Configuration.NtMinorVersion);

			ulong v6_r_v1 = 0x3d3f7e17b695e08ful;
			ulong v6_r_v2 = v6_r_v1 * (0x76a46bd2d8e16ecful);
			ulong v6_r_v3 = v6_r_v2 - (0x665ea216e0d81095ul);
			ulong v6_r_v4 = v6_r_v3 << (int) (((0x5c496a9b647dc027ul) % 64ul) | 1ul);

			ulong v7 = Mathematics.InverseRotationLeftRight(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Sub_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x96040e25e7ee9aa8ul;
			ulong Input_l_v2 = Input_l_v1 * (0x3318bd2bfb4e742cul);
			ulong Input_l_v3 = Mathematics.RotateRight(Input_l_v2, (int) (((0xbb38d7fd2233b04bul) % 64ul) | 1ul));
			ulong Input_l_v4 = Input_l_v3 + (0xe5552d8dcdf3a976ul);

			ulong Input_r_v1 = 0x59b98f04847de12aul;
			ulong Input_r_v2 = Input_r_v1 & (Configuration.NtMinorVersion);
			ulong Input_r_v3 = Input_r_v2 << (int) (((0xecfa1bb06aab98b9ul) % 64ul) | 1ul);
			ulong Input_r_v4 = ~Input_r_v3;
			ulong Input_r_v5 = Input_r_v4 | (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x53efb371088676ceul;
			ulong v1_v2 = v1_v1 | (0x9d1df735e1b4b627ul);
			ulong v1_v3 = v1_v2 ^ (Configuration.NtMinorVersion);
			ulong v1_v4 = v1_v3 + (0x3b1aa8c4c8bb50bful);
			ulong v1_v5 = v1_v4 - (0xdbd634782fc4fc38ul);

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xea5aade5340c544ul;
			ulong v2_v2 = v2_v1 | (Configuration.NtMinorVersion);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 << (int) (((0x9ee41c00ae93231dul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x753e139e7302eab3ul;
			ulong v3_l_v2 = v3_l_v1 & (Configuration.NtMinorVersion);
			ulong v3_l_v3 = v3_l_v2 | (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v3_l_v4 = v3_l_v3 & (0x16643661a960474ul);

			ulong v3_r_v1 = 0x20ce47edb30fb9d3ul;
			ulong v3_r_v2 = v3_r_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v3_r_v3 = v3_r_v2 * (0xf6fbcd9e78b9bf38ul);
			ulong v3_r_v4 = v3_r_v3 + (0x65badf9c014a9f43ul);

			ulong v4 = Mathematics.InverseRotationRightLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xfa4e60409b04ea40ul;
			ulong v4_v2 = v4_v1 ^ (0x827c2beb67028db6ul);
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 | (0xe5b2e444d355a15eul);
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_l_v1 = 0x8b4fed6e517623d2ul;
			ulong v5_l_v2 = Mathematics.RotateLeft(v5_l_v1, (int) (((0xfa70bd807757b141ul) % 64ul) | 1ul));
			ulong v5_l_v3 = v5_l_v2 & (0xbe4418b481141ff3ul);
			ulong v5_l_v4 = v5_l_v3 + (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v5_l_v5 = Mathematics.RotateLeft(v5_l_v4, (int) (((0x595ccdafae79d00aul) % 64ul) | 1ul));

			ulong v5_r_v1 = 0x822f3278694db024ul;
			ulong v5_r_v2 = ~v5_r_v1;
			ulong v5_r_v3 = v5_r_v2 - (0xab4299d8c093dc6cul);
			ulong v5_r_v4 = v5_r_v3 << (int) (((0xfaa6f066f7fee808ul) % 64ul) | 1ul);
			ulong v5_r_v5 = v5_r_v4 & (0x7d5876436f125980ul);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0x5ef1f1486fb757d9ul;
			ulong v6_l_v2 = BinaryPrimitives.ReverseEndianness(v6_l_v1);
			ulong v6_l_v3 = v6_l_v2 >> (int) (((0xb9d250a5a80c1c03ul) % 64ul) | 1ul);
			ulong v6_l_v4 = v6_l_v3 & (0xdaa31168cf1e51b3ul);

			ulong v6_r_v1 = 0xeca5f07172fb383dul;
			ulong v6_r_v2 = v6_r_v1 & (0xbee9459df21cec0dul);
			ulong v6_r_v3 = v6_r_v2 << (int) (((0xef927e910c1a6905ul) % 64ul) | 1ul);
			ulong v6_r_v4 = v6_r_v3 - (0xc76fa693abe10f45ul);
			ulong v6_r_v5 = v6_r_v4 & (Configuration.CpuBrandString3[1] & 0xffffffff);

			ulong v7 = Mathematics.InverseRotationRightRight(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v5 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Sub_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xf5608e81e4c863fdul;
			ulong Input_l_v2 = BinaryPrimitives.ReverseEndianness(Input_l_v1);
			ulong Input_l_v3 = Input_l_v2 - (0x6d2998e63592ad24ul);
			ulong Input_l_v4 = Input_l_v3 & (0xb6b88a5922165c74ul);

			ulong Input_r_v1 = 0xb23282109563feacul;
			ulong Input_r_v2 = Input_r_v1 & (0xc5734f2716c444ccul);
			ulong Input_r_v3 = ~Input_r_v2;
			ulong Input_r_v4 = Input_r_v3 - (0x508eadb792cd83daul);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x624f8b8db46d19bbul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = Mathematics.RotateLeft(v1_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 - (Configuration.NtMajorVersion);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0x909f23381166c5d9ul;
			ulong v2_l_v2 = v2_l_v1 - (0x93b58a35f5386dc1ul);
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0xe98d413a26d8e588ul) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 * (0xe0681a916e7202caul);

			ulong v2_r_v1 = 0x4a593d1a1df12627ul;
			ulong v2_r_v2 = Mathematics.RotateLeft(v2_r_v1, (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_r_v3 = v2_r_v2 - (0x20990c67ab425442ul);
			ulong v2_r_v4 = Mathematics.RotateRight(v2_r_v3, (int) (((0xc2accd7f1375d8d7ul) % 64ul) | 1ul));

			ulong v3 = Mathematics.InverseRotationRightRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x97208977eabf5922ul;
			ulong v3_l_v2 = BinaryPrimitives.ReverseEndianness(v3_l_v1);
			ulong v3_l_v3 = v3_l_v2 ^ (0x450577f44ebcbde2ul);
			ulong v3_l_v4 = v3_l_v3 + (0x59694ba46c5b1312ul);
			ulong v3_l_v5 = v3_l_v4 | (Configuration.NtMajorVersion);

			ulong v3_r_v1 = 0x2343ce90eb510decul;
			ulong v3_r_v2 = BinaryPrimitives.ReverseEndianness(v3_r_v1);
			ulong v3_r_v3 = v3_r_v2 & (0xfd6b6467b80b2df9ul);
			ulong v3_r_v4 = v3_r_v3 - (0xa7c7c27faf4b4877ul);

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x49ebc614e5050ed9ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x625cc4510486117ul) % 64ul) | 1ul);
			ulong v4_v3 = Mathematics.RotateRight(v4_v2, (int) (((0xe7f329ae60b67940ul) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Sub_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xb2ade306d424a6ul;
			ulong Input_l_v2 = Input_l_v1 ^ (0xec383012e76a187dul);
			ulong Input_l_v3 = Mathematics.RotateLeft(Input_l_v2, (int) (((0xe6820bb8435fca2ful) % 64ul) | 1ul));
			ulong Input_l_v4 = Input_l_v3 + (0x40f6bebf0982bb36ul);

			ulong Input_r_v1 = 0x3ae97c006d2649acul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = Input_r_v2 ^ (0xa89d3179fc59364bul);
			ulong Input_r_v4 = Mathematics.RotateRight(Input_r_v3, (int) (((0x8afc70508765e370ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x262fec3d8b1f8199ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = v1_l_v2 - (0xa6714cf64f0fa9bful);
			ulong v1_l_v4 = v1_l_v3 ^ (Configuration.CpuBrandString1[1] & 0xffffffff);

			ulong v1_r_v1 = 0x656f20e7e776b2e9ul;
			ulong v1_r_v2 = v1_r_v1 * (0xf179461391fb7c9dul);
			ulong v1_r_v3 = v1_r_v2 + (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v1_r_v4 = Mathematics.RotateLeft(v1_r_v3, (int) (((0x4beca9212f569a5dul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_v1 = 0x4ad05c6da751397cul;
			ulong v3_v2 = v3_v1 - (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v3_v3 = v3_v2 << (int) (((0x10cf31400dc156eful) % 64ul) | 1ul);
			ulong v3_v4 = v3_v3 ^ (0x6a568b02da5cbc60ul);
			ulong v3_v5 = v3_v4 & (0x841e0d3f018bcacdul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));


			ulong v5 = ~v4;

			ulong v5_l_v1 = 0x11bc3a06653bb000ul;
			ulong v5_l_v2 = v5_l_v1 ^ (Configuration.NtMajorVersion);
			ulong v5_l_v3 = v5_l_v2 + (Configuration.NtMinorVersion);
			ulong v5_l_v4 = ~v5_l_v3;
			ulong v5_l_v5 = v5_l_v4 + (0x5e99ad530c50442cul);

			ulong v5_r_v1 = 0xd91033075608c981ul;
			ulong v5_r_v2 = v5_r_v1 >> (int) (((0xb8faf609f1d96a8dul) % 64ul) | 1ul);
			ulong v5_r_v3 = BinaryPrimitives.ReverseEndianness(v5_r_v2);
			ulong v5_r_v4 = v5_r_v3 & (0x398ef96d6c7da3eeul);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Sub_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x221b574b6cb5b281ul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong Input_v3 = BinaryPrimitives.ReverseEndianness(Input_v2);
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((0xd3081d9b83a22e86ul) % 64ul) | 1ul));
			ulong Input_v5 = Input_v4 | (0xaf5c76f2f09d5dbdul);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v5 | 1ul)));
			ulong v1_v1 = 0x40f7a650a2a6d16ul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((0xd7fd6794b9a37b87ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 ^ (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v1_v4 = v1_v3 + (0x38cf75c0c6ec6166ul);
			ulong v1_v5 = v1_v4 & (0x8f45e3081e30516ful);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xa24f46e86b31e98eul;
			ulong v2_v2 = v2_v1 >> (int) (((0xf23a92bb6807130ul) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 ^ (0x38956675fcc9dec1ul);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);

			ulong v3 = v2 + ((v2_v4));


			ulong v4 = ~v3;

			ulong v4_v1 = 0xb66f27d21fb6eba4ul;
			ulong v4_v2 = v4_v1 | (0xa2fa2ff339988963ul);
			ulong v4_v3 = v4_v2 + (0x25c3f22e1fe137dbul);
			ulong v4_v4 = v4_v3 | (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v4_v5 = v4_v4 >> (int) (((0xc9173f362d35287cul) % 64ul) | 1ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v5 % 64ul) | 1ul))));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			ulong v6_v1 = 0xa370221dbc2e4e4aul;
			ulong v6_v2 = v6_v1 & (0xf57ee4d0b210cf73ul);
			ulong v6_v3 = v6_v2 - (0xa6270c4177f2b899ul);
			ulong v6_v4 = v6_v3 ^ (0xd22f75d928f19830ul);
			ulong v6_v5 = v6_v4 * (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v7 = v6 * Mathematics.InverseMultiplication(((v6_v5 | 1ul)));

			ulong v7_v1 = 0xc605048e3048d3f2ul;
			ulong v7_v2 = ~v7_v1;
			ulong v7_v3 = v7_v2 - (0x2e3003e2836f0faful);
			ulong v7_v4 = v7_v3 * (0x7276c4f05a981451ul);
			ulong v7_v5 = Mathematics.RotateRight(v7_v4, (int) (((0x8072657999ed29acul) % 64ul) | 1ul));

			ulong v8 = v7 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v7_v5 % 64ul) | 1ul))));

			return v8;
		}

		public static ulong Sub_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xa9954071bada70d5ul;
			ulong Input_v2 = Input_v1 - (0x3338e547d54ff9e4ul);
			ulong Input_v3 = Input_v2 & (0x63a478a3232a1b7cul);
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x51a327f065210263ul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0xb8def756d0161c88ul) % 64ul) | 1ul));
			ulong v1_v3 = Mathematics.RotateLeft(v1_v2, (int) (((0x8a8e7403f2a7ecebul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 << (int) (((0x67222135a587a7ebul) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 | (0xdd5da35d82f74a63ul);

			ulong v2 = v1 - ((v1_v5));

			ulong v2_v1 = 0x7036c2b4a458675bul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 << (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 * (Configuration.NtMajorVersion);
			ulong v2_v5 = v2_v4 + (0x6cb37c8280ce359ful);

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x7e3e7bcab5567e8ful;
			ulong v3_v2 = v3_v1 * (0xf213779c49676982ul);
			ulong v3_v3 = v3_v2 >> (int) (((0x53a5b898d642aaf1ul) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((0xb66f8a8dabe550e6ul) % 64ul) | 1ul));
			ulong v3_v5 = v3_v4 & (0x4bde613373ee51eaul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xab1ed680ae6a8493ul;
			ulong v4_v2 = v4_v1 - (0x7a399633c66fefc5ul);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((0x57b2cbb0b9ea1939ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 + (0xd78afe646b6bdeacul);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Sub_7_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xb622bf37b31a4d4aul;
			ulong Input_l_v2 = Input_l_v1 >> (int) (((0x113126fee789d5dful) % 64ul) | 1ul);
			ulong Input_l_v3 = ~Input_l_v2;
			ulong Input_l_v4 = Input_l_v3 * (0xd8c9d1cc5e7df39cul);

			ulong Input_r_v1 = 0xd89a0ff08e2ecd95ul;
			ulong Input_r_v2 = Mathematics.RotateRight(Input_r_v1, (int) (((0x945fee98e6ce9c28ul) % 64ul) | 1ul));
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 >> (int) (((0x278820503250e1fcul) % 64ul) | 1ul);
			ulong Input_r_v5 = Input_r_v4 | (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xe7f49e59dee64c64ul;
			ulong v1_v2 = v1_v1 ^ (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong v1_v3 = ~v1_v2;
			ulong v1_v4 = v1_v3 ^ (0x662efb8291c11ed1ul);
			ulong v1_v5 = v1_v4 << (int) (((0xdd6e0db2258a5a1aul) % 64ul) | 1ul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v1_v5 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0x534f349a18611aul;
			ulong v2_l_v2 = v2_l_v1 + (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0x3c6ce8ca3e01990aul) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 & (0x9655b5b966f61d13ul);

			ulong v2_r_v1 = 0x5bd3671cb794396ful;
			ulong v2_r_v2 = v2_r_v1 | (0x56def704541e246cul);
			ulong v2_r_v3 = v2_r_v2 >> (int) (((0xc1bb532431a5d8d3ul) % 64ul) | 1ul);
			ulong v2_r_v4 = v2_r_v3 & (0x2784a99ccdfe383ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xec304f8a453c5d01ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 - (Configuration.NtMinorVersion);
			ulong v3_v4 = v3_v3 + (0x26e9664aaa09747dul);

			ulong v4 = v3 + ((v3_v4));


			ulong v5 = ~v4;

			return v5;
		}

		public static ulong Mul_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xdae4cf03621df496ul;
			ulong Input_l_v2 = Input_l_v1 + (0x8d802a9956f87b38ul);
			ulong Input_l_v3 = Input_l_v2 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong Input_l_v4 = Input_l_v3 * (0xd4f4336b0713bbe2ul);
			ulong Input_l_v5 = Input_l_v4 - (0xf8acd0be01a26375ul);

			ulong Input_r_v1 = 0x97d57c91bd39b5d5ul;
			ulong Input_r_v2 = Input_r_v1 * (0x576a580845b76c2ul);
			ulong Input_r_v3 = ~Input_r_v2;
			ulong Input_r_v4 = Input_r_v3 * (Configuration.NtBuildNumber);
			ulong Input_r_v5 = Input_r_v4 ^ (0x1b280a2c3b535609ul);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xc7d14997a7abee59ul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x2f9758ef647c859aul) % 64ul) | 1ul));
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 ^ (0x35aa1a20e5fabee6ul);
			ulong v1_v5 = Mathematics.RotateLeft(v1_v4, (int) (((0xaae2ac061d3d1bb9ul) % 64ul) | 1ul));

			ulong v2 = v1 - ((v1_v5));

			ulong v2_l_v1 = 0xe06eeeafa4dc3184ul;
			ulong v2_l_v2 = ~v2_l_v1;
			ulong v2_l_v3 = v2_l_v2 + (0x56a843dbd1fef1b7ul);
			ulong v2_l_v4 = v2_l_v3 - (0x9fa0d4d35699b18cul);

			ulong v2_r_v1 = 0x67de21d5c4a0aaeaul;
			ulong v2_r_v2 = Mathematics.RotateLeft(v2_r_v1, (int) (((0x24b7e4d671dc8dadul) % 64ul) | 1ul));
			ulong v2_r_v3 = BinaryPrimitives.ReverseEndianness(v2_r_v2);
			ulong v2_r_v4 = v2_r_v3 | (0x46f9799aad43cd51ul);
			ulong v2_r_v5 = v2_r_v4 ^ (0x30d1c0110e45851cul);

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x1fd149d0a20d7d49ul;
			ulong v3_l_v2 = v3_l_v1 ^ (0x8cef4f45516a81c7ul);
			ulong v3_l_v3 = v3_l_v2 - (0xaf3221d9cd521a8ul);
			ulong v3_l_v4 = v3_l_v3 + (0x36cdd7532bd401e9ul);

			ulong v3_r_v1 = 0x858168fc7acda02cul;
			ulong v3_r_v2 = v3_r_v1 - (0x3eb2259aaabb325cul);
			ulong v3_r_v3 = v3_r_v2 + (0x7cb13536df64c47ful);
			ulong v3_r_v4 = v3_r_v3 * (Configuration.CpuBrandString3[2] & 0xffffffff);

			ulong v4 = Mathematics.InverseRotationRightLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0xf2d3cbfb065a84a4ul;
			ulong v4_l_v2 = BinaryPrimitives.ReverseEndianness(v4_l_v1);
			ulong v4_l_v3 = v4_l_v2 + (0x3a61b10c5bb378f7ul);
			ulong v4_l_v4 = v4_l_v3 | (0x4e1ea2ed93b74cfbul);

			ulong v4_r_v1 = 0x61ef514a6b87a65bul;
			ulong v4_r_v2 = Mathematics.RotateRight(v4_r_v1, (int) (((0x546976b927ca08e9ul) % 64ul) | 1ul));
			ulong v4_r_v3 = v4_r_v2 * (0xc6303403c2e93f8aul);
			ulong v4_r_v4 = v4_r_v3 | (0x51a9f9ef03455e2eul);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0xf0f015c1c1353547ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = Mathematics.RotateLeft(v5_v2, (int) (((0x9488fab198915993ul) % 64ul) | 1ul));
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);

			ulong v6 = Mathematics.RotateLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Mul_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xbf88a818c76397a8ul;
			ulong Input_v2 = Input_v1 | (0xa1192f147690e8e9ul);
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Input_v3 >> (int) (((0xa6ca65e3f52bea63ul) % 64ul) | 1ul);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0xc0875d030a24e9b1ul;
			ulong v1_v2 = v1_v1 & (0x6ea54b50f25ce58eul);
			ulong v1_v3 = ~v1_v2;
			ulong v1_v4 = v1_v3 * (0x1a6e8546a3729428ul);
			ulong v1_v5 = v1_v4 >> (int) (((0x427c048ea8d788beul) % 64ul) | 1ul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v5 % 64ul) | 1ul))));

			ulong v2_v1 = 0xc8ef0af90e588de6ul;
			ulong v2_v2 = v2_v1 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 * (0x667a0a45af9d7a8ful);
			ulong v2_v4 = v2_v3 << (int) (((0x85916beb0a6ebbdul) % 64ul) | 1ul);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_l_v1 = 0x1796deb162cc72b7ul;
			ulong v4_l_v2 = v4_l_v1 & (0x2a95f82dcaa88005ul);
			ulong v4_l_v3 = v4_l_v2 - (0x737e5d7e12b418a0ul);
			ulong v4_l_v4 = v4_l_v3 | (0xdb8e21ff1dce457aul);
			ulong v4_l_v5 = v4_l_v4 & (0xa06c2a7f3212145eul);

			ulong v4_r_v1 = 0x2e7bf29abd56019ful;
			ulong v4_r_v2 = v4_r_v1 * (0x55db18bf4f17b5e0ul);
			ulong v4_r_v3 = v4_r_v2 << (int) (((0x687b6d1f96f6336ful) % 64ul) | 1ul);
			ulong v4_r_v4 = v4_r_v3 - (0x5de5eddeb4889b57ul);

			ulong v5 = Mathematics.InverseRotationLeftLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Mul_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xcf8d1d5965b5975ul;
			ulong Input_v2 = Input_v1 + (0x835bef8e0969add4ul);
			ulong Input_v3 = Input_v2 * (0xe82b9d2dc3c18a74ul);
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((0x3ccc44cf8a6f3b74ul) % 64ul) | 1ul));
			ulong Input_v5 = Input_v4 | (0x8a52aa934f8880b4ul);

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x971b9a5c3c1810fdul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = v1_v2 * (0x2c3b4f47bf554ee2ul);
			ulong v1_v4 = v1_v3 + (0x8a56e876f371ec57ul);
			ulong v1_v5 = v1_v4 * (0x95719a03efabd924ul);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0x7e0c3858aa121c00ul;
			ulong v2_l_v2 = BinaryPrimitives.ReverseEndianness(v2_l_v1);
			ulong v2_l_v3 = v2_l_v2 | (0xde5fd9ed2c182ef7ul);
			ulong v2_l_v4 = Mathematics.RotateRight(v2_l_v3, (int) (((0x8f70f2fec4acbe07ul) % 64ul) | 1ul));
			ulong v2_l_v5 = ~v2_l_v4;

			ulong v2_r_v1 = 0xd907ba79c446d252ul;
			ulong v2_r_v2 = v2_r_v1 + (0x870fa5a763c1a092ul);
			ulong v2_r_v3 = Mathematics.RotateLeft(v2_r_v2, (int) (((0x3ab014fc1b503904ul) % 64ul) | 1ul));
			ulong v2_r_v4 = Mathematics.RotateRight(v2_r_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xb5abc53d889922dcul;
			ulong v3_v2 = v3_v1 ^ (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v3_v3 = v3_v2 & (Configuration.NtMajorVersion);
			ulong v3_v4 = ~v3_v3;

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x712689b36596a5deul;
			ulong v4_v2 = v4_v1 + (0xc263508263d0daa7ul);
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((0x61a7236fb1d06bf5ul) % 64ul) | 1ul));
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = v4 ^ ((v4_v5));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			ulong v6_v1 = 0x75fd8efd33ebae5dul;
			ulong v6_v2 = v6_v1 >> (int) (((0x9b621184b17a6d94ul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 | (0x5d0040e7e68969f2ul);
			ulong v6_v4 = ~v6_v3;

			ulong v7 = v6 - ((v6_v4));

			return v7;
		}

		public static ulong Mul_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x6a133ff55f590f93ul;
			ulong Input_v2 = Input_v1 + (0x776f9897466c0b7eul);
			ulong Input_v3 = Mathematics.RotateLeft(Input_v2, (int) (((0x2e6fb5d994db189cul) % 64ul) | 1ul));
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xa1296d4f5a51234eul;
			ulong v1_v2 = v1_v1 >> (int) (((0xf34ff235985ec482ul) % 64ul) | 1ul);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 & (0xeab6f297ef5054aful);
			ulong v1_v5 = v1_v4 | (0xfd3ad15fa6824c6dul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v1_v5 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0xbfbbe83d95334df5ul;
			ulong v2_l_v2 = v2_l_v1 - (Configuration.NtMajorVersion);
			ulong v2_l_v3 = v2_l_v2 + (0x7095fa9230c2b704ul);
			ulong v2_l_v4 = v2_l_v3 - (0x88e25d2ab67a0c40ul);
			ulong v2_l_v5 = v2_l_v4 + (Configuration.CpuBrandString1[1] & 0xffffffff);

			ulong v2_r_v1 = 0x56016f15deadfbaful;
			ulong v2_r_v2 = v2_r_v1 + (0x5928f4bb8a1258a4ul);
			ulong v2_r_v3 = v2_r_v2 & (0xc2d14f38f5e25ff9ul);
			ulong v2_r_v4 = v2_r_v3 ^ (Configuration.CpuBrandString1[1] & 0xffffffff);

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xfaf1b9346f582951ul;
			ulong v3_v2 = v3_v1 - (0x7167bc6f57c21c66ul);
			ulong v3_v3 = v3_v2 ^ (0x5100ab61c2eeb195ul);
			ulong v3_v4 = BinaryPrimitives.ReverseEndianness(v3_v3);
			ulong v3_v5 = v3_v4 ^ (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v4 = v3 - ((v3_v5));

			ulong v4_l_v1 = 0xfb0f7bd6bdc0f645ul;
			ulong v4_l_v2 = v4_l_v1 << (int) (((0x457b86856b9e881cul) % 64ul) | 1ul);
			ulong v4_l_v3 = ~v4_l_v2;
			ulong v4_l_v4 = BinaryPrimitives.ReverseEndianness(v4_l_v3);
			ulong v4_l_v5 = v4_l_v4 ^ (0x8cbe727fe4549ef6ul);

			ulong v4_r_v1 = 0x15f6f501592f33a5ul;
			ulong v4_r_v2 = v4_r_v1 << (int) (((0x52026162601e4fbaul) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 ^ (0x9f7fb7bcc1303939ul);
			ulong v4_r_v4 = v4_r_v3 + (0x4016535886fd543ful);
			ulong v4_r_v5 = v4_r_v4 >> (int) (((0x28aac5b7b79057fcul) % 64ul) | 1ul);

			ulong v5 = Mathematics.InverseRotationLeftLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0x43186f442b96c789ul;
			ulong v5_v2 = v5_v1 - (0xe191c93828417b3ful);
			ulong v5_v3 = BinaryPrimitives.ReverseEndianness(v5_v2);
			ulong v5_v4 = Mathematics.RotateLeft(v5_v3, (int) (((0x639c445aaa25e8a3ul) % 64ul) | 1ul));
			ulong v5_v5 = BinaryPrimitives.ReverseEndianness(v5_v4);

			ulong v6 = v5 + ((v5_v5));

			return v6;
		}

		public static ulong Mul_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x86db58a80041657dul;
			ulong Input_v2 = ~Input_v1;
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_v1 = 0xb4fe1bc2feb2b61ful;
			ulong v1_v2 = v1_v1 & (0x1935a28244691206ul);
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 ^ (0xe68b325852a933edul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_l_v1 = 0x43aeb5c1306b82b7ul;
			ulong v2_l_v2 = v2_l_v1 ^ (0xf9ca6d74619e8332ul);
			ulong v2_l_v3 = Mathematics.RotateRight(v2_l_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 * (Configuration.NtMajorVersion);
			ulong v2_l_v5 = Mathematics.RotateLeft(v2_l_v4, (int) (((0xaffcd0a6500e174dul) % 64ul) | 1ul));

			ulong v2_r_v1 = 0x45070596c08f8efbul;
			ulong v2_r_v2 = v2_r_v1 * (0x47958fba78b20a20ul);
			ulong v2_r_v3 = v2_r_v2 - (0x2cf89c7eb99e1a88ul);
			ulong v2_r_v4 = v2_r_v3 & (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x96371a597d3a744bul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = v3_v2 - (0x8d7a46cf0b4e31c1ul);
			ulong v3_v4 = v3_v3 + (0xc0bb6d5566bd1be3ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x520c084abab97387ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x67b6a242fc937519ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 - (0x1d15c70243121fbul);
			ulong v4_v4 = v4_v3 | (0xeee55c1cd62e13ful);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x70158598f49ba14aul;
			ulong v5_l_v2 = BinaryPrimitives.ReverseEndianness(v5_l_v1);
			ulong v5_l_v3 = v5_l_v2 | (0x53f71a32adaaca93ul);
			ulong v5_l_v4 = v5_l_v3 * (0x8987e9e1659590eul);

			ulong v5_r_v1 = 0x2d9781b2d86fb308ul;
			ulong v5_r_v2 = v5_r_v1 + (0x3b69c1ef6ab0622bul);
			ulong v5_r_v3 = v5_r_v2 * (0x4cd57b45dd13c4b7ul);
			ulong v5_r_v4 = v5_r_v3 >> (int) (((0x8c115ad61ddf3ed2ul) % 64ul) | 1ul);
			ulong v5_r_v5 = Mathematics.RotateLeft(v5_r_v4, (int) (((0x4bcb091365a3065eul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Mul_5_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_v1 = 0xef089cd59d0a03dcul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x219b91e96cbb6f0ful) % 64ul) | 1ul));
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 << (int) (((0x38783a7759c87f2bul) % 64ul) | 1ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xad3416171ac2d06dul;
			ulong v2_l_v2 = v2_l_v1 & (0x46131aee67ea035cul);
			ulong v2_l_v3 = Mathematics.RotateRight(v2_l_v2, (int) (((0x25a83d619649f4f7ul) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 ^ (0xf1dfe8fb4189e98ul);
			ulong v2_l_v5 = v2_l_v4 >> (int) (((0x4ead6eac30b30829ul) % 64ul) | 1ul);

			ulong v2_r_v1 = 0x6ed10aed4cad4156ul;
			ulong v2_r_v2 = ~v2_r_v1;
			ulong v2_r_v3 = v2_r_v2 << (int) (((0x3ea0e34bf76efffdul) % 64ul) | 1ul);
			ulong v2_r_v4 = v2_r_v3 - (0x26bd2e69f6138443ul);
			ulong v2_r_v5 = v2_r_v4 << (int) (((0xbae802a6fd5b83e0ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x5be0898c35be05ddul;
			ulong v3_v2 = v3_v1 - (0x1f534f8cb55d958aul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 - (0x482392cd21965d1bul);
			ulong v3_v5 = ~v3_v4;

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x61801b074a26b7f1ul;
			ulong v4_l_v2 = v4_l_v1 >> (int) (((0xc69d199c720d8ca3ul) % 64ul) | 1ul);
			ulong v4_l_v3 = v4_l_v2 & (0xb05f6fe8fe46abd2ul);
			ulong v4_l_v4 = v4_l_v3 - (Configuration.CpuBrandString1[2] & 0xffffffff);

			ulong v4_r_v1 = 0x6f68c29b38b4eebbul;
			ulong v4_r_v2 = ~v4_r_v1;
			ulong v4_r_v3 = v4_r_v2 << (int) (((0x936a9c08e1cee99bul) % 64ul) | 1ul);
			ulong v4_r_v4 = v4_r_v3 & (0x315f7c87b1a3a34cul);
			ulong v4_r_v5 = v4_r_v4 * (0x3a4dbbfb79fd87a9ul);

			ulong v5 = Mathematics.InverseRotationRightLeft(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Mul_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x12042227079597ecul;
			ulong Input_l_v2 = Input_l_v1 ^ (0x8b3f0cc75547f00cul);
			ulong Input_l_v3 = Input_l_v2 >> (int) (((0x6f917e793d97725ful) % 64ul) | 1ul);
			ulong Input_l_v4 = Mathematics.RotateRight(Input_l_v3, (int) (((0x4738caf5af38c2b4ul) % 64ul) | 1ul));

			ulong Input_r_v1 = 0x22bb385385ab2e52ul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = Input_r_v2 | (0xec6d021d430ca577ul);
			ulong Input_r_v4 = Input_r_v3 >> (int) (((0xb19bbdf8904511b5ul) % 64ul) | 1ul);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));

			ulong v2 = ~v1;

			ulong v2_v1 = 0xecd3740967b7c8f2ul;
			ulong v2_v2 = v2_v1 + (0x855140549b700b4ful);
			ulong v2_v3 = Mathematics.RotateLeft(v2_v2, (int) (((0xe1aca7caa292594aul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 & (0x3143d1126664daceul);
			ulong v2_v5 = v2_v4 - (0x9f7e59e86b7d5d60ul);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x4775dfc9e714b1e2ul;
			ulong v3_v2 = v3_v1 - (0x6b65b1b234d8965dul);
			ulong v3_v3 = v3_v2 ^ (0x737afaaece4b4cdul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((0x4bde2419be2948baul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseShiftRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x7c624ba9a560e7cul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0xae74ceddc9c10050ul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 * (0x171ac429a84a7202ul);
			ulong v4_v4 = ~v4_v3;

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Mul_7_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x7182f58928b94a18ul;
			ulong Input_l_v2 = Input_l_v1 - (0xda8ef4ef58e47bfeul);
			ulong Input_l_v3 = Input_l_v2 ^ (0x2a36881404d8b82dul);
			ulong Input_l_v4 = BinaryPrimitives.ReverseEndianness(Input_l_v3);
			ulong Input_l_v5 = Input_l_v4 >> (int) (((0x5ad4d225daa48032ul) % 64ul) | 1ul);

			ulong Input_r_v1 = 0x3f47352d28cfe99eul;
			ulong Input_r_v2 = Input_r_v1 + (Configuration.NtMinorVersion);
			ulong Input_r_v3 = Input_r_v2 << (int) (((0x292b5ba96abbb888ul) % 64ul) | 1ul);
			ulong Input_r_v4 = Mathematics.RotateLeft(Input_r_v3, (int) (((0x30ce77d8f9bbcd92ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x990598aa400b716ul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = v1_v2 & (0x619c7ae60ca0a271ul);
			ulong v1_v4 = v1_v3 + (0x36c5e90569762d5dul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xdf6c80b5ce5e14dul;
			ulong v2_v2 = v2_v1 + (Configuration.NtMinorVersion);
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);
			ulong v2_v5 = v2_v4 | (0x4ca48456ccbae8c1ul);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x3ac2af86335fe358ul;
			ulong v3_v2 = v3_v1 & (0x70a7b1e2dde5b8f2ul);
			ulong v3_v3 = ~v3_v2;
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v3_v5 = v3_v4 | (0xda30be34e760913ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v5 | 1ul)));


			ulong v5 = ~v4;

			ulong v5_l_v1 = 0x8e8e5e197b6bc943ul;
			ulong v5_l_v2 = v5_l_v1 | (0x5620df396e256da1ul);
			ulong v5_l_v3 = v5_l_v2 ^ (0x295942a2e63bfa1eul);
			ulong v5_l_v4 = BinaryPrimitives.ReverseEndianness(v5_l_v3);

			ulong v5_r_v1 = 0xf5b9fc7b83746616ul;
			ulong v5_r_v2 = BinaryPrimitives.ReverseEndianness(v5_r_v1);
			ulong v5_r_v3 = v5_r_v2 | (0xe741dddd5c274c93ul);
			ulong v5_r_v4 = Mathematics.RotateRight(v5_r_v3, (int) (((0xc5754b56926f4e45ul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseRotationLeftRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Xor_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x8e6b6d9a99e27115ul;
			ulong Input_v2 = Input_v1 & (0x6202de5f0a41efb3ul);
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Input_v3 | (0xdee7d780cd458526ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x2568d440e847e88ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = v1_l_v2 ^ (0x425492ab8c49e22dul);
			ulong v1_l_v4 = v1_l_v3 | (0xd9105ef4690a4c13ul);
			ulong v1_l_v5 = v1_l_v4 + (0x89e7b559af51a504ul);

			ulong v1_r_v1 = 0x5c58f930135e0b26ul;
			ulong v1_r_v2 = ~v1_r_v1;
			ulong v1_r_v3 = v1_r_v2 - (0xc3a9bd67425e59dbul);
			ulong v1_r_v4 = ~v1_r_v3;
			ulong v1_r_v5 = v1_r_v4 * (Configuration.NtMinorVersion);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xd4d8e3785f375874ul;
			ulong v2_v2 = v2_v1 ^ (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 ^ (0x68744df06135683bul);
			ulong v2_v5 = v2_v4 * (0x215caedb8dd696ccul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v5 | 1ul)));

			ulong v3_v1 = 0x2d9397d3077b3ebaul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0x2a902ddecb1c2ce1ul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 - (Configuration.NtMajorVersion);
			ulong v3_v4 = v3_v3 | (0x46f0492c51ebb085ul);
			ulong v3_v5 = Mathematics.RotateLeft(v3_v4, (int) (((0x967f98f026ca897eul) % 64ul) | 1ul));

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0xafbe33877b7c1a80ul;
			ulong v4_v2 = v4_v1 >> (int) (((0xbc8dc00cf7846c44ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 ^ (0xecf1b6ef57dfc874ul);
			ulong v4_v4 = v4_v3 - (0xb7c6737b8c46dd78ul);
			ulong v4_v5 = Mathematics.RotateLeft(v4_v4, (int) (((0x138bbb0b54b47655ul) % 64ul) | 1ul));

			ulong v5 = v4 + ((v4_v5));

			return v5;
		}

		public static ulong Xor_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xa3558b7fece9051ful;
			ulong Input_v2 = Input_v1 << (int) (((0x5e231b176fe6d918ul) % 64ul) | 1ul);
			ulong Input_v3 = Input_v2 | (0x5e0f3c392957a241ul);
			ulong Input_v4 = Input_v3 << (int) (((0x77264dc80883a3c2ul) % 64ul) | 1ul);
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0xcbc248c8b6d1f018ul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 | (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v1_v4 = v1_v3 * (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x76ea85891f2eb71ful;
			ulong v2_v2 = BinaryPrimitives.ReverseEndianness(v2_v1);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 | (0x64fc9934ef150abful);

			ulong v3 = v2 ^ ((v2_v4));

			ulong v3_v1 = 0x633c124cf9d39a63ul;
			ulong v3_v2 = v3_v1 + (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v3_v3 = v3_v2 | (0xcc9ef82c65ceca03ul);
			ulong v3_v4 = v3_v3 >> (int) (((0x351d5cfa473b6f78ul) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 ^ (Configuration.CpuBrandString3[0] & 0xffffffff);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x75441fdafe418e4ul;
			ulong v4_v2 = v4_v1 | (0xd24b0f48e6eb57eul);
			ulong v4_v3 = v4_v2 * (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v4_v4 = v4_v3 << (int) (((0xbc2e539281dcee43ul) % 64ul) | 1ul);
			ulong v4_v5 = v4_v4 * (0x30023986185f41c2ul);

			ulong v5 = v4 - ((v4_v5));

			ulong v5_l_v1 = 0x73951feac3f5a6a1ul;
			ulong v5_l_v2 = v5_l_v1 | (0x7eccd63eb028f90bul);
			ulong v5_l_v3 = BinaryPrimitives.ReverseEndianness(v5_l_v2);
			ulong v5_l_v4 = v5_l_v3 << (int) (((0x5a387b76e29c16c6ul) % 64ul) | 1ul);
			ulong v5_l_v5 = Mathematics.RotateLeft(v5_l_v4, (int) (((0x7c0c4b50bfd14a45ul) % 64ul) | 1ul));

			ulong v5_r_v1 = 0xcf63d8f3189b96bcul;
			ulong v5_r_v2 = v5_r_v1 * (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v5_r_v3 = v5_r_v2 >> (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v5_r_v4 = ~v5_r_v3;

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0xd3ccfe7c4c96a404ul;
			ulong v6_l_v2 = v6_l_v1 + (0x93ee88c4186aa867ul);
			ulong v6_l_v3 = v6_l_v2 ^ (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v6_l_v4 = BinaryPrimitives.ReverseEndianness(v6_l_v3);

			ulong v6_r_v1 = 0x47f70660d52538bul;
			ulong v6_r_v2 = v6_r_v1 + (0x5e5187826dded420ul);
			ulong v6_r_v3 = Mathematics.RotateRight(v6_r_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v6_r_v4 = Mathematics.RotateLeft(v6_r_v3, (int) (((0xd342a943901acbd7ul) % 64ul) | 1ul));

			ulong v7 = Mathematics.InverseRotationRightRight(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Xor_2_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_v1 = 0xac81a390ed33800bul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x62eac067a5fe96deul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 - (0x912bbc3f7737c0bcul);
			ulong v1_v4 = ~v1_v3;
			ulong v1_v5 = v1_v4 - (Configuration.CpuBrandString2[0] & 0xffffffff);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xd8d41122fef68edaul;
			ulong v2_l_v2 = ~v2_l_v1;
			ulong v2_l_v3 = v2_l_v2 ^ (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v2_l_v4 = Mathematics.RotateLeft(v2_l_v3, (int) (((0x5d9a2d54a2e2661ul) % 64ul) | 1ul));

			ulong v2_r_v1 = 0x20f54b262d3de7d7ul;
			ulong v2_r_v2 = ~v2_r_v1;
			ulong v2_r_v3 = v2_r_v2 * (0xdf6fc43523a98c78ul);
			ulong v2_r_v4 = v2_r_v3 - (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x70581e6efb0ef0b0ul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0xf5f69dc67a4ffa84ul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 + (0x584faee8a00b7e6eul);
			ulong v3_v5 = ~v3_v4;

			ulong v4 = v3 ^ ((v3_v5));

			ulong v4_l_v1 = 0xf98571c0c9ba4346ul;
			ulong v4_l_v2 = v4_l_v1 >> (int) (((0x380eb7e44d166983ul) % 64ul) | 1ul);
			ulong v4_l_v3 = v4_l_v2 & (Configuration.NtBuildNumber);
			ulong v4_l_v4 = v4_l_v3 + (0x77739e2c70841ef8ul);
			ulong v4_l_v5 = Mathematics.RotateRight(v4_l_v4, (int) (((0xadd93e3df3bca84eul) % 64ul) | 1ul));

			ulong v4_r_v1 = 0x5ec10c0016ddc490ul;
			ulong v4_r_v2 = v4_r_v1 + (0x26a5bafa5c69e570ul);
			ulong v4_r_v3 = Mathematics.RotateRight(v4_r_v2, (int) (((0x17fbbeabfd91fb38ul) % 64ul) | 1ul));
			ulong v4_r_v4 = v4_r_v3 + (0x31bf11207e06bd35ul);

			ulong v5 = Mathematics.InverseRotationLeftLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0xffc55f1a268e764cul;
			ulong v5_l_v2 = v5_l_v1 & (0x173130774c45f391ul);
			ulong v5_l_v3 = v5_l_v2 >> (int) (((0xf2140393a6c8b99eul) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 ^ (0x46b7a861257d632bul);
			ulong v5_l_v5 = ~v5_l_v4;

			ulong v5_r_v1 = 0xa9b678ff69152c9eul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0xc094a11b03daaa7aul) % 64ul) | 1ul));
			ulong v5_r_v3 = ~v5_r_v2;
			ulong v5_r_v4 = Mathematics.RotateRight(v5_r_v3, (int) (((0xfb236214fcc8a9a8ul) % 64ul) | 1ul));
			ulong v5_r_v5 = v5_r_v4 + (0x9cfb25f8e32d17ccul);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0xbf4186982a321cd9ul;
			ulong v6_v2 = v6_v1 << (int) (((0x85a0df9e6ef95edbul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 | (0xd966a4a8ab9ea479ul);
			ulong v6_v4 = Mathematics.RotateRight(v6_v3, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));

			ulong v7 = v6 ^ ((v6_v4));

			return v7;
		}

		public static ulong Xor_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x8bff3e494671c185ul;
			ulong Input_v2 = Input_v1 ^ (0x1ea6d002bef82e69ul);
			ulong Input_v3 = Mathematics.RotateLeft(Input_v2, (int) (((0x8df4cc05ddbbcc4ful) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 - (0x802dc3931f5eba23ul);
			ulong Input_v5 = Mathematics.RotateLeft(Input_v4, (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v5 | 1ul)));
			ulong v1_l_v1 = 0x67231bc3f17fa1b0ul;
			ulong v1_l_v2 = Mathematics.RotateRight(v1_l_v1, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v1_l_v3 = v1_l_v2 + (0x80ad17163cfcefdful);
			ulong v1_l_v4 = Mathematics.RotateRight(v1_l_v3, (int) (((0xaae6c65bf1a4388cul) % 64ul) | 1ul));
			ulong v1_l_v5 = v1_l_v4 ^ (0x8ee72b90b6d03ba4ul);

			ulong v1_r_v1 = 0xdda9fc6a1e0b4406ul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = v1_r_v2 << (int) (((0x7a897008b08aa110ul) % 64ul) | 1ul);
			ulong v1_r_v4 = v1_r_v3 + (0xa943f27875c26467ul);
			ulong v1_r_v5 = v1_r_v4 - (Configuration.CpuBrandString3[0] & 0xffffffff);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x5af5af30d977f093ul;
			ulong v2_v2 = v2_v1 << (int) (((0x5b4094107c7ad0daul) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 * (0xd9f342b166028d3bul);
			ulong v2_v4 = v2_v3 ^ (0x5f4937260984cee6ul);

			ulong v3 = v2 ^ ((v2_v4));

			ulong v3_v1 = 0xe64180c7069285ecul;
			ulong v3_v2 = v3_v1 ^ (0xb558ffb7c4514549ul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0x4ff1e7309689f3aul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 + (0xb9f50d5a5e25a7e2ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x88f73626d6de6ecdul;
			ulong v4_v2 = v4_v1 >> (int) (((0xde4bf8d95160b374ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 ^ (0xdb1a36efa69dbe52ul);
			ulong v4_v4 = ~v4_v3;

			ulong v5 = v4 * Mathematics.InverseMultiplication(((v4_v4 | 1ul)));

			ulong v5_v1 = 0x4651221fe84e697bul;
			ulong v5_v2 = v5_v1 * (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v5_v3 = v5_v2 << (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 >> (int) (((0x4a75acc3eba7dca6ul) % 64ul) | 1ul);

			ulong v6 = Mathematics.RotateLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0x2b867d824f03b83bul;
			ulong v6_v2 = v6_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 ^ (0x59b7bcff2ac13c4eul);
			ulong v6_v4 = ~v6_v3;
			ulong v6_v5 = v6_v4 + (0x55ae155a0f107b30ul);

			ulong v7 = v6 * Mathematics.InverseMultiplication(((v6_v5 | 1ul)));

			return v7;
		}

		public static ulong Xor_4_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_l_v1 = 0x542cb8fea78e39a5ul;
			ulong v1_l_v2 = v1_l_v1 & (0xf59d0085a3072bacul);
			ulong v1_l_v3 = v1_l_v2 * (0x190b0e7b9b795a5eul);
			ulong v1_l_v4 = v1_l_v3 & (0x4ac93f734a18530ful);
			ulong v1_l_v5 = BinaryPrimitives.ReverseEndianness(v1_l_v4);

			ulong v1_r_v1 = 0xee73d4ea2231b587ul;
			ulong v1_r_v2 = v1_r_v1 - (0xdaf729c356291e04ul);
			ulong v1_r_v3 = ~v1_r_v2;
			ulong v1_r_v4 = v1_r_v3 & (0xaea73f14ae3653b1ul);
			ulong v1_r_v5 = v1_r_v4 - (0xaf906bd11bdc2d3ful);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x6ad2d3726b4b890cul;
			ulong v2_v2 = BinaryPrimitives.ReverseEndianness(v2_v1);
			ulong v2_v3 = v2_v2 >> (int) (((0x59960f73a72e30beul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 & (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v2_v5 = v2_v4 + (0xcb646af4d8b29951ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v5 | 1ul)));

			ulong v3_v1 = 0x1ce7d5cab4a15595ul;
			ulong v3_v2 = v3_v1 ^ (0xd852326399a7b078ul);
			ulong v3_v3 = v3_v2 * (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v3_v4 % 64ul) | 1ul))));

			ulong v4_l_v1 = 0x7cbc39f1798ecd8ful;
			ulong v4_l_v2 = v4_l_v1 & (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v4_l_v3 = ~v4_l_v2;
			ulong v4_l_v4 = v4_l_v3 & (0x52783f7b98cf6966ul);
			ulong v4_l_v5 = Mathematics.RotateLeft(v4_l_v4, (int) (((0x84f63708d95f2692ul) % 64ul) | 1ul));

			ulong v4_r_v1 = 0x121937c44a29e547ul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((0x8a4586be35901f9ul) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 | (0xf2465b73b2d0ec9aul);
			ulong v4_r_v4 = BinaryPrimitives.ReverseEndianness(v4_r_v3);

			ulong v5 = Mathematics.InverseRotationRightLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x64b1852df83af2f9ul;
			ulong v5_v2 = v5_v1 ^ (0x727a185f023afa05ul);
			ulong v5_v3 = v5_v2 * (0xe702988324f5f4e0ul);
			ulong v5_v4 = v5_v3 - (Configuration.NtMinorVersion);
			ulong v5_v5 = v5_v4 >> (int) (((0x17d05ced5949c741ul) % 64ul) | 1ul);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0x4df1980bf3094ee4ul;
			ulong v6_v2 = v6_v1 * (0x49e613e72e915bbaul);
			ulong v6_v3 = v6_v2 ^ (0x5b63d6fcd7be5013ul);
			ulong v6_v4 = BinaryPrimitives.ReverseEndianness(v6_v3);

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			return v7;
		}

		public static ulong Xor_5_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = ~Input;
			ulong v1_v1 = 0x7ed0c1bea1d409a6ul;
			ulong v1_v2 = v1_v1 ^ (0x129ea79f59ec02c8ul);
			ulong v1_v3 = v1_v2 << (int) (((0x403317e2643674d0ul) % 64ul) | 1ul);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x9c01bbef8fea8689ul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 * (0xc79242d7254c16e1ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xbe1c9136bef1e6c2ul;
			ulong v2_v2 = v2_v1 ^ (0xd161944a0da2ba0aul);
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 ^ (0x1d39b8c20a1d2017ul);
			ulong v2_v5 = ~v2_v4;

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_v1 = 0xd63bb276c7fb2caaul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 + (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v3_v4 = v3_v3 | (0x37360d6295f4886dul);
			ulong v3_v5 = v3_v4 + (0x87b1c7101f71037bul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xa6ea8e96eed3ff54ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x791a593757292247ul) % 64ul) | 1ul);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((0x944e1332accfd492ul) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x4ccc42868db75c87ul;
			ulong v5_l_v2 = v5_l_v1 << (int) (((0xd146f3ddab646ce0ul) % 64ul) | 1ul);
			ulong v5_l_v3 = ~v5_l_v2;
			ulong v5_l_v4 = v5_l_v3 & (0x58150bdc36748dfbul);

			ulong v5_r_v1 = 0x1c157ae46847a47dul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0xd1ca7825573ec338ul) % 64ul) | 1ul));
			ulong v5_r_v3 = v5_r_v2 - (0x7bc160f6907b87d0ul);
			ulong v5_r_v4 = v5_r_v3 | (0x1b27293eac310860ul);
			ulong v5_r_v5 = v5_r_v4 * (0x87ee70e46baec6cul);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Xor_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x12d146de80ef3582ul;
			ulong Input_v2 = Mathematics.RotateLeft(Input_v1, (int) (((0x6c9b57e0a554f28eul) % 64ul) | 1ul));
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Input_v3 << (int) (((0x2f1101781499d97ul) % 64ul) | 1ul);
			ulong Input_v5 = Input_v4 ^ (0xf513e4b36edb727ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v5 | 1ul)));
			ulong v1_v1 = 0x1499cd086be5dbc2ul;
			ulong v1_v2 = BinaryPrimitives.ReverseEndianness(v1_v1);
			ulong v1_v3 = v1_v2 << (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 | (0xf4b82785b98aa01aul);

			ulong v2 = v1 ^ ((v1_v4));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_v1 = 0x428a1ce8a16fb3d8ul;
			ulong v3_v2 = Mathematics.RotateRight(v3_v1, (int) (((0xc079af1fa61c9c52ul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 + (0x24ad5ddc9289405eul);
			ulong v3_v4 = v3_v3 ^ (0xb38325f1b3b4a94eul);
			ulong v3_v5 = Mathematics.RotateLeft(v3_v4, (int) (((0x2ddc68e7bda9d155ul) % 64ul) | 1ul));

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xc99a42cedf3a9c38ul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 >> (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Rol_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x16e5600f2d1ab451ul;
			ulong Input_l_v2 = Input_l_v1 + (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong Input_l_v3 = Mathematics.RotateRight(Input_l_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong Input_l_v4 = Input_l_v3 - (0x3ca5cdd5b4fba8a8ul);
			ulong Input_l_v5 = Input_l_v4 & (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong Input_r_v1 = 0xdf62430376643130ul;
			ulong Input_r_v2 = Input_r_v1 & (0x2fb8cbceff9b8de4ul);
			ulong Input_r_v3 = Input_r_v2 - (0x4d63ca2c31019cd3ul);
			ulong Input_r_v4 = Input_r_v3 * (0x975674175afc82d1ul);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xd6da1158712cf7adul;
			ulong v1_l_v2 = v1_l_v1 | (0xd898311d4dd9ab92ul);
			ulong v1_l_v3 = v1_l_v2 ^ (Configuration.NtMinorVersion);
			ulong v1_l_v4 = ~v1_l_v3;
			ulong v1_l_v5 = v1_l_v4 << (int) (((0x4eca2795dffa08ceul) % 64ul) | 1ul);

			ulong v1_r_v1 = 0xde0b369112ff31a1ul;
			ulong v1_r_v2 = v1_r_v1 | (0x124ec1dc7c133968ul);
			ulong v1_r_v3 = v1_r_v2 - (Configuration.CpuBrandString3[3] & 0xffffffff);
			ulong v1_r_v4 = v1_r_v3 & (0xe09434eafa629733ul);
			ulong v1_r_v5 = Mathematics.RotateLeft(v1_r_v4, (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x6de061b50977ea68ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 - (0x8cc54a7beac4591ful);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0x3763c77f5de1bd58ul) % 64ul) | 1ul));

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v4 | 1ul)));

			ulong v3_l_v1 = 0xcd3b04fab2f96cc9ul;
			ulong v3_l_v2 = v3_l_v1 | (0xf6023f0d76851ceul);
			ulong v3_l_v3 = v3_l_v2 & (0xb37a1f07f2551305ul);
			ulong v3_l_v4 = v3_l_v3 + (Configuration.NtBuildNumber);

			ulong v3_r_v1 = 0xc2e768a58903087ful;
			ulong v3_r_v2 = v3_r_v1 * (0x2f2352f183e867ebul);
			ulong v3_r_v3 = v3_r_v2 - (0x999dc92b5f97834aul);
			ulong v3_r_v4 = v3_r_v3 ^ (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xc58f214ed1f3b932ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 & (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);
			ulong v4_v5 = ~v4_v4;

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0xfc24dc78f4ed2cf5ul;
			ulong v5_l_v2 = v5_l_v1 ^ (0xe3d50e083d214373ul);
			ulong v5_l_v3 = ~v5_l_v2;
			ulong v5_l_v4 = v5_l_v3 << (int) (((0x15d85b0e89e4fa0cul) % 64ul) | 1ul);
			ulong v5_l_v5 = v5_l_v4 & (0xbeea67d5966be3ful);

			ulong v5_r_v1 = 0x7c8f25bc92ea141eul;
			ulong v5_r_v2 = v5_r_v1 - (0xa378e1e81de56688ul);
			ulong v5_r_v3 = Mathematics.RotateLeft(v5_r_v2, (int) (((0xd13a50c3ad49f867ul) % 64ul) | 1ul));
			ulong v5_r_v4 = v5_r_v3 & (Configuration.CpuBrandString1[2] & 0xffffffff);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Rol_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xc12fc605bb048a78ul;
			ulong Input_v2 = ~Input_v1;
			ulong Input_v3 = Mathematics.RotateLeft(Input_v2, (int) (((0xe708464dc64a3f93ul) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 ^ (0x85baf408c9c70004ul);
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v5 | 1ul)));
			ulong v1_l_v1 = 0x6f35d1d74d9bc432ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = BinaryPrimitives.ReverseEndianness(v1_l_v2);
			ulong v1_l_v4 = ~v1_l_v3;
			ulong v1_l_v5 = v1_l_v4 ^ (0xe0d566dd61fcb4d3ul);

			ulong v1_r_v1 = 0x63a4a03f55b7780ful;
			ulong v1_r_v2 = v1_r_v1 & (0x3089b51f3d6840bful);
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0x9d4f897ffa69033aul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 >> (int) (((0x55be5a54c85f1511ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x1bd388e3f42f8d5ful;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = ~v2_v3;
			ulong v2_v5 = v2_v4 + (0x988daaabf37cd501ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v5 | 1ul)));

			ulong v3_v1 = 0x5504ebe2d31f1528ul;
			ulong v3_v2 = v3_v1 | (0xf473c07c49bc16a0ul);
			ulong v3_v3 = v3_v2 - (0xe14157cf7525f840ul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v3_v5 = v3_v4 << (int) (((0x5212358b0a8a8d7ful) % 64ul) | 1ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xc251df76412ff9d5ul;
			ulong v4_v2 = v4_v1 * (0x3ad6a0e9c5cf21e1ul);
			ulong v4_v3 = v4_v2 >> (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 | (0x5fa6696f7a319177ul);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x33805586746b4413ul;
			ulong v5_l_v2 = v5_l_v1 ^ (0x276798687adc9588ul);
			ulong v5_l_v3 = v5_l_v2 >> (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 ^ (0x8e76b7d68c01877cul);

			ulong v5_r_v1 = 0x182e928e7bfe7939ul;
			ulong v5_r_v2 = v5_r_v1 >> (int) (((0xbecb710f91a0ef8ul) % 64ul) | 1ul);
			ulong v5_r_v3 = v5_r_v2 | (0xddaa4c12e382e37ful);
			ulong v5_r_v4 = Mathematics.RotateLeft(v5_r_v3, (int) (((0xf299f0be348af083ul) % 64ul) | 1ul));
			ulong v5_r_v5 = v5_r_v4 ^ (0x7922430473d49accul);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Rol_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x71a9a289296d2b6dul;
			ulong Input_v2 = Input_v1 & (0xb49d2c3d57a8783ul);
			ulong Input_v3 = Mathematics.RotateLeft(Input_v2, (int) (((0xfc49b08921182e73ul) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 * (0x6f3213cced5e8f8cul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));

			ulong v2 = ~v1;

			ulong v2_l_v1 = 0x81dd41e9fb1056ddul;
			ulong v2_l_v2 = v2_l_v1 << (int) (((0xfaf4df26edb6037bul) % 64ul) | 1ul);
			ulong v2_l_v3 = v2_l_v2 | (0x92bf8f0f1e687c4ul);
			ulong v2_l_v4 = v2_l_v3 & (0xf3e9ab2f85b987eful);

			ulong v2_r_v1 = 0xc6b0e293c877ced2ul;
			ulong v2_r_v2 = v2_r_v1 + (0x19fca1fc4229ddbdul);
			ulong v2_r_v3 = v2_r_v2 ^ (0x45ab2418e186b529ul);
			ulong v2_r_v4 = v2_r_v3 | (0xa1abbe2e5c0e185cul);
			ulong v2_r_v5 = v2_r_v4 >> (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x3c5df8b407421fb8ul;
			ulong v3_v2 = v3_v1 * (0xc16057c353520b6ul);
			ulong v3_v3 = v3_v2 + (0x65f245d27f52c1bcul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((0x980f7e0ea21109acul) % 64ul) | 1ul));

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v4 | 1ul)));

			ulong v4_l_v1 = 0x4a0d87a564aa43a0ul;
			ulong v4_l_v2 = Mathematics.RotateRight(v4_l_v1, (int) (((0x993ae180014fb73ul) % 64ul) | 1ul));
			ulong v4_l_v3 = v4_l_v2 - (0x50952ccef1abbaabul);
			ulong v4_l_v4 = v4_l_v3 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);

			ulong v4_r_v1 = 0xa81615883bacca42ul;
			ulong v4_r_v2 = v4_r_v1 & (0x9145e5fd321e6fc5ul);
			ulong v4_r_v3 = v4_r_v2 ^ (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v4_r_v4 = v4_r_v3 & (0x8841104dbe9a4d9cul);

			ulong v5 = Mathematics.InverseRotationRightRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0xf14a3a0e429d7c60ul;
			ulong v5_v2 = v5_v1 + (0x8d6aa3a8816b0e69ul);
			ulong v5_v3 = ~v5_v2;
			ulong v5_v4 = v5_v3 | (Configuration.CpuBrandString3[2] & 0xffffffff);

			ulong v6 = v5 ^ ((v5_v4));

			return v6;
		}

		public static ulong Rol_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xe803b632332370d6ul;
			ulong Input_l_v2 = Input_l_v1 | (0x8b3812977201aa93ul);
			ulong Input_l_v3 = Input_l_v2 + (0x554a37b7114324c5ul);
			ulong Input_l_v4 = Mathematics.RotateRight(Input_l_v3, (int) (((0xfca9280b9cfa0797ul) % 64ul) | 1ul));
			ulong Input_l_v5 = Input_l_v4 ^ (0xe4db80de20a5dcdul);

			ulong Input_r_v1 = 0x35f3d51031af88eaul;
			ulong Input_r_v2 = BinaryPrimitives.ReverseEndianness(Input_r_v1);
			ulong Input_r_v3 = Input_r_v2 + (Configuration.NtBuildNumber);
			ulong Input_r_v4 = Input_r_v3 - (0xcd21d811291890d4ul);
			ulong Input_r_v5 = Mathematics.RotateLeft(Input_r_v4, (int) (((0xa3076a2fa5352331ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x3f062744b2815bfaul;
			ulong v1_v2 = v1_v1 >> (int) (((0xb1eff42463e33efdul) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 + (0x489d34c3de7b1ecful);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x19dfeec7492304bdul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 >> (int) (((0x88900804c575f558ul) % 64ul) | 1ul);

			ulong v2 = v1 ^ ((v1_v5));

			ulong v2_v1 = 0x2271312db5bb0e7ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((0x584b06d52358175ul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 >> (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x78eb4b182c0405cful;
			ulong v3_v2 = v3_v1 | (0x87c12293358e932aul);
			ulong v3_v3 = v3_v2 & (0xc69eaf8496b9947bul);
			ulong v3_v4 = v3_v3 >> (int) (((0x65b71d6c99900449ul) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 + (0xb3c0f4ed7de8bf98ul);

			ulong v4 = v3 + ((v3_v5));

			ulong v4_v1 = 0x628d2739f59a9bb0ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x6fac466604cb4eb5ul) % 64ul) | 1ul);
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((0xa7503d772e4a8c4cul) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 << (int) (((0xf99588cc0643cf7dul) % 64ul) | 1ul);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			return v6;
		}

		public static ulong Rol_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xcf127492db688978ul;
			ulong Input_v2 = Input_v1 & (0xb34ee769d369f68cul);
			ulong Input_v3 = Input_v2 - (0xbbf6df9d5d8b3296ul);
			ulong Input_v4 = Input_v3 | (Configuration.CpuBrandString3[3] & 0xffffffff);
			ulong Input_v5 = Input_v4 << (int) (((0xa9743b9b166fb3c2ul) % 64ul) | 1ul);

			ulong v1 = Input ^ ((Input_v5));
			ulong v1_v1 = 0x183353bdebe220feul;
			ulong v1_v2 = v1_v1 * (0x191e9ca9a0ed6d08ul);
			ulong v1_v3 = v1_v2 ^ (Configuration.NtBuildNumber);
			ulong v1_v4 = v1_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 | (0x58e4cf14a84813b7ul);

			ulong v2 = v1 + ((v1_v5));

			ulong v2_v1 = 0x45bad6256f6ec656ul;
			ulong v2_v2 = v2_v1 | (0x8d4d0b911adfb7a7ul);
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((0x69dd046289c29d69ul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 + (0xa8d26e75d6b63f0cul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v4 | 1ul)));

			ulong v3_v1 = 0x750df9867ed5969bul;
			ulong v3_v2 = v3_v1 - (0x9b2e2a9ead57e2e0ul);
			ulong v3_v3 = v3_v2 + (0x965936462146b4c4ul);
			ulong v3_v4 = BinaryPrimitives.ReverseEndianness(v3_v3);
			ulong v3_v5 = v3_v4 - (Configuration.CpuBrandString3[3] & 0xffffffff);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x6651ea71020df391ul;
			ulong v4_l_v2 = v4_l_v1 ^ (0x435b0471e522b81aul);
			ulong v4_l_v3 = v4_l_v2 - (0x1b49aabeeeab6a8aul);
			ulong v4_l_v4 = Mathematics.RotateLeft(v4_l_v3, (int) (((0x21549c385b4e6c2ful) % 64ul) | 1ul));
			ulong v4_l_v5 = v4_l_v4 & (0x15e819a1dbf2b3deul);

			ulong v4_r_v1 = 0x8a7062bad386afd5ul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((0x4740dcf97f45e6c0ul) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 * (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v4_r_v4 = v4_r_v3 | (0xaaf15a3da2262beful);

			ulong v5 = Mathematics.InverseRotationRightRight(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0xc2ced610de484ae9ul;
			ulong v5_l_v2 = v5_l_v1 * (0xd661f3a11ab6fbd4ul);
			ulong v5_l_v3 = v5_l_v2 << (int) (((0xe02f2fad2ee66d8ful) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v5_l_v5 = v5_l_v4 + (0x68bd746a377be7d9ul);

			ulong v5_r_v1 = 0x234b0d28e7aa5c03ul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0x6fc6e00da79067a2ul) % 64ul) | 1ul));
			ulong v5_r_v3 = v5_r_v2 ^ (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v5_r_v4 = ~v5_r_v3;
			ulong v5_r_v5 = v5_r_v4 ^ (0x78b93e2f851c0d2ful);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0x8c02872b4ef66b87ul;
			ulong v6_v2 = v6_v1 & (0x18729a1e0af6373eul);
			ulong v6_v3 = v6_v2 | (0xf4e617c31459231ful);
			ulong v6_v4 = BinaryPrimitives.ReverseEndianness(v6_v3);
			ulong v6_v5 = v6_v4 & (0x65ae98a22a47651dul);

			ulong v7 = Mathematics.InverseShiftLeft(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			ulong v7_v1 = 0x3a26ccae31d28f48ul;
			ulong v7_v2 = v7_v1 - (0xcb34b5b8ad2d84feul);
			ulong v7_v3 = v7_v2 | (0xf5adb35646e6381dul);
			ulong v7_v4 = v7_v3 << (int) (((0xaf3e40f3ac0ab38dul) % 64ul) | 1ul);
			ulong v7_v5 = v7_v4 ^ (0x525d15ea41b814ful);

			ulong v8 = v7 * Mathematics.InverseMultiplication(((v7_v5 | 1ul)));

			return v8;
		}

		public static ulong Rol_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x9af4b6944a370481ul;
			ulong Input_v2 = Mathematics.RotateLeft(Input_v1, (int) (((0x5ccc1efb67bddf54ul) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 * (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong Input_v4 = Input_v3 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v4 | 1ul)));
			ulong v1_v1 = 0x3db213a132159183ul;
			ulong v1_v2 = BinaryPrimitives.ReverseEndianness(v1_v1);
			ulong v1_v3 = Mathematics.RotateLeft(v1_v2, (int) (((0x4fc76b378e53df2bul) % 64ul) | 1ul));
			ulong v1_v4 = ~v1_v3;
			ulong v1_v5 = v1_v4 >> (int) (((0x39b71a7b3865aa32ul) % 64ul) | 1ul);

			ulong v2 = v1 ^ ((v1_v5));

			ulong v2_v1 = 0xa50046e71a9877bcul;
			ulong v2_v2 = v2_v1 * (0xa0f3ba9440aa8302ul);
			ulong v2_v3 = v2_v2 ^ (0x987a35ee21c5474ful);
			ulong v2_v4 = ~v2_v3;
			ulong v2_v5 = v2_v4 >> (int) (((0xd1c8c79b3da44ffbul) % 64ul) | 1ul);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0x209de92e76119726ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 + (0x67f833bbf06ee6eaul);
			ulong v3_v4 = v3_v3 << (int) (((0xdda7c4de6a9b330aul) % 64ul) | 1ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v4 % 64ul) | 1ul))));

			ulong v4_v1 = 0xaa834cec67911f26ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x3ee9e104bf3cf2ful) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 << (int) (((0x5cb6f66531d355b6ul) % 64ul) | 1ul);
			ulong v4_v4 = ~v4_v3;

			ulong v5 = v4 ^ ((v4_v4));

			ulong v5_v1 = 0xfa8f1a6d9175ac2aul;
			ulong v5_v2 = v5_v1 & (0x6f3080ce553ff51dul);
			ulong v5_v3 = v5_v2 >> (int) (((0x8b80758d6e0ddb7ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 ^ (0x6514683a78184857ul);

			ulong v6 = Mathematics.RotateLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0x7e5cb037a4fd5481ul;
			ulong v6_v2 = Mathematics.RotateLeft(v6_v1, (int) (((0x6467012ea5090a82ul) % 64ul) | 1ul));
			ulong v6_v3 = v6_v2 - (0x35f40cfb47776226ul);
			ulong v6_v4 = v6_v3 + (0xf363ba1b7592add3ul);
			ulong v6_v5 = v6_v4 | (0xe43d6d8103c7a8daul);

			ulong v7 = v6 - ((v6_v5));

			return v7;
		}

		public static ulong Rol_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xd1f4ecff34fb20f7ul;
			ulong Input_v2 = Input_v1 + (0xc585b2eee2f22f89ul);
			ulong Input_v3 = Input_v2 * (0xd23178ce7b35f199ul);
			ulong Input_v4 = Input_v3 | (0xfeb6ac761086a1f2ul);
			ulong Input_v5 = Mathematics.RotateRight(Input_v4, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseShiftRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xe46632e35f50ec89ul;
			ulong v1_v2 = v1_v1 ^ (0x261c738860b07806ul);
			ulong v1_v3 = v1_v2 & (0xe5dd66b29a1c99f3ul);
			ulong v1_v4 = v1_v3 + (Configuration.CpuBrandString3[0] & 0xffffffff);

			ulong v2 = v1 - ((v1_v4));

			ulong v2_v1 = 0x3969dcf600ec1fdful;
			ulong v2_v2 = v2_v1 ^ (0xb4a34cc5ca16931bul);
			ulong v2_v3 = v2_v2 | (0xfeabe4489bf9d5ebul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0xa0ecb9d9551de645ul) % 64ul) | 1ul));
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x2bd05bbb49781251ul;
			ulong v3_l_v2 = v3_l_v1 ^ (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v3_l_v3 = v3_l_v2 + (0x180e82aa96c1514bul);
			ulong v3_l_v4 = v3_l_v3 | (0x7447846682a4418aul);

			ulong v3_r_v1 = 0x7a181a1525ba4151ul;
			ulong v3_r_v2 = BinaryPrimitives.ReverseEndianness(v3_r_v1);
			ulong v3_r_v3 = v3_r_v2 << (int) (((0x9d07bf2db3405a9ful) % 64ul) | 1ul);
			ulong v3_r_v4 = Mathematics.RotateLeft(v3_r_v3, (int) (((0x63d8e12c873957eeul) % 64ul) | 1ul));
			ulong v3_r_v5 = v3_r_v4 & (0xdd66a4d8f219b6d2ul);

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0xd792604ea69dab5dul;
			ulong v4_l_v2 = ~v4_l_v1;
			ulong v4_l_v3 = v4_l_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v4_l_v4 = BinaryPrimitives.ReverseEndianness(v4_l_v3);
			ulong v4_l_v5 = v4_l_v4 ^ (0xc6adfe891593d33aul);

			ulong v4_r_v1 = 0x58e308056a078121ul;
			ulong v4_r_v2 = ~v4_r_v1;
			ulong v4_r_v3 = v4_r_v2 * (0xc0b7c473f6c97e62ul);
			ulong v4_r_v4 = v4_r_v3 >> (int) (((0xd20210e1b7b561fbul) % 64ul) | 1ul);

			ulong v5 = Mathematics.InverseRotationLeftLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x932501e2cf02550aul;
			ulong v5_v2 = v5_v1 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v5_v3 = v5_v2 - (Configuration.NtMajorVersion);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);

			ulong v6 = v5 - ((v5_v4));

			ulong v6_v1 = 0xf1469ab2c09dea22ul;
			ulong v6_v2 = BinaryPrimitives.ReverseEndianness(v6_v1);
			ulong v6_v3 = v6_v2 + (0x92935824c1fd1f82ul);
			ulong v6_v4 = v6_v3 ^ (0xe4695d752324a481ul);

			ulong v7 = Mathematics.RotateRight(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Ror_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x2483ce8a2f0a2a1dul;
			ulong Input_l_v2 = Input_l_v1 | (0xfeb479e44397aaecul);
			ulong Input_l_v3 = Input_l_v2 * (0xa5f4e54014a81f2dul);
			ulong Input_l_v4 = BinaryPrimitives.ReverseEndianness(Input_l_v3);
			ulong Input_l_v5 = Input_l_v4 + (0x6c5f0448ccdc8c9cul);

			ulong Input_r_v1 = 0x50e939973008f100ul;
			ulong Input_r_v2 = BinaryPrimitives.ReverseEndianness(Input_r_v1);
			ulong Input_r_v3 = ~Input_r_v2;
			ulong Input_r_v4 = Input_r_v3 ^ (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong Input_r_v5 = Input_r_v4 + (0x1f3abe2df160ce1ul);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x2f68a0942e114106ul;
			ulong v1_v2 = v1_v1 ^ (0xd6333ebb7cfe1ebdul);
			ulong v1_v3 = v1_v2 + (0x492d6b8d6a0b9d79ul);
			ulong v1_v4 = Mathematics.RotateLeft(v1_v3, (int) (((0x3e115b24bae618b8ul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 | (0x9ae7e5276ea149fful);

			ulong v2 = v1 + ((v1_v5));


			ulong v3 = ~v2;


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_v1 = 0xe3092e96f26adaul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 - (0x70fc6fb3592a70f9ul);
			ulong v4_v4 = v4_v3 << (int) (((0xc52b8e625a113f11ul) % 64ul) | 1ul);

			ulong v5 = v4 ^ ((v4_v4));

			ulong v5_v1 = 0x565808f821337453ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = Mathematics.RotateRight(v5_v2, (int) (((0x5820d5f6898650cful) % 64ul) | 1ul));
			ulong v5_v4 = v5_v3 & (0xe50ba1a58fdb55d2ul);
			ulong v5_v5 = ~v5_v4;

			ulong v6 = v5 * Mathematics.InverseMultiplication(((v5_v5 | 1ul)));

			ulong v6_v1 = 0x2aef6b10a16402bul;
			ulong v6_v2 = v6_v1 >> (int) (((0x7feccc0b6896caf2ul) % 64ul) | 1ul);
			ulong v6_v3 = Mathematics.RotateLeft(v6_v2, (int) (((0x376c9838da4d68ful) % 64ul) | 1ul));
			ulong v6_v4 = BinaryPrimitives.ReverseEndianness(v6_v3);
			ulong v6_v5 = ~v6_v4;

			ulong v7 = Mathematics.InverseShiftLeft(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong Ror_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x75a39d24e651549bul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((0x2ce036d8e98ec7f6ul) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 >> (int) (((0xaac69d7213c822beul) % 64ul) | 1ul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0x66c47d09c39ad9f1ul) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x2da9fafdcbf18560ul;
			ulong v1_l_v2 = v1_l_v1 - (0xe83b718b200b1cd7ul);
			ulong v1_l_v3 = v1_l_v2 * (0xefc0cf2d778051d8ul);
			ulong v1_l_v4 = ~v1_l_v3;

			ulong v1_r_v1 = 0x87691c370076c54bul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0xc899cb6a04e51042ul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 * (0x3770cf3a4bd649a3ul);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xfa0607823cf9a5d4ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = Mathematics.RotateLeft(v2_v3, (int) (((0xc5189b9b2d7773e3ul) % 64ul) | 1ul));

			ulong v3 = v2 + ((v2_v4));

			ulong v3_l_v1 = 0x2b2b7eb7a27b1d30ul;
			ulong v3_l_v2 = v3_l_v1 & (0xb1fc929d02d755daul);
			ulong v3_l_v3 = v3_l_v2 - (0xea6263785ca309d4ul);
			ulong v3_l_v4 = v3_l_v3 & (0x65895e0918c51515ul);

			ulong v3_r_v1 = 0x320292a4efaa1b1bul;
			ulong v3_r_v2 = v3_r_v1 >> (int) (((0xa2c3e505958b7780ul) % 64ul) | 1ul);
			ulong v3_r_v3 = v3_r_v2 & (0xe9e85dbe15cabb90ul);
			ulong v3_r_v4 = v3_r_v3 << (int) (((0x6a68e6cfa33d81ceul) % 64ul) | 1ul);
			ulong v3_r_v5 = BinaryPrimitives.ReverseEndianness(v3_r_v4);

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x64842d9bf87ab0cul;
			ulong v4_l_v2 = v4_l_v1 & (0x7604d3cabaedf0f9ul);
			ulong v4_l_v3 = v4_l_v2 ^ (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v4_l_v4 = v4_l_v3 & (0x699f622327d8ca8ul);

			ulong v4_r_v1 = 0xa7514cc6052eac8cul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 ^ (0xdd57c8dfd31cf82cul);
			ulong v4_r_v4 = v4_r_v3 & (0x10e5b915fbae0e0cul);
			ulong v4_r_v5 = Mathematics.RotateLeft(v4_r_v4, (int) (((0xf59b557d84737dfful) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x6aab574d334270edul;
			ulong v5_l_v2 = v5_l_v1 << (int) (((0xaa2fb97780b6d771ul) % 64ul) | 1ul);
			ulong v5_l_v3 = v5_l_v2 - (0x544cbaf616706801ul);
			ulong v5_l_v4 = Mathematics.RotateRight(v5_l_v3, (int) (((0xfc1c208958ac45b3ul) % 64ul) | 1ul));
			ulong v5_l_v5 = v5_l_v4 >> (int) (((0x1af79467e4915275ul) % 64ul) | 1ul);

			ulong v5_r_v1 = 0x7638d7c8396c006dul;
			ulong v5_r_v2 = v5_r_v1 | (0xf2bbf6df0419ab5ul);
			ulong v5_r_v3 = v5_r_v2 * (0x249bc610adeeba31ul);
			ulong v5_r_v4 = BinaryPrimitives.ReverseEndianness(v5_r_v3);
			ulong v5_r_v5 = Mathematics.RotateLeft(v5_r_v4, (int) (((0xe18e66b0d39d4187ul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong Ror_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x9d6bc9c0d627b55aul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((0x5229b66e8035d255ul) % 64ul) | 1ul));
			ulong Input_v3 = BinaryPrimitives.ReverseEndianness(Input_v2);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0x3574046125c235fcul) % 64ul) | 1ul));

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0xb7d119c346dced38ul;
			ulong v1_v2 = v1_v1 + (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0xfe0084f87b808757ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 >> (int) (((0xba29fa9b098b64fbul) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 + (0xf5801eed3881dbaaul);

			ulong v2 = v1 + ((v1_v5));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_v1 = 0x50cce26ae38e40e9ul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = v3_v2 ^ (0xe2ba7648156e80c5ul);
			ulong v3_v4 = ~v3_v3;
			ulong v3_v5 = v3_v4 << (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x25f1530aa45015c9ul;
			ulong v4_l_v2 = v4_l_v1 - (0xcb55a189d7437e69ul);
			ulong v4_l_v3 = v4_l_v2 * (0xccaf429b7ee18cb1ul);
			ulong v4_l_v4 = v4_l_v3 - (0x3d48be3003ecefcful);

			ulong v4_r_v1 = 0xeef96c612fb7c73dul;
			ulong v4_r_v2 = v4_r_v1 >> (int) (((0x947a993d73e6cccdul) % 64ul) | 1ul);
			ulong v4_r_v3 = v4_r_v2 + (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v4_r_v4 = v4_r_v3 * (0x107b9ae1688118d7ul);

			ulong v5 = Mathematics.InverseRotationRightLeft(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Ror_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xe1a0aee2d7bac0a6ul;
			ulong Input_v2 = Mathematics.RotateLeft(Input_v1, (int) (((0xd6c96134c3f9e35ful) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 << (int) (((0xc68ead8db1d77943ul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 * (0xfe0f066ba3243fe6ul);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0xca1550061d9a8c7aul;
			ulong v1_v2 = v1_v1 | (Configuration.NtBuildNumber);
			ulong v1_v3 = ~v1_v2;
			ulong v1_v4 = v1_v3 + (Configuration.NtMajorVersion);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xfdb6346ee7611199ul;
			ulong v2_v2 = v2_v1 & (0xead038409c16f114ul);
			ulong v2_v3 = v2_v2 >> (int) (((0x981d26a4f001a9fdul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 ^ (0xd9c1e94b483bbf50ul);
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xa894c8f093a350e0ul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0xd02d458fdc56a1a2ul) % 64ul) | 1ul));
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v3_v4 = BinaryPrimitives.ReverseEndianness(v3_v3);

			ulong v4 = v3 ^ ((v3_v4));

			ulong v4_v1 = 0x66ee944b9187ded8ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0x3220406e640a992cul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 << (int) (((0x23187c2aab885084ul) % 64ul) | 1ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Ror_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x994a2e41027d35b2ul;
			ulong Input_v2 = Input_v1 ^ (0xf168720f5a94a273ul);
			ulong Input_v3 = Input_v2 + (0x973595986e99f3a7ul);
			ulong Input_v4 = Input_v3 * (0x24484588768f38e8ul);

			ulong v1 = Mathematics.InverseShiftRight(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x835417b7894cc59aul;
			ulong v1_v2 = v1_v1 | (Configuration.NtMinorVersion);
			ulong v1_v3 = v1_v2 & (0x7cc561f52f7cb747ul);
			ulong v1_v4 = v1_v3 >> (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v1_v5 = BinaryPrimitives.ReverseEndianness(v1_v4);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v1_v5 % 64ul) | 1ul))));

			ulong v2_v1 = 0x8a34f7f076c9e088ul;
			ulong v2_v2 = v2_v1 * (Configuration.CpuBrandString1[2] & 0xffffffff);
			ulong v2_v3 = v2_v2 >> (int) (((0x2306436b4685e615ul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 - (0xf9c1b3fbac88caa6ul);
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = v2 ^ ((v2_v5));

			ulong v3_v1 = 0x3b760b374660a612ul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 - (0x6422b87e497fbfd8ul);
			ulong v3_v5 = v3_v4 + (0x7737b863ac95eefcul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0xefdc0e5e13e241d7ul;
			ulong v4_l_v2 = Mathematics.RotateRight(v4_l_v1, (int) (((0xcdb5dcda131d2d01ul) % 64ul) | 1ul));
			ulong v4_l_v3 = BinaryPrimitives.ReverseEndianness(v4_l_v2);
			ulong v4_l_v4 = v4_l_v3 << (int) (((0x12d26e4f11053256ul) % 64ul) | 1ul);
			ulong v4_l_v5 = ~v4_l_v4;

			ulong v4_r_v1 = 0x6c3e6ed5bcc4df25ul;
			ulong v4_r_v2 = BinaryPrimitives.ReverseEndianness(v4_r_v1);
			ulong v4_r_v3 = v4_r_v2 << (int) (((0xf36cd7447e18ce7eul) % 64ul) | 1ul);
			ulong v4_r_v4 = v4_r_v3 + (0xee7ad168f4dba7e0ul);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x6f0a860bcf46fedcul;
			ulong v5_v2 = v5_v1 >> (int) (((0xf5c13bbebd44c4b3ul) % 64ul) | 1ul);
			ulong v5_v3 = v5_v2 - (0x74561bc290a43b41ul);
			ulong v5_v4 = v5_v3 & (0xd32c99cbf1f0c24dul);
			ulong v5_v5 = v5_v4 - (0xd96908368ec2075cul);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0x34aa05692a649bacul;
			ulong v6_v2 = v6_v1 >> (int) (((0xac2b459d97c2b2bul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v6_v4 = Mathematics.RotateRight(v6_v3, (int) (((0xe1c0ec7b3a8390f3ul) % 64ul) | 1ul));
			ulong v6_v5 = v6_v4 - (0x85549c95abfb4859ul);

			ulong v7 = Mathematics.InverseShiftRight(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			ulong v7_v1 = 0x401b4a2715ca2819ul;
			ulong v7_v2 = Mathematics.RotateLeft(v7_v1, (int) (((0x1b46d93a274f4a8dul) % 64ul) | 1ul));
			ulong v7_v3 = v7_v2 & (0x6a7a54fcb5e0ef52ul);
			ulong v7_v4 = v7_v3 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v7_v5 = v7_v4 + (0xfda8ae3be51b0b28ul);

			ulong v8 = v7 + ((v7_v5));

			return v8;
		}

		public static ulong Ror_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x1c4720aad89cf2caul;
			ulong Input_v2 = Input_v1 * (0x5fe51f0c3baba330ul);
			ulong Input_v3 = Input_v2 >> (int) (((0x5d018032a8f1c6beul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 | (0x7255c682eb2e1831ul);
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Input - ((Input_v5));
			ulong v1_v1 = 0xd1e127b389c77972ul;
			ulong v1_v2 = v1_v1 & (0xcd4c88607044481cul);
			ulong v1_v3 = Mathematics.RotateLeft(v1_v2, (int) (((0x722612517d40ed33ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 >> (int) (((0x39ef98e88152ddf7ul) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 - (0x6f38f9045e4651d8ul);

			ulong v2 = v1 ^ ((v1_v5));

			ulong v2_v1 = 0x1baf3daf3501c43dul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = Mathematics.RotateLeft(v2_v2, (int) (((0xc9430dad1da9f81ul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 & (0x289df4b6b284373cul);
			ulong v2_v5 = v2_v4 + (0xbbf0d04486f0ca5bul);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0xa7c8dcfc4178936eul;
			ulong v3_v2 = v3_v1 << (int) (((0xcf19ea71c861a500ul) % 64ul) | 1ul);
			ulong v3_v3 = v3_v2 & (0xc410aebe14070807ul);
			ulong v3_v4 = v3_v3 | (0x8f4a726b3ffebf08ul);

			ulong v4 = v3 ^ ((v3_v4));

			ulong v4_v1 = 0xd282bdbe51656dc5ul;
			ulong v4_v2 = v4_v1 + (0x6440fed8e8aeefd4ul);
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = v4_v3 + (0x2cae9c6839b5d250ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong Ror_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x6fb00acae0822cfeul;
			ulong Input_v2 = BinaryPrimitives.ReverseEndianness(Input_v1);
			ulong Input_v3 = Input_v2 ^ (0xb3faa5760dcc1123ul);
			ulong Input_v4 = Input_v3 | (0x74daba8611e7296aul);
			ulong Input_v5 = Mathematics.RotateRight(Input_v4, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x1357a0affbc116dcul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x9147c9fd96407ca8ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 << (int) (((0xa48e3d0dd59b7446ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 + (0x4e2b007eb018f4c6ul);
			ulong v1_v5 = v1_v4 | (0x986f9b3c5b603971ul);

			ulong v2 = v1 ^ ((v1_v5));

			ulong v2_v1 = 0xabc56fbcbf31018dul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = v2_v3 * (0x28215810644f6365ul);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_v1 = 0x130e71fd9feab345ul;
			ulong v4_v2 = v4_v1 ^ (0xac51b68462225f7aul);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);
			ulong v4_v5 = v4_v4 & (0xa706f72a14238becul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0x802a9f6d9af8e234ul;
			ulong v5_v2 = Mathematics.RotateRight(v5_v1, (int) (((0x76a9f6f4bea72808ul) % 64ul) | 1ul));
			ulong v5_v3 = v5_v2 * (0x1201a5e68385e5f4ul);
			ulong v5_v4 = Mathematics.RotateRight(v5_v3, (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul));

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v5_v4 % 64ul) | 1ul))));

			return v6;
		}

		public static ulong LoadCpuid_0_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = ~Input;
			ulong v1_v1 = 0x48f1c9e992b63892ul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x2c78fb87c0ffd2fful) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 >> (int) (((0xec4f8af5ccf350cul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 << (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul);

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xf836fd6509f04419ul;
			ulong v2_l_v2 = v2_l_v1 + (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v2_l_v3 = ~v2_l_v2;
			ulong v2_l_v4 = v2_l_v3 >> (int) (((0xdd57e5527611695dul) % 64ul) | 1ul);
			ulong v2_l_v5 = v2_l_v4 & (Configuration.CpuBrandString1[1] & 0xffffffff);

			ulong v2_r_v1 = 0x28f521add59280bful;
			ulong v2_r_v2 = Mathematics.RotateRight(v2_r_v1, (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_r_v3 = v2_r_v2 + (0xa9a4ac54bbce5d1dul);
			ulong v2_r_v4 = ~v2_r_v3;

			ulong v3 = Mathematics.InverseRotationRightLeft(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x98ae4e8ff8d0d704ul;
			ulong v3_v2 = v3_v1 | (0xd1719598f3c6ca1dul);
			ulong v3_v3 = v3_v2 & (0x9b9bd1eeb660597cul);
			ulong v3_v4 = v3_v3 ^ (0xa45e911734785ef4ul);
			ulong v3_v5 = ~v3_v4;

			ulong v4 = v3 + ((v3_v5));

			ulong v4_l_v1 = 0xee85b9620280a9c8ul;
			ulong v4_l_v2 = v4_l_v1 | (0xf68122caf5998da1ul);
			ulong v4_l_v3 = Mathematics.RotateRight(v4_l_v2, (int) (((0xb7a4e7ba2f982e91ul) % 64ul) | 1ul));
			ulong v4_l_v4 = v4_l_v3 & (0x643e54cd5f1dfb3aul);

			ulong v4_r_v1 = 0x45d7d146c1697874ul;
			ulong v4_r_v2 = Mathematics.RotateRight(v4_r_v1, (int) (((0xf7b8fa2b1356e9c5ul) % 64ul) | 1ul));
			ulong v4_r_v3 = ~v4_r_v2;
			ulong v4_r_v4 = BinaryPrimitives.ReverseEndianness(v4_r_v3);
			ulong v4_r_v5 = v4_r_v4 - (0x4086e3658ca95845ul);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0xcf5021b082611218ul;
			ulong v5_v2 = v5_v1 - (0xa25d40c1bf32d55aul);
			ulong v5_v3 = v5_v2 | (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);
			ulong v5_v5 = ~v5_v4;

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong LoadCpuid_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x6bfa42a13f39a2feul;
			ulong Input_v2 = Input_v1 + (0x671c61d4ba508dd2ul);
			ulong Input_v3 = Input_v2 * (0xc88fa45bfc8f19f2ul);
			ulong Input_v4 = ~Input_v3;
			ulong Input_v5 = Input_v4 * (0xf174ce7d8f9943e8ul);

			ulong v1 = Mathematics.InverseShiftLeft(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x4905709b0be5cbcaul;
			ulong v1_v2 = v1_v1 - (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0x8979bb4e8f1e5bf9ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 & (0xf5e6274a641b9755ul);

			ulong v2 = v1 - ((v1_v4));

			ulong v2_v1 = 0x1c5e31a9878deed8ul;
			ulong v2_v2 = v2_v1 & (0xf2fd6e8f439846b0ul);
			ulong v2_v3 = v2_v2 << (int) (((0xca55600eb55c4828ul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 ^ (0x8a63eb71f13f4a5dul);

			ulong v3 = v2 ^ ((v2_v4));

			ulong v3_l_v1 = 0x1db4be4b621d78d1ul;
			ulong v3_l_v2 = ~v3_l_v1;
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v3_l_v5 = v3_l_v4 | (0xddbd5602d9b979cul);

			ulong v3_r_v1 = 0x26f1abc548d2315ul;
			ulong v3_r_v2 = v3_r_v1 | (Configuration.NtBuildNumber);
			ulong v3_r_v3 = v3_r_v2 >> (int) (((0x375616db39265830ul) % 64ul) | 1ul);
			ulong v3_r_v4 = v3_r_v3 & (0xbce13a2efadbbf0ful);

			ulong v4 = Mathematics.InverseRotationRightLeft(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xabe0b3f4019d55cul;
			ulong v4_v2 = v4_v1 | (0xddf5d8db6676bf0dul);
			ulong v4_v3 = v4_v2 ^ (0x8ba555e66100fcc1ul);
			ulong v4_v4 = v4_v3 - (0xa24f5958514f2437ul);
			ulong v4_v5 = v4_v4 << (int) (((0x3ff5207906185265ul) % 64ul) | 1ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong LoadCpuid_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xde82a98a7d8d378cul;
			ulong Input_l_v2 = Input_l_v1 ^ (0xe416f4a763eb73f9ul);
			ulong Input_l_v3 = Input_l_v2 | (0x8062f4c61cb954e8ul);
			ulong Input_l_v4 = Mathematics.RotateLeft(Input_l_v3, (int) (((0x2a1e64451d8ffaf6ul) % 64ul) | 1ul));
			ulong Input_l_v5 = Input_l_v4 * (0x78b293e626207849ul);

			ulong Input_r_v1 = 0x167d2e6a5a831b45ul;
			ulong Input_r_v2 = Mathematics.RotateLeft(Input_r_v1, (int) (((0x530a5d65574ea72ul) % 64ul) | 1ul));
			ulong Input_r_v3 = Input_r_v2 ^ (0x55bc91958456fedaul);
			ulong Input_r_v4 = Input_r_v3 << (int) (((0x8e5946528ed77ca9ul) % 64ul) | 1ul);
			ulong Input_r_v5 = Input_r_v4 * (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x4a509a3aa575d4dbul;
			ulong v1_v2 = v1_v1 >> (int) (((0x2c1dc4a7559cc3e7ul) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 ^ (0x45af62b466619149ul);
			ulong v1_v4 = v1_v3 & (0x8fbba0f03f483565ul);
			ulong v1_v5 = Mathematics.RotateRight(v1_v4, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xf0b6e54a09aa88f2ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));
			ulong v2_v4 = ~v2_v3;
			ulong v2_v5 = v2_v4 ^ (0x160d78f0390395deul);

			ulong v3 = v2 - ((v2_v5));

			ulong v3_v1 = 0x35369d3da729068eul;
			ulong v3_v2 = v3_v1 * (0x48d7e48730defe77ul);
			ulong v3_v3 = v3_v2 + (0xade5566e47853ed5ul);
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((0x5aa42f4f830b15b8ul) % 64ul) | 1ul));
			ulong v3_v5 = v3_v4 + (Configuration.NtMajorVersion);

			ulong v4 = v3 ^ ((v3_v5));


			ulong v5 = BinaryPrimitives.ReverseEndianness(v4);


			ulong v6 = ~v5;

			ulong v6_l_v1 = 0x66cb7e48661aa7dcul;
			ulong v6_l_v2 = Mathematics.RotateLeft(v6_l_v1, (int) (((0xb18967157ebef354ul) % 64ul) | 1ul));
			ulong v6_l_v3 = v6_l_v2 >> (int) (((0x77970fe40538f32aul) % 64ul) | 1ul);
			ulong v6_l_v4 = v6_l_v3 + (0xeeb25045f6789a31ul);

			ulong v6_r_v1 = 0xc4b0d934c2723ec5ul;
			ulong v6_r_v2 = Mathematics.RotateLeft(v6_r_v1, (int) (((0xe952dd665add1aa0ul) % 64ul) | 1ul));
			ulong v6_r_v3 = v6_r_v2 - (0xbf88ecbb50043c1bul);
			ulong v6_r_v4 = v6_r_v3 + (0xbfb570c4e681cf1aul);

			ulong v7 = Mathematics.InverseRotationLeftRight(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong LoadCpuid_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x69b5b75dad9282fful;
			ulong Input_v2 = Input_v1 >> (int) (((0xfd86727e938925f6ul) % 64ul) | 1ul);
			ulong Input_v3 = Input_v2 * (0x33b6b892b96fcc22ul);
			ulong Input_v4 = Input_v3 >> (int) (((0x1c6180cb1ac50c16ul) % 64ul) | 1ul);

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x5937b884176bea0ul;
			ulong v1_v2 = v1_v1 ^ (0x12c11f273a2514a5ul);
			ulong v1_v3 = v1_v2 << (int) (((0xc55cd801853f62f5ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 >> (int) (((0xc908fd22562afe7dul) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 ^ (0x6f5ce8613d2c0458ul);

			ulong v2 = v1 ^ ((v1_v5));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_v1 = 0x75616b6e31fa472bul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = v3_v2 | (0x91b851593c229418ul);
			ulong v3_v4 = v3_v3 << (int) (((0x716b1bab7df2784bul) % 64ul) | 1ul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0xa60a7c7207c8fed6ul;
			ulong v4_l_v2 = v4_l_v1 << (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_l_v3 = BinaryPrimitives.ReverseEndianness(v4_l_v2);
			ulong v4_l_v4 = v4_l_v3 | (0x9c15b2064eeb4be2ul);
			ulong v4_l_v5 = ~v4_l_v4;

			ulong v4_r_v1 = 0xf462c799d1eba17bul;
			ulong v4_r_v2 = BinaryPrimitives.ReverseEndianness(v4_r_v1);
			ulong v4_r_v3 = v4_r_v2 | (0x507f31dffd7bffc3ul);
			ulong v4_r_v4 = Mathematics.RotateRight(v4_r_v3, (int) (((0x52c7b0f4f1126f2cul) % 64ul) | 1ul));
			ulong v4_r_v5 = BinaryPrimitives.ReverseEndianness(v4_r_v4);

			ulong v5 = Mathematics.InverseRotationRightLeft(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0x7bd70ca64fe3669aul;
			ulong v5_v2 = v5_v1 * (0x783a57258fa902b9ul);
			ulong v5_v3 = v5_v2 >> (int) (((0xfb740d9adb588735ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 | (0x1dcf3d5c0d68b977ul);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0xdb2fbf6579cc5d8dul;
			ulong v6_l_v2 = ~v6_l_v1;
			ulong v6_l_v3 = v6_l_v2 ^ (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v6_l_v4 = Mathematics.RotateLeft(v6_l_v3, (int) (((0xe5cab79895629663ul) % 64ul) | 1ul));

			ulong v6_r_v1 = 0x1f828baed115e74dul;
			ulong v6_r_v2 = v6_r_v1 * (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v6_r_v3 = BinaryPrimitives.ReverseEndianness(v6_r_v2);
			ulong v6_r_v4 = v6_r_v3 - (0x945a353c8a94e2e2ul);

			ulong v7 = Mathematics.InverseRotationRightLeft(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0x70d7637048aa8a3bul;
			ulong v7_v2 = v7_v1 - (0xe153bd5136acd4bbul);
			ulong v7_v3 = Mathematics.RotateLeft(v7_v2, (int) (((0xe226a5e14b04059aul) % 64ul) | 1ul));
			ulong v7_v4 = v7_v3 ^ (0x6ceb46adef79250dul);

			ulong v8 = v7 ^ ((v7_v4));

			ulong v8_l_v1 = 0x2294ffd5fd6a46e4ul;
			ulong v8_l_v2 = BinaryPrimitives.ReverseEndianness(v8_l_v1);
			ulong v8_l_v3 = v8_l_v2 + (Configuration.NtBuildNumber);
			ulong v8_l_v4 = ~v8_l_v3;
			ulong v8_l_v5 = v8_l_v4 - (Configuration.NtMinorVersion);

			ulong v8_r_v1 = 0x11b8ca166412cda9ul;
			ulong v8_r_v2 = v8_r_v1 | (Configuration.NtBuildNumber);
			ulong v8_r_v3 = v8_r_v2 & (0xdf264433967709d0ul);
			ulong v8_r_v4 = v8_r_v3 - (0x24572ec2527ef6c3ul);
			ulong v8_r_v5 = Mathematics.RotateLeft(v8_r_v4, (int) (((0xf06c0f4a82d21ecdul) % 64ul) | 1ul));

			ulong v9 = Mathematics.InverseRotationRightRight(v8, (int) (((v8_l_v5 % 64ul) | 1ul)), (int) (((v8_r_v5 % 64ul) | 1ul)));

			return v9;
		}

		public static ulong LoadCpuid_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x1c7006489fdc3d2ul;
			ulong Input_v2 = Input_v1 + (Configuration.NtMinorVersion);
			ulong Input_v3 = Input_v2 & (0xcb5d9ad052720bcful);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong Input_v5 = Input_v4 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v1 = Mathematics.InverseShiftLeft(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x1ff37dce126199faul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0x2a6d89be66941d02ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 * (0x1a956b4705dec73aul);
			ulong v1_v4 = v1_v3 & (0xdc132c72dc34f31bul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_v1 = 0xf1998881f552e6cul;
			ulong v2_v2 = v2_v1 + (0x9ede4b7c06ec267ul);
			ulong v2_v3 = v2_v2 & (0x5f72211260b45607ul);
			ulong v2_v4 = ~v2_v3;

			ulong v3 = v2 - ((v2_v4));

			ulong v3_l_v1 = 0x6b46e9671d0ee4d4ul;
			ulong v3_l_v2 = Mathematics.RotateLeft(v3_l_v1, (int) (((0xd050bf211ffb0283ul) % 64ul) | 1ul));
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((0xad06aca02bea813dul) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (0x6bd07bd433bf96e4ul);
			ulong v3_l_v5 = v3_l_v4 - (0x7dbe0b7d9a745208ul);

			ulong v3_r_v1 = 0x27ff40fb4fa0e13cul;
			ulong v3_r_v2 = Mathematics.RotateLeft(v3_r_v1, (int) (((0x4944cd1e6a4ce247ul) % 64ul) | 1ul));
			ulong v3_r_v3 = v3_r_v2 >> (int) (((0x611a964d43b365a0ul) % 64ul) | 1ul);
			ulong v3_r_v4 = Mathematics.RotateLeft(v3_r_v3, (int) (((0x434f1f28057fddf6ul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x731d3eabcafe1ddful;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 & (0x3de970a1f36b8d52ul);
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 << (int) (((0x56f62d807fd48fadul) % 64ul) | 1ul);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0xe54c72e08329a990ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = v5_v2 << (int) (((0xf5e5547b8218ba88ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 >> (int) (((0x7c40ab8c7950f469ul) % 64ul) | 1ul);
			ulong v5_v5 = v5_v4 ^ (0xd3bba08175ddf394ul);

			ulong v6 = v5 - ((v5_v5));

			return v6;
		}

		public static ulong LoadCpuid_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x89e530c0dff14f36ul;
			ulong Input_l_v2 = Input_l_v1 ^ (0xb85171976541cadaul);
			ulong Input_l_v3 = Input_l_v2 | (Configuration.NtBuildNumber);
			ulong Input_l_v4 = Input_l_v3 >> (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong Input_l_v5 = BinaryPrimitives.ReverseEndianness(Input_l_v4);

			ulong Input_r_v1 = 0x7a90875618bc98f0ul;
			ulong Input_r_v2 = Input_r_v1 ^ (0x9939c6348d451991ul);
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 >> (int) (((0x61ff7492fd28b78ful) % 64ul) | 1ul);
			ulong Input_r_v5 = Mathematics.RotateLeft(Input_r_v4, (int) (((0x67b628452284c08eul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));

			ulong v2 = ~v1;


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_l_v1 = 0xd189d525b18507c5ul;
			ulong v3_l_v2 = BinaryPrimitives.ReverseEndianness(v3_l_v1);
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((0x8cedc0cc685280eful) % 64ul) | 1ul));
			ulong v3_l_v4 = Mathematics.RotateLeft(v3_l_v3, (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul));

			ulong v3_r_v1 = 0xbbddb0e17bced7c5ul;
			ulong v3_r_v2 = v3_r_v1 >> (int) (((0xc911a0519d529876ul) % 64ul) | 1ul);
			ulong v3_r_v3 = v3_r_v2 & (0xb85c65ed0e69d4b8ul);
			ulong v3_r_v4 = v3_r_v3 * (0xe37a5e3dadb62420ul);
			ulong v3_r_v5 = Mathematics.RotateRight(v3_r_v4, (int) (((0x5df7e5f36f44feabul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xc2a6d867f505a4f5ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 | (0xcc002a67b82da1dful);
			ulong v4_v4 = v4_v3 << (int) (((0xe205511cc9e9e05aul) % 64ul) | 1ul);
			ulong v4_v5 = Mathematics.RotateLeft(v4_v4, (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul));

			ulong v5 = v4 ^ ((v4_v5));

			return v5;
		}

		public static ulong LoadCpuid_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xe15e8f5950b7d483ul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((0x960c549d80c11b66ul) % 64ul) | 1ul));
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = BinaryPrimitives.ReverseEndianness(Input_v3);
			ulong Input_v5 = Input_v4 + (0x3328efe2fbcfcfd2ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x5d42d662d976a08aul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((0x8bb0494a790683f4ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 - (0x11b2669428cd7bc8ul);
			ulong v1_v4 = v1_v3 | (0xd119bcb5b3232102ul);

			ulong v2 = v1 ^ ((v1_v4));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_v1 = 0x86fb58b92b65ec20ul;
			ulong v3_v2 = v3_v1 << (int) (((0xbd244f68ed7e3417ul) % 64ul) | 1ul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0x720c5573e2708b91ul) % 64ul) | 1ul));
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v4 | 1ul)));

			ulong v4_v1 = 0x78a5c92106d823b4ul;
			ulong v4_v2 = v4_v1 ^ (0x82bfcd11a0f22c5ful);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = v4_v3 & (0x3c491d3765a2b927ul);
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0x63a72fd0dfe05d72ul;
			ulong v5_v2 = ~v5_v1;
			ulong v5_v3 = v5_v2 >> (int) (((0xdc3bd8504f4884e9ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 | (0x6eb74704a7400adaul);

			ulong v6 = v5 ^ ((v5_v4));

			return v6;
		}

		public static ulong LoadNumberOfProcessors_0_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_l_v1 = 0xd202ddccc2fa840cul;
			ulong v1_l_v2 = v1_l_v1 + (0x70300948b24abdc8ul);
			ulong v1_l_v3 = ~v1_l_v2;
			ulong v1_l_v4 = v1_l_v3 >> (int) (((0x1f2c93d80516d864ul) % 64ul) | 1ul);

			ulong v1_r_v1 = 0x959dbefecdf1645ul;
			ulong v1_r_v2 = v1_r_v1 & (Configuration.NtMajorVersion);
			ulong v1_r_v3 = v1_r_v2 >> (int) (((0x79274cbf0fb263c1ul) % 64ul) | 1ul);
			ulong v1_r_v4 = ~v1_r_v3;
			ulong v1_r_v5 = v1_r_v4 | (0x2ed36fbaac48c7d3ul);

			ulong v2 = Mathematics.InverseRotationLeftRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x48b3de791948f2a5ul;
			ulong v2_v2 = v2_v1 * (0xdd332500ae28a948ul);
			ulong v2_v3 = v2_v2 & (0x94f9552cd95d6c59ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0x6602305389028023ul) % 64ul) | 1ul));
			ulong v2_v5 = v2_v4 >> (int) (((0x98b1fd6d59d295dcul) % 64ul) | 1ul);

			ulong v3 = v2 ^ ((v2_v5));

			ulong v3_v1 = 0x7915fd6a582737bul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0x75f56c622b6ed8f6ul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 * (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v3_v4 = v3_v3 << (int) (((0xdaa2d6924cab92bbul) % 64ul) | 1ul);

			ulong v4 = v3 - ((v3_v4));

			ulong v4_v1 = 0x2fc21b9556e04280ul;
			ulong v4_v2 = v4_v1 * (Configuration.NtBuildNumber);
			ulong v4_v3 = v4_v2 << (int) (((0x5aa51e91eb02ce46ul) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 & (0x334fba77e0d9b02ul);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong LoadNumberOfProcessors_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x47efc680c1f7841eul;
			ulong Input_v2 = Mathematics.RotateLeft(Input_v1, (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 & (0xae58d10df172c2a8ul);
			ulong Input_v4 = Input_v3 | (0x6078f27d8a41a508ul);
			ulong Input_v5 = Input_v4 + (0x1593d01217b1a267ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0xc98319f102c5cc6cul;
			ulong v1_l_v2 = Mathematics.RotateLeft(v1_l_v1, (int) (((0x3856accd3779b6daul) % 64ul) | 1ul));
			ulong v1_l_v3 = v1_l_v2 >> (int) (((0x5a09016c03bfc32cul) % 64ul) | 1ul);
			ulong v1_l_v4 = v1_l_v3 + (0xd16d4607814d4400ul);
			ulong v1_l_v5 = v1_l_v4 - (0x3418746b99ace3bul);

			ulong v1_r_v1 = 0x64221838ab063a8eul;
			ulong v1_r_v2 = v1_r_v1 & (0xa579f859dde373a0ul);
			ulong v1_r_v3 = BinaryPrimitives.ReverseEndianness(v1_r_v2);
			ulong v1_r_v4 = v1_r_v3 >> (int) (((0x4be442403b488a74ul) % 64ul) | 1ul);
			ulong v1_r_v5 = Mathematics.RotateLeft(v1_r_v4, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xe7673dd7055fbb8cul;
			ulong v2_l_v2 = BinaryPrimitives.ReverseEndianness(v2_l_v1);
			ulong v2_l_v3 = v2_l_v2 - (0xd75999217481f7c7ul);
			ulong v2_l_v4 = v2_l_v3 | (0x126fc9d9e9eb159bul);

			ulong v2_r_v1 = 0xc1caf88ed6bf1d89ul;
			ulong v2_r_v2 = v2_r_v1 | (0x69bfec97c9b4926eul);
			ulong v2_r_v3 = v2_r_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v2_r_v4 = v2_r_v3 * (0x56cf97e8cd33b700ul);
			ulong v2_r_v5 = v2_r_v4 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xe2a9c58f05b01f36ul;
			ulong v3_v2 = Mathematics.RotateRight(v3_v1, (int) (((0x3b6c839e34934994ul) % 64ul) | 1ul));
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 ^ (Configuration.CpuBrandString3[3] & 0xffffffff);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xdaf65e1d15edbd8ul;
			ulong v4_v2 = v4_v1 & (0x52864ce8538a49e6ul);
			ulong v4_v3 = v4_v2 + (Configuration.NtMinorVersion);
			ulong v4_v4 = v4_v3 - (0x4f27e52db6a59b76ul);
			ulong v4_v5 = v4_v4 ^ (0x3c28820d44d00e58ul);

			ulong v5 = v4 ^ ((v4_v5));

			ulong v5_l_v1 = 0x7f373712b4ef7343ul;
			ulong v5_l_v2 = v5_l_v1 ^ (0x59efad7690bae9a1ul);
			ulong v5_l_v3 = ~v5_l_v2;
			ulong v5_l_v4 = v5_l_v3 | (0x950a1821d24a1817ul);

			ulong v5_r_v1 = 0xcd860943dd3412a0ul;
			ulong v5_r_v2 = ~v5_r_v1;
			ulong v5_r_v3 = v5_r_v2 * (0x8276697e4d8a154ul);
			ulong v5_r_v4 = Mathematics.RotateLeft(v5_r_v3, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v5_r_v5 = Mathematics.RotateRight(v5_r_v4, (int) (((0x992f5a8d58b5406bul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0x2feeeddfcf0fa49cul;
			ulong v6_l_v2 = Mathematics.RotateRight(v6_l_v1, (int) (((0xe4a3bf922cba1b84ul) % 64ul) | 1ul));
			ulong v6_l_v3 = v6_l_v2 + (0xde29ec612dbb8d0aul);
			ulong v6_l_v4 = v6_l_v3 | (0xd844c56ef4b9d433ul);
			ulong v6_l_v5 = v6_l_v4 + (0xd79e3fdfc59afc63ul);

			ulong v6_r_v1 = 0x1b0db5a5f86952ddul;
			ulong v6_r_v2 = Mathematics.RotateLeft(v6_r_v1, (int) (((0xcdd8f50c8d108b07ul) % 64ul) | 1ul));
			ulong v6_r_v3 = v6_r_v2 - (Configuration.NtMinorVersion);
			ulong v6_r_v4 = ~v6_r_v3;

			ulong v7 = Mathematics.InverseRotationLeftLeft(v6, (int) (((v6_l_v5 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0x617c0fc3d43a09e0ul;
			ulong v7_v2 = v7_v1 & (0xe860af086d5c6d33ul);
			ulong v7_v3 = BinaryPrimitives.ReverseEndianness(v7_v2);
			ulong v7_v4 = v7_v3 + (0x51bc71443e0de8ebul);

			ulong v8 = v7 - ((v7_v4));

			return v8;
		}

		public static ulong LoadNumberOfProcessors_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x93152dc03b7b328eul;
			ulong Input_l_v2 = Input_l_v1 | (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong Input_l_v3 = Input_l_v2 & (0xdda276aed306a53bul);
			ulong Input_l_v4 = Input_l_v3 - (Configuration.NtMajorVersion);

			ulong Input_r_v1 = 0xc46f57984f939b5bul;
			ulong Input_r_v2 = Input_r_v1 ^ (Configuration.NtMinorVersion);
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 << (int) (((0xfdb89373744eac1eul) % 64ul) | 1ul);
			ulong Input_r_v5 = Input_r_v4 - (Configuration.CpuBrandString1[2] & 0xffffffff);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xe63fd16d1ed6233cul;
			ulong v1_l_v2 = v1_l_v1 & (0x206bda39359be91dul);
			ulong v1_l_v3 = v1_l_v2 - (0x594631f9c2b04861ul);
			ulong v1_l_v4 = Mathematics.RotateLeft(v1_l_v3, (int) (((0x8bb6f8a06ff8230aul) % 64ul) | 1ul));

			ulong v1_r_v1 = 0xd8c75e4cb27e356ul;
			ulong v1_r_v2 = Mathematics.RotateLeft(v1_r_v1, (int) (((0x7339a8feb764c283ul) % 64ul) | 1ul));
			ulong v1_r_v3 = v1_r_v2 | (0x9d383c70b0c109dcul);
			ulong v1_r_v4 = BinaryPrimitives.ReverseEndianness(v1_r_v3);
			ulong v1_r_v5 = v1_r_v4 & (0xc2cd588518686613ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xf864a545db00292ful;
			ulong v2_v2 = BinaryPrimitives.ReverseEndianness(v2_v1);
			ulong v2_v3 = v2_v2 | (0x2de18005fa0f7fd2ul);
			ulong v2_v4 = v2_v3 - (0x93ec862284619aeeul);
			ulong v2_v5 = v2_v4 * (0x7822929d2cf62dadul);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x3bc853cdd8b600f2ul;
			ulong v3_l_v2 = v3_l_v1 - (0xc2f9f99db2bce8dcul);
			ulong v3_l_v3 = v3_l_v2 ^ (0x124792c483c3cad0ul);
			ulong v3_l_v4 = Mathematics.RotateRight(v3_l_v3, (int) (((0xf577c190b7c6580cul) % 64ul) | 1ul));

			ulong v3_r_v1 = 0xa17647e5ac419cbful;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = v3_r_v2 - (0x1f6d68e6bf890a21ul);
			ulong v3_r_v4 = v3_r_v3 + (Configuration.NtMajorVersion);
			ulong v3_r_v5 = v3_r_v4 * (0xa3de89ac3b0b7562ul);

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x11e1100ac56a00adul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 >> (int) (((0x88c3f55627fb7055ul) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 - (0x5fd0e9248f0d87d9ul);
			ulong v4_v5 = Mathematics.RotateRight(v4_v4, (int) (((0xadb69597d96abd6ul) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0x470ce9663b022219ul;
			ulong v5_v2 = Mathematics.RotateLeft(v5_v1, (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v5_v3 = v5_v2 >> (int) (((0xf9ec069349bb11f7ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 & (0xb2d9d2dcf7bcb4cbul);

			ulong v6 = v5 ^ ((v5_v4));

			return v6;
		}

		public static ulong LoadNumberOfProcessors_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x45dd402cdb0caa3eul;
			ulong Input_v2 = Input_v1 | (0x5683846a2aad7bfcul);
			ulong Input_v3 = Input_v2 << (int) (((0xc345da60f550c1f0ul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 & (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v1 = Input ^ ((Input_v4));
			ulong v1_v1 = 0x239a5834d7b0957aul;
			ulong v1_v2 = v1_v1 & (0xe60f0c4893522ac6ul);
			ulong v1_v3 = Mathematics.RotateLeft(v1_v2, (int) (((0x3e1de9bebee838eul) % 64ul) | 1ul));
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x778e832fb4d09aeul) % 64ul) | 1ul));
			ulong v1_v5 = BinaryPrimitives.ReverseEndianness(v1_v4);

			ulong v2 = v1 + ((v1_v5));

			ulong v2_v1 = 0x705f385887bbe58dul;
			ulong v2_v2 = v2_v1 | (Configuration.NtMinorVersion);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 ^ (0x169a3416007df307ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v4 % 64ul) | 1ul))));

			ulong v3_v1 = 0xe385c511a3d19645ul;
			ulong v3_v2 = v3_v1 + (0xa30db95341c55593ul);
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((0xbff1c7cb3a9e781aul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 & (0x389d8cec6da8140dul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x480fc49317734aebul;
			ulong v4_v2 = v4_v1 * (0xab7dfffbebdae311ul);
			ulong v4_v3 = v4_v2 << (int) (((0x432c047735c8e094ul) % 64ul) | 1ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);
			ulong v4_v5 = v4_v4 ^ (0x79beac0abe76d6ul);

			ulong v5 = v4 - ((v4_v5));

			ulong v5_v1 = 0x3870e48389c75c25ul;
			ulong v5_v2 = v5_v1 * (0xa603ccd9018ff1fbul);
			ulong v5_v3 = ~v5_v2;
			ulong v5_v4 = v5_v3 >> (int) (((0x719f81e7fb711a75ul) % 64ul) | 1ul);
			ulong v5_v5 = v5_v4 + (0xff232e22543c716ul);

			ulong v6 = v5 ^ ((v5_v5));

			return v6;
		}

		public static ulong LoadNumberOfProcessors_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x2aec9574cb07c893ul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((0xc1cf3fbc5d2c90abul) % 64ul) | 1ul));
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Input_v3 & (0x6d31f54af0043da1ul);
			ulong Input_v5 = Input_v4 - (0xcd4bd876836260b5ul);

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));

			ulong v2 = ~v1;

			ulong v2_v1 = 0x62fc180def1a362cul;
			ulong v2_v2 = v2_v1 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 - (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v2_v4 = Mathematics.RotateLeft(v2_v3, (int) (((0xe198854bb77932f1ul) % 64ul) | 1ul));
			ulong v2_v5 = v2_v4 | (0xf79cc3e75190f2ccul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_v1 = 0x377d85d7ddfae778ul;
			ulong v3_v2 = v3_v1 - (0x5ad6c902d44a184ful);
			ulong v3_v3 = v3_v2 >> (int) (((0xdb165e11bb305c7aul) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((0xc6ddafb9384e9f14ul) % 64ul) | 1ul));

			ulong v4 = v3 + ((v3_v4));

			ulong v4_l_v1 = 0x8accc822dc12d6ccul;
			ulong v4_l_v2 = v4_l_v1 & (Configuration.NtBuildNumber);
			ulong v4_l_v3 = v4_l_v2 * (Configuration.NtMajorVersion);
			ulong v4_l_v4 = v4_l_v3 << (int) (((0xff57a9d99eb7422ul) % 64ul) | 1ul);

			ulong v4_r_v1 = 0x3c69dbb31763540cul;
			ulong v4_r_v2 = v4_r_v1 ^ (0x8a20b82f0c258e39ul);
			ulong v4_r_v3 = v4_r_v2 * (0xd0743fce8d6cd1ceul);
			ulong v4_r_v4 = v4_r_v3 | (0x8bea60ca30245d2ul);

			ulong v5 = Mathematics.InverseRotationRightRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x747b677a768fc89aul;
			ulong v5_v2 = v5_v1 - (0xea6aec35ffdf7b92ul);
			ulong v5_v3 = BinaryPrimitives.ReverseEndianness(v5_v2);
			ulong v5_v4 = v5_v3 << (int) (((0x80907417c8d6b092ul) % 64ul) | 1ul);

			ulong v6 = v5 - ((v5_v4));

			ulong v6_v1 = 0xf909c0f4bf6f14e5ul;
			ulong v6_v2 = BinaryPrimitives.ReverseEndianness(v6_v1);
			ulong v6_v3 = v6_v2 & (0x2efd90fe6dc9628aul);
			ulong v6_v4 = BinaryPrimitives.ReverseEndianness(v6_v3);

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			ulong v7_v1 = 0xe03e6fd2b9dd7c15ul;
			ulong v7_v2 = v7_v1 | (0xc2af1e7769d63b54ul);
			ulong v7_v3 = v7_v2 & (0x272af4f5c0e999e4ul);
			ulong v7_v4 = v7_v3 + (0x19150893c517b950ul);

			ulong v8 = v7 + ((v7_v4));

			ulong v8_v1 = 0x7524fa1c3a417b05ul;
			ulong v8_v2 = v8_v1 + (0xadfb571515dd2de9ul);
			ulong v8_v3 = v8_v2 ^ (0x658ca100cae808d0ul);
			ulong v8_v4 = v8_v3 << (int) (((0x61d0ef34506cf890ul) % 64ul) | 1ul);
			ulong v8_v5 = v8_v4 + (0x688e314ef7571b68ul);

			ulong v9 = v8 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v8_v5 % 64ul) | 1ul))));

			return v9;
		}

		public static ulong LoadFirmwareType_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x3e5599b51c7ddf96ul;
			ulong Input_l_v2 = Mathematics.RotateLeft(Input_l_v1, (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_l_v3 = Input_l_v2 & (0x307acf903667182eul);
			ulong Input_l_v4 = Input_l_v3 | (Configuration.NtMajorVersion);
			ulong Input_l_v5 = Input_l_v4 - (0xf393ea546f78d7e8ul);

			ulong Input_r_v1 = 0x723455a1c88255d5ul;
			ulong Input_r_v2 = Mathematics.RotateLeft(Input_r_v1, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong Input_r_v3 = Input_r_v2 & (0xa2454d8062a23a5eul);
			ulong Input_r_v4 = Input_r_v3 + (0x81f7eaf6953835a6ul);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xfca96d710f7529edul;
			ulong v1_v2 = v1_v1 | (0xc2c06aad65946686ul);
			ulong v1_v3 = v1_v2 * (0x31a69c088bfa3b19ul);
			ulong v1_v4 = Mathematics.RotateLeft(v1_v3, (int) (((0xaeee1adbf3e384eaul) % 64ul) | 1ul));

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xbe5c58961a43b491ul;
			ulong v2_v2 = v2_v1 | (0x448fea0719443660ul);
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = v2_v3 + (0xd281a755717103ddul);

			ulong v3 = v2 + ((v2_v4));

			ulong v3_v1 = 0x4e64c6d98eccfa6bul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = v3_v2 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateRight(v3_v3, (int) (((0xe07cff8db839b26dul) % 64ul) | 1ul));
			ulong v3_v5 = v3_v4 ^ (0x94d7afdfd96266d1ul);

			ulong v4 = Mathematics.InverseShiftRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x74fde1262df42c34ul;
			ulong v4_v2 = v4_v1 & (0xa4718dec90e75674ul);
			ulong v4_v3 = v4_v2 + (Configuration.NtMajorVersion);
			ulong v4_v4 = v4_v3 >> (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v5 = Mathematics.RotateLeft(v4_v4, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_l_v1 = 0x2d0588c8d96aacd6ul;
			ulong v5_l_v2 = v5_l_v1 & (0xd40e20ba40e67f1eul);
			ulong v5_l_v3 = v5_l_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 >> (int) (((0xccd3c3c41611a3aul) % 64ul) | 1ul);
			ulong v5_l_v5 = v5_l_v4 | (Configuration.NtMajorVersion);

			ulong v5_r_v1 = 0x6ec34f711252a6d4ul;
			ulong v5_r_v2 = v5_r_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v5_r_v3 = v5_r_v2 << (int) (((0xcca82cc443ed038cul) % 64ul) | 1ul);
			ulong v5_r_v4 = v5_r_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v5_r_v5 = v5_r_v4 - (0xcc72297ba9846751ul);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0xc13c9a5ba9547e40ul;
			ulong v6_v2 = v6_v1 & (0xb468dc583a9ea56cul);
			ulong v6_v3 = v6_v2 << (int) (((0x8db6847233d59f32ul) % 64ul) | 1ul);
			ulong v6_v4 = v6_v3 >> (int) (((0x29bef0e546d7ed85ul) % 64ul) | 1ul);

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			ulong v7_v1 = 0x3a90512f7991b685ul;
			ulong v7_v2 = v7_v1 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v7_v3 = Mathematics.RotateRight(v7_v2, (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul));
			ulong v7_v4 = v7_v3 ^ (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v7_v5 = ~v7_v4;

			ulong v8 = v7 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v7_v5 % 64ul) | 1ul))));


			ulong v9 = BinaryPrimitives.ReverseEndianness(v8);

			return v9;
		}

		public static ulong LoadFirmwareType_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x7719272f112edea9ul;
			ulong Input_v2 = Input_v1 * (0xb43aeae0c06e398ul);
			ulong Input_v3 = Input_v2 ^ (0x78fd3d3042254840ul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0x39916ff7ae317431ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));

			ulong v2 = BinaryPrimitives.ReverseEndianness(v1);

			ulong v2_v1 = 0xdaf78d68265f0e2dul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 | (0xf2812e3cd21fe175ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0x6eff8b66ebfb980aul) % 64ul) | 1ul));

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x675ee8947a29c2bul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 * (0xe4344062d09cdc65ul);
			ulong v3_v4 = v3_v3 - (0xe5003e30de182023ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x1494499f906f356cul;
			ulong v4_v2 = v4_v1 | (0x6589b723a9653ecbul);
			ulong v4_v3 = v4_v2 - (0x197a8ef52744c873ul);
			ulong v4_v4 = v4_v3 * (0x32418780265dc8aful);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x87e2cc83f07fad04ul;
			ulong v5_v2 = ~v5_v1;
			ulong v5_v3 = v5_v2 | (0xc6304dbb1c8a4435ul);
			ulong v5_v4 = Mathematics.RotateRight(v5_v3, (int) (((0x308692fce1a4e0bdul) % 64ul) | 1ul));
			ulong v5_v5 = v5_v4 * (0xcd60930813d7fafful);

			ulong v6 = v5 + ((v5_v5));

			return v6;
		}

		public static ulong LoadFirmwareType_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xaec53cbed1de6f2ul;
			ulong Input_v2 = Input_v1 + (0x2acc67ae637870edul);
			ulong Input_v3 = Input_v2 >> (int) (((0xd5e546b09ca2594dul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 & (0x553327bdd90a9f2dul);
			ulong Input_v5 = Input_v4 - (0x2ba676ecaea0b75ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0xc22fe4bba83227eful;
			ulong v1_l_v2 = v1_l_v1 << (int) (((0xd8827e52758927daul) % 64ul) | 1ul);
			ulong v1_l_v3 = v1_l_v2 - (0x7a86b0f3837eba3dul);
			ulong v1_l_v4 = v1_l_v3 >> (int) (((0xaf924cbd68709e73ul) % 64ul) | 1ul);

			ulong v1_r_v1 = 0xe0d878d19ca8b96cul;
			ulong v1_r_v2 = v1_r_v1 + (0x73696fc207db4a95ul);
			ulong v1_r_v3 = v1_r_v2 & (0xf96d0c0627b611aeul);
			ulong v1_r_v4 = ~v1_r_v3;
			ulong v1_r_v5 = v1_r_v4 - (0x61741403993a7ee5ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xbfeca904f84fe2e3ul;
			ulong v2_v2 = v2_v1 * (0x2c44dc8eabba4d57ul);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 & (0xa8cfd9cbe38397a2ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v4 % 64ul) | 1ul))));

			ulong v3_v1 = 0x4a437318fa0cd0ccul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 >> (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v3_v4 = BinaryPrimitives.ReverseEndianness(v3_v3);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v3_v4 % 64ul) | 1ul))));

			ulong v4_v1 = 0xf1f6b189506047a9ul;
			ulong v4_v2 = v4_v1 << (int) (((0x25750935d5a71462ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 | (0x35c6a53b46a584a5ul);
			ulong v4_v4 = v4_v3 * (0xac63e53b11eaa272ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			ulong v5_v1 = 0xad5db29d780e5f20ul;
			ulong v5_v2 = v5_v1 + (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong v5_v3 = v5_v2 - (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v5_v4 = v5_v3 << (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);

			ulong v6 = Mathematics.InverseShiftLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0xf226ef14012718f8ul;
			ulong v6_v2 = v6_v1 & (Configuration.NtMinorVersion);
			ulong v6_v3 = v6_v2 ^ (0xc15b26b219f1e23dul);
			ulong v6_v4 = Mathematics.RotateRight(v6_v3, (int) (((0x71cffe8d50bd35f2ul) % 64ul) | 1ul));

			ulong v7 = Mathematics.RotateLeft(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong LoadFirmwareType_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x888ff1bee10aa592ul;
			ulong Input_v2 = Input_v1 & (Configuration.NtMajorVersion);
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v4 = BinaryPrimitives.ReverseEndianness(Input_v3);
			ulong Input_v5 = Input_v4 >> (int) (((0x96b2ae22217a0321ul) % 64ul) | 1ul);

			ulong v1 = Input - ((Input_v5));
			ulong v1_l_v1 = 0xfbc238e95438b0d9ul;
			ulong v1_l_v2 = v1_l_v1 << (int) (((0x99bb3824e9d697f6ul) % 64ul) | 1ul);
			ulong v1_l_v3 = v1_l_v2 + (Configuration.NtMinorVersion);
			ulong v1_l_v4 = v1_l_v3 - (0x8b48f14e06cb49ecul);
			ulong v1_l_v5 = BinaryPrimitives.ReverseEndianness(v1_l_v4);

			ulong v1_r_v1 = 0x49ab60d57aef6324ul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = ~v1_r_v2;
			ulong v1_r_v4 = v1_r_v3 * (0x504825067400bb38ul);
			ulong v1_r_v5 = v1_r_v4 + (0x75f7a1c33acfce35ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x5356f54687379d61ul;
			ulong v2_v2 = v2_v1 + (Configuration.NtBuildNumber);
			ulong v2_v3 = v2_v2 & (0x75ae2c458b79dcb1ul);
			ulong v2_v4 = v2_v3 >> (int) (((0x2a67c9a1e0c8fd66ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0xa225bdf0ba855aacul;
			ulong v3_l_v2 = v3_l_v1 | (0x7fcf45b745ad41e2ul);
			ulong v3_l_v3 = v3_l_v2 << (int) (((0x76f5a24ca57ff386ul) % 64ul) | 1ul);
			ulong v3_l_v4 = v3_l_v3 >> (int) (((0x7f299b13d835d100ul) % 64ul) | 1ul);

			ulong v3_r_v1 = 0xd7850babf8ab1c20ul;
			ulong v3_r_v2 = v3_r_v1 * (0x352d788af7a67fb7ul);
			ulong v3_r_v3 = v3_r_v2 & (0x7a3ebf7c841a91b1ul);
			ulong v3_r_v4 = v3_r_v3 * (0x98c0e0fa8008036cul);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xcaebf6cd1961f57cul;
			ulong v4_v2 = v4_v1 - (0x7c4066dfb7fe66e2ul);
			ulong v4_v3 = Mathematics.RotateRight(v4_v2, (int) (((0xcb43feac2e76814eul) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 + (0x9990c2d4b66b900eul);
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = v4 ^ ((v4_v5));

			ulong v5_l_v1 = 0xc6d53737f10d6ad3ul;
			ulong v5_l_v2 = v5_l_v1 * (0xdf5a90944e725e4ful);
			ulong v5_l_v3 = v5_l_v2 << (int) (((0xbd18183a49bfdf03ul) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 | (0x97b749bfee4a22b9ul);
			ulong v5_l_v5 = v5_l_v4 ^ (0xa7f9dca9d116e950ul);

			ulong v5_r_v1 = 0x7bb216adf0a54674ul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0x3df95cfbbab0d735ul) % 64ul) | 1ul));
			ulong v5_r_v3 = v5_r_v2 | (0x39cc74dfeeb68d40ul);
			ulong v5_r_v4 = v5_r_v3 * (0x5aa5ba6de11ea4fbul);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0x8714da21ecd578bful;
			ulong v6_v2 = v6_v1 << (int) (((0xd7544885dfede040ul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 & (0x393d198c28462e6cul);
			ulong v6_v4 = v6_v3 ^ (0x4541b135acd69fd9ul);
			ulong v6_v5 = v6_v4 + (0xbeed4a0de8e86649ul);

			ulong v7 = v6 + ((v6_v5));

			return v7;
		}

		public static ulong LoadFirmwareType_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xb0c3441c1ceeb318ul;
			ulong Input_v2 = Input_v1 | (0xd5bd59963113e3bul);
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((0xd1ca18ba4817b622ul) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 ^ (0xb5a5e30e4ff1745cul);
			ulong Input_v5 = BinaryPrimitives.ReverseEndianness(Input_v4);

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x2f5dda8063032e09ul;
			ulong v1_l_v2 = v1_l_v1 * (0xa6dfa4986a9d780cul);
			ulong v1_l_v3 = Mathematics.RotateLeft(v1_l_v2, (int) (((0xa62568d2296eba80ul) % 64ul) | 1ul));
			ulong v1_l_v4 = BinaryPrimitives.ReverseEndianness(v1_l_v3);
			ulong v1_l_v5 = v1_l_v4 - (0x8892d8cd756a849dul);

			ulong v1_r_v1 = 0xcaab85c91bc64636ul;
			ulong v1_r_v2 = v1_r_v1 << (int) (((0x4c4bd06ab513bb1dul) % 64ul) | 1ul);
			ulong v1_r_v3 = v1_r_v2 >> (int) (((0xe53eaaa61a1c25e0ul) % 64ul) | 1ul);
			ulong v1_r_v4 = v1_r_v3 * (0x6053f0b72c9aa8f1ul);
			ulong v1_r_v5 = v1_r_v4 & (0x9b3399c2bc62815eul);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x335b32195b54ad94ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = v2_v3 + (0x2a37424b91d9568aul);
			ulong v2_v5 = ~v2_v4;

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_v1 = 0xf909ded52a146ee2ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = ~v3_v2;
			ulong v3_v4 = v3_v3 & (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v3_v5 = v3_v4 - (0x43f92b899adc1d55ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));


			ulong v5 = BinaryPrimitives.ReverseEndianness(v4);

			ulong v5_v1 = 0x3471ea31332e8811ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = Mathematics.RotateLeft(v5_v2, (int) (((0xb4d2b6ee81bd4523ul) % 64ul) | 1ul));
			ulong v5_v4 = Mathematics.RotateRight(v5_v3, (int) (((0x44255b30565b8f8dul) % 64ul) | 1ul));
			ulong v5_v5 = v5_v4 ^ (0x173b5191db432570ul);

			ulong v6 = v5 - ((v5_v5));

			return v6;
		}

		public static ulong LoadFirmwareType_5_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_l_v1 = 0xbb1d218441862040ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = v1_l_v2 & (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v1_l_v4 = v1_l_v3 ^ (0x5d318dca6f58cfc5ul);

			ulong v1_r_v1 = 0xe49487eabe93ab16ul;
			ulong v1_r_v2 = ~v1_r_v1;
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0x232adc091abb0524ul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 >> (int) (((0x88709ce07ae9befbul) % 64ul) | 1ul);
			ulong v1_r_v5 = v1_r_v4 + (Configuration.NtMinorVersion);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xc0fbda960ee0510cul;
			ulong v2_v2 = v2_v1 ^ (0xd94769db184d25aaul);
			ulong v2_v3 = v2_v2 << (int) (((0xbd0f11f8b1760bfbul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 + (0x31292838e6157b87ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v4 | 1ul)));

			ulong v3_l_v1 = 0xe8d3f581717f6493ul;
			ulong v3_l_v2 = v3_l_v1 + (0x382c2aec4c2bce4cul);
			ulong v3_l_v3 = v3_l_v2 - (0xa3b2596f165944d8ul);
			ulong v3_l_v4 = v3_l_v3 << (int) (((0x88e649c4f87c43b8ul) % 64ul) | 1ul);
			ulong v3_l_v5 = v3_l_v4 ^ (Configuration.CpuBrandString2[3] & 0xffffffff);

			ulong v3_r_v1 = 0xdd1ac95fac1b6506ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = Mathematics.RotateRight(v3_r_v2, (int) (((0x9f3f3654802d1968ul) % 64ul) | 1ul));
			ulong v3_r_v4 = v3_r_v3 & (0x9fc399b1a2a9b8c6ul);
			ulong v3_r_v5 = ~v3_r_v4;

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x7aaf1949ade2e2a9ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0x2372695e3c593964ul) % 64ul) | 1ul));
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = v4_v3 ^ (Configuration.NtMajorVersion);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			ulong v5_v1 = 0x3da7aa553258e5eaul;
			ulong v5_v2 = v5_v1 + (0x17fb83445f19a5f7ul);
			ulong v5_v3 = v5_v2 & (0x53eb5d3e2fc36d03ul);
			ulong v5_v4 = v5_v3 << (int) (((0x4015eee43c7d7ba3ul) % 64ul) | 1ul);

			ulong v6 = Mathematics.InverseShiftLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong UpdateBootGuid_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x74de970f8954e659ul;
			ulong Input_l_v2 = Input_l_v1 - (0x463f9fe61b7981bcul);
			ulong Input_l_v3 = Input_l_v2 + (0xac177275d1921e1dul);
			ulong Input_l_v4 = BinaryPrimitives.ReverseEndianness(Input_l_v3);

			ulong Input_r_v1 = 0x8417738db0ac29deul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = Input_r_v2 << (int) (((0xf23914643218a497ul) % 64ul) | 1ul);
			ulong Input_r_v4 = Mathematics.RotateRight(Input_r_v3, (int) (((0x65c1257e4cace45ful) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xa30c466c04eb2667ul;
			ulong v1_l_v2 = v1_l_v1 - (0xcf2a1dcf5c1e70baul);
			ulong v1_l_v3 = v1_l_v2 ^ (0x6c53b6b6acbd8918ul);
			ulong v1_l_v4 = v1_l_v3 * (0x7d4a35d246197c85ul);

			ulong v1_r_v1 = 0x3b51a5e96e22e2cul;
			ulong v1_r_v2 = v1_r_v1 & (0x52f1b9fbba4da86ul);
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0xf0187e83c395fceul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x701a96385d2ee001ul;
			ulong v2_v2 = Mathematics.RotateRight(v2_v1, (int) (((0x209d8ec85ca9f0d2ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 >> (int) (((0xddb6cb884d0984cdul) % 64ul) | 1ul);
			ulong v2_v4 = v2_v3 & (Configuration.NtMajorVersion);

			ulong v3 = v2 - ((v2_v4));

			ulong v3_l_v1 = 0x39732aefbebb03cful;
			ulong v3_l_v2 = v3_l_v1 << (int) (((0x6b7b6155df692e72ul) % 64ul) | 1ul);
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((0x932f65d2ed2fb0f1ul) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (0xd4b5e830d76f3e9cul);
			ulong v3_l_v5 = v3_l_v4 | (0x38127e4017d2dfc2ul);

			ulong v3_r_v1 = 0x699666127fca566cul;
			ulong v3_r_v2 = v3_r_v1 + (Configuration.NtMajorVersion);
			ulong v3_r_v3 = Mathematics.RotateLeft(v3_r_v2, (int) (((0x76fdfa10a759ecd1ul) % 64ul) | 1ul));
			ulong v3_r_v4 = v3_r_v3 >> (int) (((0x99e87fbd1ebcd651ul) % 64ul) | 1ul);

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x6b6e6a775f2026eaul;
			ulong v4_v2 = v4_v1 >> (int) (((0x54d3f2f2c631bfc2ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 - (0x1c0393a56b9a899eul);
			ulong v4_v4 = v4_v3 & (0x589542fbf20d9c68ul);
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = v4 - ((v4_v5));

			ulong v5_v1 = 0xdd9cbe37a296dce6ul;
			ulong v5_v2 = v5_v1 >> (int) (((0xe493247b34b36bedul) % 64ul) | 1ul);
			ulong v5_v3 = v5_v2 | (0xa03f98ea839a171ful);
			ulong v5_v4 = v5_v3 * (0xffcde6da74036735ul);
			ulong v5_v5 = BinaryPrimitives.ReverseEndianness(v5_v4);

			ulong v6 = Mathematics.InverseShiftLeft(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong UpdateBootGuid_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x604ee3043cdc9383ul;
			ulong Input_l_v2 = Input_l_v1 - (0xbdfbc5cd15c3bffbul);
			ulong Input_l_v3 = BinaryPrimitives.ReverseEndianness(Input_l_v2);
			ulong Input_l_v4 = ~Input_l_v3;
			ulong Input_l_v5 = Input_l_v4 - (0x64281478f55b420ul);

			ulong Input_r_v1 = 0x871a77f674c9c2f2ul;
			ulong Input_r_v2 = Input_r_v1 - (0x5eef8e7748447718ul);
			ulong Input_r_v3 = Input_r_v2 + (0xd75df33be588a9b3ul);
			ulong Input_r_v4 = Input_r_v3 & (0xf9cb68e8dbe338a6ul);
			ulong Input_r_v5 = ~Input_r_v4;

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xa8022e2580a9e76bul;
			ulong v1_v2 = v1_v1 << (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 | (0x2076a5895ff283d5ul);
			ulong v1_v4 = v1_v3 & (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v1_v5 = v1_v4 ^ (Configuration.NtMajorVersion);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0x3f81d58f98b572f3ul;
			ulong v2_l_v2 = v2_l_v1 << (int) (((0x11cc252006a29655ul) % 64ul) | 1ul);
			ulong v2_l_v3 = v2_l_v2 & (0xb3180b99d5dda960ul);
			ulong v2_l_v4 = v2_l_v3 + (Configuration.CpuBrandString3[1] & 0xffffffff);

			ulong v2_r_v1 = 0x1e505a4c9ae6c3b1ul;
			ulong v2_r_v2 = BinaryPrimitives.ReverseEndianness(v2_r_v1);
			ulong v2_r_v3 = v2_r_v2 * (Configuration.NtMinorVersion);
			ulong v2_r_v4 = Mathematics.RotateRight(v2_r_v3, (int) (((0xd290eff030077a9bul) % 64ul) | 1ul));
			ulong v2_r_v5 = v2_r_v4 << (int) (((0xc1bf9309701ae2b8ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x3ccceadfc7c73415ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 | (0x35a5a84670341931ul);
			ulong v3_v4 = ~v3_v3;

			ulong v4 = v3 ^ ((v3_v4));

			ulong v4_v1 = 0x8334ec85d4d15e16ul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = v4_v3 >> (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0xa3456a7196189feful;
			ulong v5_v2 = Mathematics.RotateRight(v5_v1, (int) (((0x39204ab31d88459ul) % 64ul) | 1ul));
			ulong v5_v3 = v5_v2 ^ (0x1e6ed8cd1f8578faul);
			ulong v5_v4 = v5_v3 | (0x1a1b1c999e08316ul);
			ulong v5_v5 = v5_v4 >> (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul);

			ulong v6 = v5 - ((v5_v5));

			return v6;
		}

		public static ulong UpdateBootGuid_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xdbc119bd0009d059ul;
			ulong Input_v2 = Input_v1 & (0x9d37fc665bf54a8eul);
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0x5993aa3415c9f252ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseShiftLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x142c96812dbf852dul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((0x4914c012e54b81e3ul) % 64ul) | 1ul));
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0xee11f2de46651e59ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 - (0xbc1e0e362e589fa1ul);
			ulong v1_v5 = v1_v4 << (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x432762666d515f53ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 - (Configuration.NtMinorVersion);
			ulong v2_v4 = ~v2_v3;
			ulong v2_v5 = v2_v4 | (Configuration.NtBuildNumber);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x52b92175f5681a28ul;
			ulong v3_v2 = v3_v1 + (0x5098fd5f07613c6ful);
			ulong v3_v3 = v3_v2 & (0x1ab0b6424dbdb09bul);
			ulong v3_v4 = v3_v3 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v4 = v3 + ((v3_v4));

			ulong v4_v1 = 0xf619ccaada67bf08ul;
			ulong v4_v2 = v4_v1 - (0xc1a233d59b79db0eul);
			ulong v4_v3 = v4_v2 | (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v4_v4 = v4_v3 >> (int) (((0xc985bc38ba887a02ul) % 64ul) | 1ul);
			ulong v4_v5 = v4_v4 | (0x8539a6ca6f18ce5cul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));


			ulong v6 = ~v5;

			return v6;
		}

		public static ulong UpdateBootGuid_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x6997e9e7dbc110aful;
			ulong Input_l_v2 = ~Input_l_v1;
			ulong Input_l_v3 = Input_l_v2 * (0x4b28334df7d2fa38ul);
			ulong Input_l_v4 = BinaryPrimitives.ReverseEndianness(Input_l_v3);
			ulong Input_l_v5 = Input_l_v4 * (0xda29e62ac6e463ddul);

			ulong Input_r_v1 = 0xa3360a447bb424adul;
			ulong Input_r_v2 = Input_r_v1 - (0x4d55a40493f6055cul);
			ulong Input_r_v3 = Input_r_v2 | (0xd0a3ac456b208ea7ul);
			ulong Input_r_v4 = Input_r_v3 - (0xfbb3af94bc41d936ul);
			ulong Input_r_v5 = Input_r_v4 ^ (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xab07e6dcd4c89429ul;
			ulong v1_v2 = v1_v1 + (Configuration.CpuBrandString1[2] & 0xffffffff);
			ulong v1_v3 = v1_v2 << (int) (((0x3bde8351f6d51f55ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 >> (int) (((0x84ff1f23a6b9047eul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xaf1043f7a3889c3aul;
			ulong v2_v2 = v2_v1 >> (int) (((0xb1b001f8b70c887bul) % 64ul) | 1ul);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 ^ (0x8991a1704aa9c720ul);
			ulong v2_v5 = v2_v4 << (int) (((0x17fbe6e23e97d75eul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x4434ccae4fb1e6b3ul;
			ulong v3_v2 = Mathematics.RotateRight(v3_v1, (int) (((0x998b941679ebb470ul) % 64ul) | 1ul));
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 << (int) (((0xff9276fdb37f92c9ul) % 64ul) | 1ul);
			ulong v3_v5 = BinaryPrimitives.ReverseEndianness(v3_v4);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0x26f8991bbea4b6c4ul;
			ulong v4_v2 = v4_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 & (0x34ae726130674eb5ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x204bf8b7e490e057ul;
			ulong v5_l_v2 = Mathematics.RotateRight(v5_l_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v5_l_v3 = v5_l_v2 ^ (0xf005c30ce87909a8ul);
			ulong v5_l_v4 = v5_l_v3 - (0xa6088036c2260ad1ul);

			ulong v5_r_v1 = 0x46b0fbf616ac0630ul;
			ulong v5_r_v2 = v5_r_v1 - (0xae864aacf5c4a7dful);
			ulong v5_r_v3 = v5_r_v2 >> (int) (((0x5951a6b4c2fe666eul) % 64ul) | 1ul);
			ulong v5_r_v4 = v5_r_v3 ^ (0xae95a890b9c7fd11ul);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong UpdateBootGuid_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x50ab0b8e9c50ec46ul;
			ulong Input_v2 = Input_v1 + (0x9adfe7dddfde8d90ul);
			ulong Input_v3 = Input_v2 | (0x106173ac2397625eul);
			ulong Input_v4 = Input_v3 << (int) (((0xea58042979cfedd9ul) % 64ul) | 1ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(((Input_v4 | 1ul)));
			ulong v1_l_v1 = 0xf5dc30c8d548143dul;
			ulong v1_l_v2 = v1_l_v1 & (0xbf407555d5e502d6ul);
			ulong v1_l_v3 = BinaryPrimitives.ReverseEndianness(v1_l_v2);
			ulong v1_l_v4 = Mathematics.RotateLeft(v1_l_v3, (int) (((0x6f474e048045042dul) % 64ul) | 1ul));

			ulong v1_r_v1 = 0x5742085ae505aa00ul;
			ulong v1_r_v2 = v1_r_v1 ^ (0xdb3630b23eea2e06ul);
			ulong v1_r_v3 = BinaryPrimitives.ReverseEndianness(v1_r_v2);
			ulong v1_r_v4 = v1_r_v3 + (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v1_r_v5 = v1_r_v4 & (0xf1d7fc7a13834371ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xac6bb90a70d5d9a3ul;
			ulong v2_v2 = v2_v1 >> (int) (((0x73228508dd3ff8d7ul) % 64ul) | 1ul);
			ulong v2_v3 = Mathematics.RotateLeft(v2_v2, (int) (((0xf51d7be20ec2a6a4ul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 | (0x8a13be9ff5528635ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v4 % 64ul) | 1ul))));

			ulong v3_v1 = 0x9beeda7f4285ca0eul;
			ulong v3_v2 = v3_v1 ^ (0x3b8a0b65b35301c5ul);
			ulong v3_v3 = v3_v2 << (int) (((0x144173d516745523ul) % 64ul) | 1ul);
			ulong v3_v4 = v3_v3 >> (int) (((0x8739dc9882d4c39dul) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 << (int) (((0xc49249232aab2d04ul) % 64ul) | 1ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xacd9c0ad44450ca9ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0x2f2b5fc0884ae79eul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 * (0x323e968d7dfe8cb8ul);
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong UpdateBootGuid_5_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);

			ulong v2 = ~v1;

			ulong v2_v1 = 0x1e52bc176acc8c5dul;
			ulong v2_v2 = v2_v1 & (0xfd3dd13822223b4eul);
			ulong v2_v3 = v2_v2 * (0x53a512865c4419d3ul);
			ulong v2_v4 = v2_v3 ^ (0x2c72b0bd9887609aul);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0xc4d632e2ca38bf13ul;
			ulong v3_l_v2 = v3_l_v1 + (0x997f566d238e3ab4ul);
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((0xd5fa339ea1073c76ul) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v3_l_v5 = ~v3_l_v4;

			ulong v3_r_v1 = 0x5c8a987d81d41e72ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = Mathematics.RotateLeft(v3_r_v2, (int) (((0x80ba79ed2a623877ul) % 64ul) | 1ul));
			ulong v3_r_v4 = v3_r_v3 & (0x6ad6883e9be7e3edul);
			ulong v3_r_v5 = ~v3_r_v4;

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x9e483b70bd87d5f2ul;
			ulong v4_l_v2 = v4_l_v1 | (0x5e9113f10709abbcul);
			ulong v4_l_v3 = v4_l_v2 + (0xd145fef698db9babul);
			ulong v4_l_v4 = v4_l_v3 - (0x8d355cdad55700e8ul);

			ulong v4_r_v1 = 0xc295bb91d9b7d205ul;
			ulong v4_r_v2 = v4_r_v1 - (0x901cbe289a92a8f0ul);
			ulong v4_r_v3 = BinaryPrimitives.ReverseEndianness(v4_r_v2);
			ulong v4_r_v4 = Mathematics.RotateLeft(v4_r_v3, (int) (((0x140b327b9d159a56ul) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseRotationRightLeft(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0xd9b9a6c77974baf7ul;
			ulong v5_v2 = Mathematics.RotateLeft(v5_v1, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v5_v3 = v5_v2 | (Configuration.CpuBrandString2[0] & 0xffffffff);
			ulong v5_v4 = v5_v3 * (0x6b185e4325c9af5aul);

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));


			ulong v7 = BinaryPrimitives.ReverseEndianness(v6);

			return v7;
		}

		public static ulong LoadNtMinorVersion_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x5f6a2f930bd6b131ul;
			ulong Input_l_v2 = Input_l_v1 | (0xf2e168515cf92d75ul);
			ulong Input_l_v3 = Input_l_v2 & (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong Input_l_v4 = BinaryPrimitives.ReverseEndianness(Input_l_v3);
			ulong Input_l_v5 = Input_l_v4 - (0xc256a107bade5428ul);

			ulong Input_r_v1 = 0x76cc1da83fe2da3dul;
			ulong Input_r_v2 = Input_r_v1 - (0x7aa0a89b1c097a93ul);
			ulong Input_r_v3 = Mathematics.RotateRight(Input_r_v2, (int) (((0x27aef05752c15534ul) % 64ul) | 1ul));
			ulong Input_r_v4 = Input_r_v3 & (0x3fd75222da4646f2ul);

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xacbc3b04f6afe869ul;
			ulong v1_l_v2 = v1_l_v1 + (0x95d49887ebf08406ul);
			ulong v1_l_v3 = ~v1_l_v2;
			ulong v1_l_v4 = v1_l_v3 * (0x1c11a3b5a9d33525ul);

			ulong v1_r_v1 = 0x9d2ac9d79a5a7b8ul;
			ulong v1_r_v2 = Mathematics.RotateRight(v1_r_v1, (int) (((0xe4300228b7f0147ful) % 64ul) | 1ul));
			ulong v1_r_v3 = v1_r_v2 << (int) (((0x8cd37defa615f87dul) % 64ul) | 1ul);
			ulong v1_r_v4 = v1_r_v3 & (Configuration.NtBuildNumber);
			ulong v1_r_v5 = v1_r_v4 << (int) (((0x78a39bd0381d427ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationRightRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xbdda97aacfb0a803ul;
			ulong v2_v2 = v2_v1 - (0x21f0a6639854388aul);
			ulong v2_v3 = v2_v2 | (0xfa4f63f97af04916ul);
			ulong v2_v4 = v2_v3 & (0xe74757552eba5781ul);

			ulong v3 = v2 - ((v2_v4));


			ulong v4 = ~v3;

			ulong v4_l_v1 = 0xe56c3c016e03def4ul;
			ulong v4_l_v2 = v4_l_v1 * (Configuration.NtBuildNumber);
			ulong v4_l_v3 = Mathematics.RotateLeft(v4_l_v2, (int) (((0x9c3cbeaaddbce4e4ul) % 64ul) | 1ul));
			ulong v4_l_v4 = v4_l_v3 >> (int) (((0x4a6162abcee0c4edul) % 64ul) | 1ul);
			ulong v4_l_v5 = v4_l_v4 << (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul);

			ulong v4_r_v1 = 0x71b618b875e1813eul;
			ulong v4_r_v2 = v4_r_v1 & (0xd67aef276697a922ul);
			ulong v4_r_v3 = BinaryPrimitives.ReverseEndianness(v4_r_v2);
			ulong v4_r_v4 = v4_r_v3 ^ (0x70d29f45d3362b67ul);

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));


			ulong v6 = ~v5;

			ulong v6_v1 = 0x6c8b8a623a78a7eeul;
			ulong v6_v2 = Mathematics.RotateLeft(v6_v1, (int) (((0x3ae302bfbd0b40c9ul) % 64ul) | 1ul));
			ulong v6_v3 = BinaryPrimitives.ReverseEndianness(v6_v2);
			ulong v6_v4 = Mathematics.RotateLeft(v6_v3, (int) (((0x8b91fdfd3340ede9ul) % 64ul) | 1ul));

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			return v7;
		}

		public static ulong LoadNtMinorVersion_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xc8b2197f7a8a1dcul;
			ulong Input_v2 = Input_v1 * (0x4f412820a55f3973ul);
			ulong Input_v3 = Input_v2 ^ (0x384045f9423d1ab2ul);
			ulong Input_v4 = Input_v3 * (0xdfb369be5b12f791ul);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0x5a0721d23cfe9f1cul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((0x934ca1b3ffbb2a49ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v1_v4 = ~v1_v3;

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xd917d5427263969ful;
			ulong v2_v2 = v2_v1 & (0x705e62866afb055dul);
			ulong v2_v3 = v2_v2 ^ (0xe4bb999bb4fa7ceful);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);
			ulong v2_v5 = ~v2_v4;

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0x29f1d65f65b8ab5bul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0x75125ee564b1dfbbul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 << (int) (((0xdad8ed4f60ad79dul) % 64ul) | 1ul);
			ulong v3_v4 = v3_v3 * (0x3acd4be2eba90141ul);
			ulong v3_v5 = ~v3_v4;

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v5 | 1ul)));

			ulong v4_v1 = 0x3b9e989bbb2ff2e0ul;
			ulong v4_v2 = v4_v1 | (0x63e3727fffc09966ul);
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((0x325a3ffce6a24b7bul) % 64ul) | 1ul));
			ulong v4_v4 = ~v4_v3;

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong LoadNtMinorVersion_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x4cc5d2e9dc26d15aul;
			ulong Input_v2 = Mathematics.RotateRight(Input_v1, (int) (((0xdd4abfa4c27fe6b3ul) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 >> (int) (((0x977063aa56971962ul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 + (0xd7be15b0f026fc04ul);
			ulong Input_v5 = Input_v4 >> (int) (((0x248a185dab6e33bcul) % 64ul) | 1ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0xa256fd11af94d49aul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((0xa52fdf0cee79d272ul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 ^ (0x920d4b76e032c00dul);
			ulong v1_v4 = v1_v3 >> (int) (((0xae74b36ba4ddc3bful) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 ^ (0x4fd9b2a567d02f89ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xba17950fa7039899ul;
			ulong v2_v2 = v2_v1 & (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v2_v3 = v2_v2 + (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v2_v4 = Mathematics.RotateLeft(v2_v3, (int) (((0x3838c5c4c1a870cdul) % 64ul) | 1ul));
			ulong v2_v5 = v2_v4 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_l_v1 = 0xb93415ecb3841618ul;
			ulong v3_l_v2 = ~v3_l_v1;
			ulong v3_l_v3 = BinaryPrimitives.ReverseEndianness(v3_l_v2);
			ulong v3_l_v4 = Mathematics.RotateRight(v3_l_v3, (int) (((0x88d3c583655cef9ful) % 64ul) | 1ul));

			ulong v3_r_v1 = 0x55722653a56b0010ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = Mathematics.RotateRight(v3_r_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v3_r_v4 = v3_r_v3 * (0x47b7c13f2ea6326ful);
			ulong v3_r_v5 = Mathematics.RotateLeft(v3_r_v4, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x94ac60d6d332df0dul;
			ulong v4_v2 = v4_v1 - (Configuration.NtBuildNumber);
			ulong v4_v3 = v4_v2 << (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);
			ulong v4_v5 = ~v4_v4;

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong LoadNtMinorVersion_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x3cc05ab95b16fc25ul;
			ulong Input_v2 = Input_v1 >> (int) (((0x470a2130571db9a4ul) % 64ul) | 1ul);
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 * (0x42b5f00afe06ebeeul);
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x1951c260cb6be37eul;
			ulong v1_l_v2 = v1_l_v1 ^ (0x2db1ddbff06629e1ul);
			ulong v1_l_v3 = v1_l_v2 + (0x8825181d58ffda06ul);
			ulong v1_l_v4 = v1_l_v3 ^ (0x44fc6c3cbdb90330ul);
			ulong v1_l_v5 = v1_l_v4 << (int) (((0x78dab98f0f48292aul) % 64ul) | 1ul);

			ulong v1_r_v1 = 0x4b147d7af92cc4d8ul;
			ulong v1_r_v2 = Mathematics.RotateLeft(v1_r_v1, (int) (((0xc14c68a3143e1208ul) % 64ul) | 1ul));
			ulong v1_r_v3 = v1_r_v2 >> (int) (((0x418b55cfb77afca5ul) % 64ul) | 1ul);
			ulong v1_r_v4 = v1_r_v3 | (0xb99d6a2156a8743ful);
			ulong v1_r_v5 = v1_r_v4 - (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v2 = Mathematics.InverseRotationLeftRight(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x6db440a267097912ul;
			ulong v2_v2 = v2_v1 >> (int) (((0xe296cf308b24b868ul) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 | (0xc923aae8db8e6a39ul);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x2ff9ca2dde2c860eul;
			ulong v3_l_v2 = v3_l_v1 + (0xf659264f8bb7d09bul);
			ulong v3_l_v3 = v3_l_v2 >> (int) (((0xebc230e64209895ul) % 64ul) | 1ul);
			ulong v3_l_v4 = v3_l_v3 & (0xdbce4d778686e1eul);

			ulong v3_r_v1 = 0x1d3bd316ef65b057ul;
			ulong v3_r_v2 = v3_r_v1 >> (int) (((0x7a965b6c370f6ddaul) % 64ul) | 1ul);
			ulong v3_r_v3 = ~v3_r_v2;
			ulong v3_r_v4 = v3_r_v3 ^ (0x3220a60c4b3009edul);

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));


			ulong v5 = ~v4;


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			ulong v6_v1 = 0xf7ded99cb24bec92ul;
			ulong v6_v2 = v6_v1 << (int) (((0x4e0882942edf1350ul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 | (0xb6c25097ce608f0eul);
			ulong v6_v4 = v6_v3 >> (int) (((0xad2bf07a60ecde31ul) % 64ul) | 1ul);
			ulong v6_v5 = v6_v4 ^ (0x9cbe585598011e30ul);

			ulong v7 = Mathematics.RotateRight(v6, (int) (((v6_v5 % 64ul) | 1ul)));


			ulong v8 = BinaryPrimitives.ReverseEndianness(v7);

			return v8;
		}

		public static ulong LoadNtMinorVersion_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x1636e9e4b9114442ul;
			ulong Input_v2 = Input_v1 * (0xa00ecd64e0f5145dul);
			ulong Input_v3 = Input_v2 & (0x41b6f585013b799bul);
			ulong Input_v4 = Input_v3 - (0x5b9d7e988d8ec968ul);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0x24d2dccc2ce0e573ul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = v1_v2 - (0xa45fd1c2933ac6a3ul);
			ulong v1_v4 = v1_v3 * (Configuration.CpuBrandString3[2] & 0xffffffff);
			ulong v1_v5 = v1_v4 - (0x94fac175e7943b16ul);

			ulong v2 = v1 + ((v1_v5));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_l_v1 = 0xbcd1ecd91f4faeb5ul;
			ulong v3_l_v2 = v3_l_v1 >> (int) (((0x8472fc8f854cd346ul) % 64ul) | 1ul);
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((0x738c9abc788c0d0aul) % 64ul) | 1ul));
			ulong v3_l_v4 = ~v3_l_v3;

			ulong v3_r_v1 = 0x2149b2cf938532feul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = Mathematics.RotateLeft(v3_r_v2, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));
			ulong v3_r_v4 = BinaryPrimitives.ReverseEndianness(v3_r_v3);
			ulong v3_r_v5 = Mathematics.RotateRight(v3_r_v4, (int) (((0xbe652b1abfee79dul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xf0d6603d06a48dd0ul;
			ulong v4_v2 = v4_v1 >> (int) (((0xf0bb96d4fba3e731ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 - (0x25bf4cccafd4a809ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong LoadNtMinorVersion_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x4979ddaaa0a28e51ul;
			ulong Input_v2 = Input_v1 * (0x5af7a78fca1910d1ul);
			ulong Input_v3 = Input_v2 - (0x1f46a09f41528852ul);
			ulong Input_v4 = Input_v3 >> (int) (((0xf57b8f372b73cb72ul) % 64ul) | 1ul);
			ulong Input_v5 = Input_v4 + (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x27be58f06dd62b6aul;
			ulong v1_v2 = v1_v1 >> (int) (((0x32d02a256e328c3aul) % 64ul) | 1ul);
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = ~v1_v3;

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x50fc3c439d153c98ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 | (0xec16d3529b27e1d2ul);
			ulong v2_v4 = ~v2_v3;

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v4 % 64ul) | 1ul))));

			ulong v3_l_v1 = 0xde0296c0460bb100ul;
			ulong v3_l_v2 = v3_l_v1 & (Configuration.NtMinorVersion);
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((0xeb2dcf4a078a92c2ul) % 64ul) | 1ul));
			ulong v3_l_v4 = BinaryPrimitives.ReverseEndianness(v3_l_v3);

			ulong v3_r_v1 = 0xa092c218c427f11ful;
			ulong v3_r_v2 = v3_r_v1 | (Configuration.NtBuildNumber);
			ulong v3_r_v3 = Mathematics.RotateLeft(v3_r_v2, (int) (((0xa36d936a7e705150ul) % 64ul) | 1ul));
			ulong v3_r_v4 = v3_r_v3 * (0x7d6d0fde1fe3bcaaul);
			ulong v3_r_v5 = v3_r_v4 << (int) (((0xe5d6a27ed4d0af6aul) % 64ul) | 1ul);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x1875f0a10c47c0dful;
			ulong v4_v2 = Mathematics.RotateRight(v4_v1, (int) (((0x7677b2059d6e9656ul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 >> (int) (((0x4fb2dae901cab4e8ul) % 64ul) | 1ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			ulong v5_v1 = 0x7cdd495af34d88aaul;
			ulong v5_v2 = v5_v1 + (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v5_v3 = v5_v2 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 + (0x50b1f41f6fc4cb59ul);

			ulong v6 = v5 ^ ((v5_v4));

			return v6;
		}

		public static ulong LoadNtMajorVersion_0_Obf(ulong Input, SystemConfiguration Configuration)
		{


			ulong v1 = BinaryPrimitives.ReverseEndianness(Input);
			ulong v1_v1 = 0x3d092eb328968ca2ul;
			ulong v1_v2 = Mathematics.RotateLeft(v1_v1, (int) (((0xea53d5c45213790cul) % 64ul) | 1ul));
			ulong v1_v3 = v1_v2 * (0x5b4a652a11e8e34bul);
			ulong v1_v4 = ~v1_v3;

			ulong v2 = v1 - ((v1_v4));

			ulong v2_v1 = 0xf28856e7a9ac0098ul;
			ulong v2_v2 = v2_v1 - (Configuration.NtMajorVersion);
			ulong v2_v3 = v2_v2 << (int) (((0x99eeff8170b6c1ceul) % 64ul) | 1ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0xe12deb39929d5cd4ul) % 64ul) | 1ul));
			ulong v2_v5 = v2_v4 * (Configuration.CpuBrandString3[3] & 0xffffffff);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xa96eb8423eff7d1eul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0x7f8dc99702036d52ul) % 64ul) | 1ul));
			ulong v3_v4 = ~v3_v3;

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));


			ulong v5 = ~v4;

			ulong v5_v1 = 0xfc5807ada0c06050ul;
			ulong v5_v2 = v5_v1 + (0x973cad0b8ba4cc4bul);
			ulong v5_v3 = Mathematics.RotateRight(v5_v2, (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v5_v4 = v5_v3 * (0x5a0c2845764759a8ul);

			ulong v6 = v5 * Mathematics.InverseMultiplication(((v5_v4 | 1ul)));

			ulong v6_v1 = 0xad3815c3d27db0dbul;
			ulong v6_v2 = v6_v1 | (0x8cdde1d9e254f049ul);
			ulong v6_v3 = v6_v2 ^ (0xdd8bd7518c0b7852ul);
			ulong v6_v4 = v6_v3 >> (int) (((0x5410b513c79604bful) % 64ul) | 1ul);

			ulong v7 = Mathematics.InverseShiftRight(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong LoadNtMajorVersion_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x9fde729ba030f1d4ul;
			ulong Input_l_v2 = Input_l_v1 * (0x88d3c2d41fc2e5c5ul);
			ulong Input_l_v3 = Mathematics.RotateRight(Input_l_v2, (int) (((0xee54b13b9bfa8a17ul) % 64ul) | 1ul));
			ulong Input_l_v4 = Input_l_v3 ^ (0x8e0dbbd292342214ul);
			ulong Input_l_v5 = Input_l_v4 << (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul);

			ulong Input_r_v1 = 0xdd7cd34c02d66e4ful;
			ulong Input_r_v2 = Input_r_v1 & (0x9de62c31bb0dfb55ul);
			ulong Input_r_v3 = Input_r_v2 ^ (0x222edd56fa664e8dul);
			ulong Input_r_v4 = Input_r_v3 * (0xfa378f9f1aa4420aul);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xb2baf6e1324f5e54ul;
			ulong v1_v2 = v1_v1 * (0xe466904dffb65d68ul);
			ulong v1_v3 = v1_v2 ^ (0xdf6ed846347d7c9cul);
			ulong v1_v4 = ~v1_v3;

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x97d37589462dc8aful;
			ulong v2_v2 = v2_v1 * (0xe0a046443a50856cul);
			ulong v2_v3 = v2_v2 - (0x4c33776a54ae7938ul);
			ulong v2_v4 = v2_v3 >> (int) (((0x80c32f1107258b9dul) % 64ul) | 1ul);
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0xb62ec0becb8560d1ul;
			ulong v3_v2 = v3_v1 * (0xb328102e5774656bul);
			ulong v3_v3 = v3_v2 << (int) (((0x1dba883ab90829edul) % 64ul) | 1ul);
			ulong v3_v4 = v3_v3 & (0xdb50bb43e7fd16ddul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x1a89a6968af08cd4ul;
			ulong v4_v2 = v4_v1 >> (int) (((0x7cbca2dcf93abce8ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 | (Configuration.NtMajorVersion);
			ulong v4_v4 = v4_v3 ^ (0x62ac3938b35d4804ul);

			ulong v5 = v4 + ((v4_v4));

			ulong v5_v1 = 0x2ea3d37c2a0363f6ul;
			ulong v5_v2 = v5_v1 & (0xb2908674a010d691ul);
			ulong v5_v3 = v5_v2 >> (int) (((0xde5986abce5fe8c4ul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 & (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v5_v4 % 64ul) | 1ul))));

			ulong v6_v1 = 0x22d924973456f464ul;
			ulong v6_v2 = v6_v1 + (0x5cfa0890e7038257ul);
			ulong v6_v3 = Mathematics.RotateRight(v6_v2, (int) (((0x4c9cfb5170254dc5ul) % 64ul) | 1ul));
			ulong v6_v4 = v6_v3 & (0xeab0e3f8e4948a94ul);
			ulong v6_v5 = v6_v4 - (0x94fd8c572e50220cul);

			ulong v7 = Mathematics.InverseShiftLeft(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			ulong v7_v1 = 0xa1a3cb598deaff1aul;
			ulong v7_v2 = v7_v1 | (0xdf9515f50a2b1f42ul);
			ulong v7_v3 = Mathematics.RotateRight(v7_v2, (int) (((0x973e206dd8e3e821ul) % 64ul) | 1ul));
			ulong v7_v4 = v7_v3 + (0xc864958fcb092185ul);

			ulong v8 = v7 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v7_v4 % 64ul) | 1ul))));

			return v8;
		}

		public static ulong LoadNtMajorVersion_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xb41c197abc5b6f25ul;
			ulong Input_v2 = Input_v1 * (0x8225a51b3cd93f9ul);
			ulong Input_v3 = BinaryPrimitives.ReverseEndianness(Input_v2);
			ulong Input_v4 = Input_v3 & (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0xca221c4ebba8179cul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x7bcd52c7c84409a6ul) % 64ul) | 1ul));

			ulong v2 = v1 + ((v1_v4));

			ulong v2_v1 = 0x55ac0d201f12b671ul;
			ulong v2_v2 = v2_v1 + (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 >> (int) (((0x6706728ec2447393ul) % 64ul) | 1ul);
			ulong v2_v5 = v2_v4 * (Configuration.NtMinorVersion);

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x6d633844adb06cbaul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((0x1211076d6127506dul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 * (0x3f94ef74c9cf79acul);

			ulong v4 = v3 + ((v3_v4));

			ulong v4_v1 = 0x5fe66d1a09b02805ul;
			ulong v4_v2 = v4_v1 & (0x1dad095528c8172ful);
			ulong v4_v3 = v4_v2 >> (int) (((Configuration.CpuBrandString1[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 - (Configuration.CpuBrandString3[3] & 0xffffffff);
			ulong v4_v5 = v4_v4 | (0xa41086e5fba1d9acul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong LoadNtMajorVersion_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x49a316928f4750b3ul;
			ulong Input_v2 = BinaryPrimitives.ReverseEndianness(Input_v1);
			ulong Input_v3 = Input_v2 - (0x5c77ffb3a9330d0ul);
			ulong Input_v4 = Input_v3 << (int) (((0xc914f65bfd2c5972ul) % 64ul) | 1ul);
			ulong Input_v5 = Input_v4 - (0x9e081c09fa33c6ful);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x224285525908d989ul;
			ulong v1_l_v2 = BinaryPrimitives.ReverseEndianness(v1_l_v1);
			ulong v1_l_v3 = v1_l_v2 << (int) (((0x69b0d845d2990781ul) % 64ul) | 1ul);
			ulong v1_l_v4 = v1_l_v3 | (0x8e7099e0d84bce90ul);

			ulong v1_r_v1 = 0xf37ba44e3917f345ul;
			ulong v1_r_v2 = v1_r_v1 * (0x752519510328f409ul);
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0x4c943461437ff7cful) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 * (Configuration.CpuBrandString1[3] & 0xffffffff);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x3ab8fe673af2eb4cul;
			ulong v2_v2 = v2_v1 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 & (0x1a6eb4e93c9f46b1ul);
			ulong v2_v4 = v2_v3 >> (int) (((0xb390fa108d17f8fbul) % 64ul) | 1ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v4 | 1ul)));

			ulong v3_l_v1 = 0xc84f2af5a3bb5fccul;
			ulong v3_l_v2 = Mathematics.RotateRight(v3_l_v1, (int) (((0x80aa66925916d9cul) % 64ul) | 1ul));
			ulong v3_l_v3 = v3_l_v2 * (0x34f13b01e619cf6ul);
			ulong v3_l_v4 = Mathematics.RotateRight(v3_l_v3, (int) (((0x92075d7ff35aa03cul) % 64ul) | 1ul));

			ulong v3_r_v1 = 0x4478000ba94f168cul;
			ulong v3_r_v2 = BinaryPrimitives.ReverseEndianness(v3_r_v1);
			ulong v3_r_v3 = Mathematics.RotateLeft(v3_r_v2, (int) (((0xbdb4e2ccfc2c68b8ul) % 64ul) | 1ul));
			ulong v3_r_v4 = Mathematics.RotateRight(v3_r_v3, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v3_r_v5 = Mathematics.RotateLeft(v3_r_v4, (int) (((0xdfe51c3f4a86fa88ul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x85bf39d02af1e840ul;
			ulong v4_v2 = v4_v1 + (0x40828504661623c3ul);
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = v4_v3 + (0x27d161176dd4095aul);
			ulong v4_v5 = BinaryPrimitives.ReverseEndianness(v4_v4);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_v1 = 0xe96bdb429daba710ul;
			ulong v5_v2 = v5_v1 ^ (Configuration.CpuBrandString3[2] & 0xffffffff);
			ulong v5_v3 = ~v5_v2;
			ulong v5_v4 = v5_v3 * (0x369d347d053bf28ful);
			ulong v5_v5 = v5_v4 >> (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v6 = v5 - ((v5_v5));

			ulong v6_l_v1 = 0xa43846dfcf619addul;
			ulong v6_l_v2 = v6_l_v1 >> (int) (((0xe7954fd9fa447ee9ul) % 64ul) | 1ul);
			ulong v6_l_v3 = Mathematics.RotateRight(v6_l_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v6_l_v4 = Mathematics.RotateLeft(v6_l_v3, (int) (((0xeab68cf816373ae9ul) % 64ul) | 1ul));
			ulong v6_l_v5 = v6_l_v4 << (int) (((0x25549dd6f0ce5a2cul) % 64ul) | 1ul);

			ulong v6_r_v1 = 0xfc4184fbcf1c490cul;
			ulong v6_r_v2 = v6_r_v1 - (0x8948ea8b713867e3ul);
			ulong v6_r_v3 = ~v6_r_v2;
			ulong v6_r_v4 = v6_r_v3 | (0x494a45bccec95b9aul);

			ulong v7 = Mathematics.InverseRotationLeftLeft(v6, (int) (((v6_l_v5 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0xfcb97073e8d07201ul;
			ulong v7_v2 = Mathematics.RotateLeft(v7_v1, (int) (((0xd0c1d622d8068464ul) % 64ul) | 1ul));
			ulong v7_v3 = v7_v2 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v7_v4 = Mathematics.RotateRight(v7_v3, (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v7_v5 = v7_v4 | (0xf157245623760ad2ul);

			ulong v8 = v7 ^ ((v7_v5));

			return v8;
		}

		public static ulong LoadNtMajorVersion_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xb582a3873a948cbdul;
			ulong Input_l_v2 = Mathematics.RotateLeft(Input_l_v1, (int) (((0x183cdbd16c8c5a63ul) % 64ul) | 1ul));
			ulong Input_l_v3 = Mathematics.RotateRight(Input_l_v2, (int) (((0x48f436bab5697abbul) % 64ul) | 1ul));
			ulong Input_l_v4 = Input_l_v3 ^ (0x2fb1b14156564483ul);

			ulong Input_r_v1 = 0xe4ba0ed2b1ea6c75ul;
			ulong Input_r_v2 = Input_r_v1 ^ (0x9b36a911d30ad4b2ul);
			ulong Input_r_v3 = ~Input_r_v2;
			ulong Input_r_v4 = Input_r_v3 | (Configuration.NtMajorVersion);
			ulong Input_r_v5 = Mathematics.RotateLeft(Input_r_v4, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xe4d7e4c50a3e7443ul;
			ulong v1_v2 = v1_v1 >> (int) (((0x6d01c679161e64caul) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 & (0x11e7d7f432340f81ul);
			ulong v1_v4 = v1_v3 | (0x665917becd308226ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x84263feefaa46bfeul;
			ulong v2_v2 = Mathematics.RotateRight(v2_v1, (int) (((0x810d2b594f9aff61ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 << (int) (((0x5f9670cc3f2f985aul) % 64ul) | 1ul);
			ulong v2_v4 = ~v2_v3;

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xa348b31edac175b4ul;
			ulong v3_v2 = v3_v1 << (int) (((0x108cb814b8adbd0aul) % 64ul) | 1ul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0x4a0545cd3e8b1d95ul) % 64ul) | 1ul));
			ulong v3_v4 = ~v3_v3;
			ulong v3_v5 = v3_v4 >> (int) (((0x9bc37fd025f82cf3ul) % 64ul) | 1ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x24d4f3f6b8dd8a83ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0x2549aaacd3e8fa2aul) % 64ul) | 1ul));
			ulong v4_v3 = v4_v2 << (int) (((0x38465f29fe9553f1ul) % 64ul) | 1ul);
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((0xc5a300fcce7d7c96ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 << (int) (((0xdc53896d258f947ful) % 64ul) | 1ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_v1 = 0x6b869f3d9f9ed46bul;
			ulong v5_v2 = v5_v1 * (0x5bac423b36e54b64ul);
			ulong v5_v3 = v5_v2 >> (int) (((0xaefec5f4b464850ful) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 & (0x369862fbcaf7714eul);
			ulong v5_v5 = Mathematics.RotateLeft(v5_v4, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v6 = v5 + ((v5_v5));

			return v6;
		}

		public static ulong LoadNtBuildNumber_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xaff4900c7c71ecdeul;
			ulong Input_v2 = Input_v1 * (0xc41224d58251978ful);
			ulong Input_v3 = Input_v2 | (0xdbc067e988e09dfaul);
			ulong Input_v4 = Input_v3 ^ (0x128fe0146b767e79ul);

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x6bdb3c554322f338ul;
			ulong v1_v2 = v1_v1 | (0x70a869cf8b394226ul);
			ulong v1_v3 = v1_v2 & (0x73a83c3c1c5af9a7ul);
			ulong v1_v4 = v1_v3 | (0x77de7c921ea6e054ul);

			ulong v2 = v1 + ((v1_v4));

			ulong v2_l_v1 = 0x97e11449d6074a33ul;
			ulong v2_l_v2 = v2_l_v1 << (int) (((Configuration.CpuBrandString3[0] & 0xffffffff) % 64ul) | 1ul);
			ulong v2_l_v3 = v2_l_v2 + (0x9681993f6c5557b8ul);
			ulong v2_l_v4 = Mathematics.RotateLeft(v2_l_v3, (int) (((0xfc1f4338dc528b6cul) % 64ul) | 1ul));

			ulong v2_r_v1 = 0x2cf1e62e63ac54ul;
			ulong v2_r_v2 = v2_r_v1 | (0x6c34d45f589ec1a2ul);
			ulong v2_r_v3 = v2_r_v2 - (0x9ee5ab9901ba7de3ul);
			ulong v2_r_v4 = v2_r_v3 * (0xc1ad6be42a9d7de2ul);
			ulong v2_r_v5 = v2_r_v4 - (0x9a60a1fb951c09b0ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xcd0209e9335fe4acul;
			ulong v3_v2 = v3_v1 + (0x662efa8405b80f7eul);
			ulong v3_v3 = v3_v2 << (int) (((0x2123ba34cada994cul) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((0x9b1a3c45c10ffd4bul) % 64ul) | 1ul));

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x1cd4077bbfe390e3ul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 - (0x34e70a416af5f53dul);
			ulong v4_v4 = ~v4_v3;
			ulong v4_v5 = v4_v4 | (0x94f8fd02d2bb3367ul);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_l_v1 = 0xa3bb6f8b8c096c14ul;
			ulong v5_l_v2 = BinaryPrimitives.ReverseEndianness(v5_l_v1);
			ulong v5_l_v3 = v5_l_v2 ^ (0xa962cb9d15b79518ul);
			ulong v5_l_v4 = v5_l_v3 << (int) (((0xc9945381469dd760ul) % 64ul) | 1ul);
			ulong v5_l_v5 = Mathematics.RotateRight(v5_l_v4, (int) (((0x3c5f2e800d4b3107ul) % 64ul) | 1ul));

			ulong v5_r_v1 = 0x29687531fa8e8f9dul;
			ulong v5_r_v2 = Mathematics.RotateRight(v5_r_v1, (int) (((0x7d9f79db05ceab58ul) % 64ul) | 1ul));
			ulong v5_r_v3 = v5_r_v2 >> (int) (((0x6f65a3f514911ab8ul) % 64ul) | 1ul);
			ulong v5_r_v4 = v5_r_v3 * (0xffbf2843a2745935ul);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong LoadNtBuildNumber_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x16c3f282278cac73ul;
			ulong Input_l_v2 = Input_l_v1 & (Configuration.NtMinorVersion);
			ulong Input_l_v3 = Input_l_v2 >> (int) (((0x3a5b780c74ce2ebdul) % 64ul) | 1ul);
			ulong Input_l_v4 = Input_l_v3 + (0xa80eaed85a163d68ul);

			ulong Input_r_v1 = 0xf5ebbd28c9aea31eul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 - (0x7193dd1e46a1b54ful);
			ulong Input_r_v5 = Input_r_v4 | (0x2d854707a9b648cful);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x3770a115a2a3a472ul;
			ulong v1_l_v2 = v1_l_v1 | (0x5a984dcb32c795d4ul);
			ulong v1_l_v3 = BinaryPrimitives.ReverseEndianness(v1_l_v2);
			ulong v1_l_v4 = v1_l_v3 << (int) (((0x5b36159172d4f80aul) % 64ul) | 1ul);
			ulong v1_l_v5 = BinaryPrimitives.ReverseEndianness(v1_l_v4);

			ulong v1_r_v1 = 0x883ec646d575664eul;
			ulong v1_r_v2 = v1_r_v1 - (0x64b0d997fb0e5710ul);
			ulong v1_r_v3 = v1_r_v2 + (Configuration.NtMajorVersion);
			ulong v1_r_v4 = BinaryPrimitives.ReverseEndianness(v1_r_v3);

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xcb45c63a651a96bbul;
			ulong v2_v2 = v2_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 | (0x44ea9ea46b8bc458ul);
			ulong v2_v4 = v2_v3 + (0x4e0258ae9373bbd6ul);
			ulong v2_v5 = v2_v4 * (0x55680d9cdb4bdb0aul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_v1 = 0xf708449c0315cd78ul;
			ulong v3_v2 = v3_v1 & (0xd4bb5e862b1a1844ul);
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 * (0xdf3ae582f05f954ul);
			ulong v3_v5 = v3_v4 - (0x4ca0ed3fee880962ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));


			ulong v5 = BinaryPrimitives.ReverseEndianness(v4);

			ulong v5_v1 = 0xbf4bc52baeb60fabul;
			ulong v5_v2 = ~v5_v1;
			ulong v5_v3 = Mathematics.RotateRight(v5_v2, (int) (((0xd81ca612e7f8f860ul) % 64ul) | 1ul));
			ulong v5_v4 = v5_v3 * (0x1a113a107358ac20ul);
			ulong v5_v5 = ~v5_v4;

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v5_v5 % 64ul) | 1ul))));

			ulong v6_v1 = 0x8aa4a173caedf265ul;
			ulong v6_v2 = v6_v1 | (Configuration.NtBuildNumber);
			ulong v6_v3 = BinaryPrimitives.ReverseEndianness(v6_v2);
			ulong v6_v4 = v6_v3 >> (int) (((0x5a936748eee55ba5ul) % 64ul) | 1ul);
			ulong v6_v5 = Mathematics.RotateLeft(v6_v4, (int) (((0x7b9b50872f94cba1ul) % 64ul) | 1ul));

			ulong v7 = v6 * Mathematics.InverseMultiplication(((v6_v5 | 1ul)));

			ulong v7_v1 = 0x74994b7551312786ul;
			ulong v7_v2 = BinaryPrimitives.ReverseEndianness(v7_v1);
			ulong v7_v3 = v7_v2 - (0xe4b7488cb2c4d8e8ul);
			ulong v7_v4 = v7_v3 & (0x2de43fdf3ab38a03ul);

			ulong v8 = Mathematics.InverseShiftRight(v7, (int) (((v7_v4 % 64ul) | 1ul)));

			return v8;
		}

		public static ulong LoadNtBuildNumber_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xf918b2e2c2848a7ful;
			ulong Input_v2 = ~Input_v1;
			ulong Input_v3 = Input_v2 >> (int) (((0xfa7606367c54e8e1ul) % 64ul) | 1ul);
			ulong Input_v4 = BinaryPrimitives.ReverseEndianness(Input_v3);

			ulong v1 = Input + ((Input_v4));
			ulong v1_l_v1 = 0x7782243cac424a2cul;
			ulong v1_l_v2 = Mathematics.RotateRight(v1_l_v1, (int) (((0x371ae0e306c8891ul) % 64ul) | 1ul));
			ulong v1_l_v3 = v1_l_v2 >> (int) (((0xb700b4fe2990f5bcul) % 64ul) | 1ul);
			ulong v1_l_v4 = v1_l_v3 - (0x92fd8b2bfe1d9686ul);
			ulong v1_l_v5 = v1_l_v4 << (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul);

			ulong v1_r_v1 = 0x3d666d129822bc42ul;
			ulong v1_r_v2 = v1_r_v1 << (int) (((0xb811913b6807f00bul) % 64ul) | 1ul);
			ulong v1_r_v3 = v1_r_v2 + (0xec08f6e148ce532aul);
			ulong v1_r_v4 = v1_r_v3 & (0xfcbe78ac88b6b44cul);

			ulong v2 = Mathematics.InverseRotationLeftRight(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xc429a8e5b891f9c7ul;
			ulong v2_v2 = v2_v1 + (Configuration.NtMinorVersion);
			ulong v2_v3 = v2_v2 | (0x37244e1b7f938c72ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0x1a0979552c3f94ceul) % 64ul) | 1ul));
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_l_v1 = 0xf188a6ad10dd726ul;
			ulong v3_l_v2 = v3_l_v1 >> (int) (((0xede4b5a926aeab73ul) % 64ul) | 1ul);
			ulong v3_l_v3 = v3_l_v2 * (0x155505446d8e40f0ul);
			ulong v3_l_v4 = BinaryPrimitives.ReverseEndianness(v3_l_v3);
			ulong v3_l_v5 = v3_l_v4 ^ (0x8bf4ecbdb536aee5ul);

			ulong v3_r_v1 = 0xffc6ae6c9725f52cul;
			ulong v3_r_v2 = BinaryPrimitives.ReverseEndianness(v3_r_v1);
			ulong v3_r_v3 = v3_r_v2 * (0x73ee17885c6c83bful);
			ulong v3_r_v4 = v3_r_v3 << (int) (((0xc8b2dab1f73937c3ul) % 64ul) | 1ul);
			ulong v3_r_v5 = Mathematics.RotateRight(v3_r_v4, (int) (((0x4a6c9bfd4766d3a0ul) % 64ul) | 1ul));

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xde1bfe1a387ec3c7ul;
			ulong v4_v2 = v4_v1 & (0x5e825aa5beb48b88ul);
			ulong v4_v3 = v4_v2 - (0xb60aaec343a8ee0aul);
			ulong v4_v4 = ~v4_v3;

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong LoadNtBuildNumber_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x48d19a6629b2b46ul;
			ulong Input_v2 = Input_v1 << (int) (((0x3761dd36176f015ul) % 64ul) | 1ul);
			ulong Input_v3 = ~Input_v2;
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0xbd92c6a8a7c87e9cul) % 64ul) | 1ul));

			ulong v1 = Input - ((Input_v4));
			ulong v1_v1 = 0x35446d9900168abdul;
			ulong v1_v2 = v1_v1 + (0xfee6af2ee60e3b87ul);
			ulong v1_v3 = v1_v2 >> (int) (((0xf7c141b096cb6936ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v1_v5 = BinaryPrimitives.ReverseEndianness(v1_v4);

			ulong v2 = v1 ^ ((v1_v5));

			ulong v2_l_v1 = 0x1e21f960786cb5e1ul;
			ulong v2_l_v2 = v2_l_v1 << (int) (((0x51d4d4001782f838ul) % 64ul) | 1ul);
			ulong v2_l_v3 = v2_l_v2 - (0xe7fc9eba2814b06dul);
			ulong v2_l_v4 = Mathematics.RotateRight(v2_l_v3, (int) (((0x71797ac4c4f7eb30ul) % 64ul) | 1ul));

			ulong v2_r_v1 = 0x85e4ec9fd0a650eul;
			ulong v2_r_v2 = ~v2_r_v1;
			ulong v2_r_v3 = Mathematics.RotateLeft(v2_r_v2, (int) (((0x887ab23831115a57ul) % 64ul) | 1ul));
			ulong v2_r_v4 = v2_r_v3 << (int) (((0x61189cba764a996eul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x5e950ad32afc94fful;
			ulong v3_v2 = v3_v1 - (0xd77b92494fcb16aul);
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((0x8d228109fa764b36ul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 ^ (0xfeca9420363dfe0ful);
			ulong v3_v5 = BinaryPrimitives.ReverseEndianness(v3_v4);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x453eb156650774e1ul;
			ulong v4_v2 = v4_v1 ^ (0x89f07c1b8c0f3277ul);
			ulong v4_v3 = Mathematics.RotateRight(v4_v2, (int) (((0x681d47c59c915ee1ul) % 64ul) | 1ul));
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x203d238429628a6eul;
			ulong v5_l_v2 = v5_l_v1 >> (int) (((0x633f6ab537e2225aul) % 64ul) | 1ul);
			ulong v5_l_v3 = BinaryPrimitives.ReverseEndianness(v5_l_v2);
			ulong v5_l_v4 = v5_l_v3 << (int) (((0x9a4243a353cea15eul) % 64ul) | 1ul);

			ulong v5_r_v1 = 0x345d66da333d8c0bul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0xdbe01ce6e272b32ful) % 64ul) | 1ul));
			ulong v5_r_v3 = v5_r_v2 * (0xc57876531d28cdd6ul);
			ulong v5_r_v4 = v5_r_v3 & (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong v5_r_v5 = Mathematics.RotateLeft(v5_r_v4, (int) (((0x7407226ef2bc511cul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseRotationLeftRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			ulong v6_v1 = 0xe8d6134f1391bb37ul;
			ulong v6_v2 = v6_v1 >> (int) (((0x8a290c0c2cdfaae5ul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 | (0x7a61111b0e6cf43eul);
			ulong v6_v4 = BinaryPrimitives.ReverseEndianness(v6_v3);

			ulong v7 = Mathematics.InverseShiftLeft(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0x15f68424032433b4ul;
			ulong v7_v2 = Mathematics.RotateLeft(v7_v1, (int) (((0x9e0776aba1c3db9cul) % 64ul) | 1ul));
			ulong v7_v3 = v7_v2 * (0xc007fcfd8476aad0ul);
			ulong v7_v4 = Mathematics.RotateRight(v7_v3, (int) (((0x3183bc38d150bfecul) % 64ul) | 1ul));

			ulong v8 = v7 - ((v7_v4));

			return v8;
		}

		public static ulong LoadNtBuildNumber_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x2fc7039409ccce1cul;
			ulong Input_l_v2 = Input_l_v1 + (0x3f37429619ec0bb7ul);
			ulong Input_l_v3 = Input_l_v2 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong Input_l_v4 = Input_l_v3 >> (int) (((0x8110373bd6d2e762ul) % 64ul) | 1ul);

			ulong Input_r_v1 = 0x252fdc65ba78949aul;
			ulong Input_r_v2 = Input_r_v1 - (0x26f61ba84aa8ddebul);
			ulong Input_r_v3 = BinaryPrimitives.ReverseEndianness(Input_r_v2);
			ulong Input_r_v4 = Input_r_v3 * (0x74f79ec33d26e2b0ul);
			ulong Input_r_v5 = Mathematics.RotateRight(Input_r_v4, (int) (((0x2e08c38c01a01b12ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x9683fc4b86f35800ul;
			ulong v1_v2 = v1_v1 - (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v1_v3 = v1_v2 & (0xa998e148c8c8de54ul);
			ulong v1_v4 = v1_v3 >> (int) (((0xec49294eee2bf877ul) % 64ul) | 1ul);
			ulong v1_v5 = v1_v4 << (int) (((0x8af41ca30c999589ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0xfa5dbeeac2ed8936ul;
			ulong v2_l_v2 = Mathematics.RotateRight(v2_l_v1, (int) (((0x8aa4db97493e6a94ul) % 64ul) | 1ul));
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 + (Configuration.NtBuildNumber);

			ulong v2_r_v1 = 0x2202d07ea96a3781ul;
			ulong v2_r_v2 = v2_r_v1 >> (int) (((0x51bdcae0da6fee15ul) % 64ul) | 1ul);
			ulong v2_r_v3 = BinaryPrimitives.ReverseEndianness(v2_r_v2);
			ulong v2_r_v4 = v2_r_v3 << (int) (((0x55f7db9a627b570ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationRightRight(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xeed7b7206f646961ul;
			ulong v3_v2 = v3_v1 | (0x9b1a6c8e357b0627ul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0x6c3d9e7862bb471ul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 * (0x3f73f4689b147ff7ul);
			ulong v3_v5 = v3_v4 + (Configuration.NtMinorVersion);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0xc8c212085ab46feaul;
			ulong v4_v2 = v4_v1 | (0x2d062056f45e7778ul);
			ulong v4_v3 = v4_v2 + (0x92fea6ffa6bf6c50ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x986aaaab3e6593bbul;
			ulong v5_v2 = v5_v1 * (0x1c9980672902e148ul);
			ulong v5_v3 = Mathematics.RotateLeft(v5_v2, (int) (((0xf5c8b53bd49cbedful) % 64ul) | 1ul));
			ulong v5_v4 = ~v5_v3;
			ulong v5_v5 = BinaryPrimitives.ReverseEndianness(v5_v4);

			ulong v6 = v5 + ((v5_v5));

			ulong v6_l_v1 = 0xd8192ea93b0defdful;
			ulong v6_l_v2 = v6_l_v1 ^ (0x70c800e1788ac5e7ul);
			ulong v6_l_v3 = Mathematics.RotateLeft(v6_l_v2, (int) (((0xc68789167b03c6cdul) % 64ul) | 1ul));
			ulong v6_l_v4 = v6_l_v3 - (0xb9427e07514f5caul);
			ulong v6_l_v5 = v6_l_v4 ^ (0xcf5930d8ac087d62ul);

			ulong v6_r_v1 = 0xea8e094af1de6f9ful;
			ulong v6_r_v2 = Mathematics.RotateRight(v6_r_v1, (int) (((0xbc7aba7f628cd8adul) % 64ul) | 1ul));
			ulong v6_r_v3 = v6_r_v2 | (0x3d216dc28242a550ul);
			ulong v6_r_v4 = v6_r_v3 * (0xb5534a591c78b50aul);
			ulong v6_r_v5 = v6_r_v4 >> (int) (((0x744af5a0f5c4353bul) % 64ul) | 1ul);

			ulong v7 = Mathematics.InverseRotationRightRight(v6, (int) (((v6_l_v5 % 64ul) | 1ul)), (int) (((v6_r_v5 % 64ul) | 1ul)));


			ulong v8 = BinaryPrimitives.ReverseEndianness(v7);

			return v8;
		}

		public static ulong LoadNtBuildNumber_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x3b15868e3d8af346ul;
			ulong Input_l_v2 = ~Input_l_v1;
			ulong Input_l_v3 = BinaryPrimitives.ReverseEndianness(Input_l_v2);
			ulong Input_l_v4 = Input_l_v3 - (0xbb3faab77851a9dul);
			ulong Input_l_v5 = Input_l_v4 & (0xdfe444aabdc9b16aul);

			ulong Input_r_v1 = 0xb789f7ffa37df98ul;
			ulong Input_r_v2 = Mathematics.RotateLeft(Input_r_v1, (int) (((0xd71f9a17e41d77f4ul) % 64ul) | 1ul));
			ulong Input_r_v3 = Input_r_v2 << (int) (((0xc358d0fefbd56a49ul) % 64ul) | 1ul);
			ulong Input_r_v4 = Input_r_v3 | (0x3531775a9846d5f8ul);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xf6ce82e626c99065ul;
			ulong v1_v2 = Mathematics.RotateRight(v1_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 - (0x5cca1553a727115ful);

			ulong v2 = v1 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v1_v4 % 64ul) | 1ul))));

			ulong v2_v1 = 0x2968f4865b03d0fdul;
			ulong v2_v2 = v2_v1 << (int) (((0x591bcd4559e6d855ul) % 64ul) | 1ul);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 << (int) (((0x46e6946826982037ul) % 64ul) | 1ul);
			ulong v2_v5 = v2_v4 - (Configuration.NtBuildNumber);

			ulong v3 = v2 ^ ((v2_v5));

			ulong v3_v1 = 0xca2f08d39e5398d1ul;
			ulong v3_v2 = v3_v1 + (0xbebe1da0453e2035ul);
			ulong v3_v3 = v3_v2 ^ (0x81e8bf4f747d44faul);
			ulong v3_v4 = v3_v3 << (int) (((0x337aa69623816420ul) % 64ul) | 1ul);

			ulong v4 = Mathematics.RotateRight(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x7994daf33b9d75b8ul;
			ulong v4_v2 = v4_v1 << (int) (((0x59be9241421a8616ul) % 64ul) | 1ul);
			ulong v4_v3 = v4_v2 | (0x3e5013c067992536ul);
			ulong v4_v4 = v4_v3 & (0x4ca333efcb77119eul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x6f54f7401c704ba2ul;
			ulong v5_v2 = v5_v1 & (0x975e5929225753ecul);
			ulong v5_v3 = v5_v2 + (0x2d5d21a34db2f73ul);
			ulong v5_v4 = v5_v3 >> (int) (((0xe3966e70bc9b3703ul) % 64ul) | 1ul);
			ulong v5_v5 = v5_v4 * (0x66047974880b5f4aul);

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v5_v5 % 64ul) | 1ul))));

			return v6;
		}

		public static ulong UpdateProgramHash_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x4554a81d805e349bul;
			ulong Input_v2 = BinaryPrimitives.ReverseEndianness(Input_v1);
			ulong Input_v3 = Input_v2 | (0xd4a8ca54433ef2b7ul);
			ulong Input_v4 = Input_v3 ^ (0x962cc91c09dbdfa6ul);
			ulong Input_v5 = Input_v4 & (0x8a070911676c6c1aul);

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xe788b560cc84d328ul;
			ulong v1_v2 = v1_v1 - (0x928e8db24bc573f5ul);
			ulong v1_v3 = v1_v2 & (0xe66605ff434b057eul);
			ulong v1_v4 = v1_v3 ^ (0x54df30bce3eb6fdcul);

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x1bbcca3f487f72b5ul;
			ulong v2_v2 = v2_v1 + (0x8bb4dbfbe5e60d47ul);
			ulong v2_v3 = v2_v2 | (0x2c9a0c7a2a0b243ful);
			ulong v2_v4 = v2_v3 * (0x3cd2627662df38caul);
			ulong v2_v5 = v2_v4 >> (int) (((0x88a069f55cc03ef1ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseShiftRight(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x9b4a624e36f42c41ul;
			ulong v3_v2 = Mathematics.RotateRight(v3_v1, (int) (((0xe2ed26078bac9192ul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 | (0xff095db58208d433ul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((0xfa9106d94ee3f1cul) % 64ul) | 1ul));

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0xbb487b66d1636cd6ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = v4_v3 ^ (0xe61a26aeeda905c3ul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x7aaaa80964b747d1ul;
			ulong v5_v2 = v5_v1 | (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v5_v3 = v5_v2 + (0xa0c73bcbecef56b5ul);
			ulong v5_v4 = Mathematics.RotateLeft(v5_v3, (int) (((0xda12f775104f1f5dul) % 64ul) | 1ul));

			ulong v6 = Mathematics.RotateLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			ulong v6_v1 = 0x15e72328960622edul;
			ulong v6_v2 = v6_v1 << (int) (((0x6e8c13ae5114b2aeul) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 - (0x55771acdfeb0b368ul);
			ulong v6_v4 = ~v6_v3;

			ulong v7 = v6 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v6_v4 % 64ul) | 1ul))));

			ulong v7_v1 = 0xa7dbc82ba959c848ul;
			ulong v7_v2 = v7_v1 + (0xa3d89d7c5fe0b936ul);
			ulong v7_v3 = ~v7_v2;
			ulong v7_v4 = v7_v3 * (0x2072b7d0eb81b29aul);

			ulong v8 = v7 + ((v7_v4));

			return v8;
		}

		public static ulong StartHash_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x57a49dc25f2afdf4ul;
			ulong Input_v2 = Input_v1 & (0x359b9d539b65616eul);
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((0xedc4e9c9be4bc296ul) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 ^ (0x9ebcbd5e3bafd877ul);

			ulong v1 = Mathematics.InverseShiftRight(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x2985808649fd920aul;
			ulong v1_v2 = v1_v1 & (0x6e9e0e0952212981ul);
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 + (0x8e2031cab8a46e21ul);

			ulong v2 = v1 ^ ((v1_v4));

			ulong v2_l_v1 = 0xd67aefde64295b4ful;
			ulong v2_l_v2 = v2_l_v1 >> (int) (((0x7650aa4f325aef73ul) % 64ul) | 1ul);
			ulong v2_l_v3 = Mathematics.RotateRight(v2_l_v2, (int) (((0x4a8db0bc726446ul) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 + (0xc4df7dbedcbce250ul);
			ulong v2_l_v5 = v2_l_v4 << (int) (((0x91383b292fa803b8ul) % 64ul) | 1ul);

			ulong v2_r_v1 = 0xec0dd604995b02f4ul;
			ulong v2_r_v2 = v2_r_v1 - (Configuration.NtBuildNumber);
			ulong v2_r_v3 = v2_r_v2 ^ (0xe97806e58e3d7c19ul);
			ulong v2_r_v4 = v2_r_v3 & (Configuration.NtMajorVersion);
			ulong v2_r_v5 = BinaryPrimitives.ReverseEndianness(v2_r_v4);

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xce02bd5b8501b6c8ul;
			ulong v3_v2 = v3_v1 | (0x69266eda822b0fb4ul);
			ulong v3_v3 = v3_v2 << (int) (((0xde5112a4070bc711ul) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((0x4cb9ce828488a39ful) % 64ul) | 1ul));

			ulong v4 = v3 + ((v3_v4));

			ulong v4_l_v1 = 0xdb95416d83e69b8dul;
			ulong v4_l_v2 = v4_l_v1 - (0xcd5bff0aafec4929ul);
			ulong v4_l_v3 = Mathematics.RotateRight(v4_l_v2, (int) (((0x7e46a62ec15e91b1ul) % 64ul) | 1ul));
			ulong v4_l_v4 = v4_l_v3 & (0x974f5d55902249aful);

			ulong v4_r_v1 = 0x8d234a44ada20dadul;
			ulong v4_r_v2 = ~v4_r_v1;
			ulong v4_r_v3 = v4_r_v2 | (0x457e25991930bd25ul);
			ulong v4_r_v4 = v4_r_v3 ^ (Configuration.NtMinorVersion);

			ulong v5 = Mathematics.InverseRotationLeftLeft(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x7567010b47a3b2f2ul;
			ulong v5_l_v2 = v5_l_v1 ^ (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v5_l_v3 = Mathematics.RotateLeft(v5_l_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v5_l_v4 = v5_l_v3 * (0xd36df1799752ae9bul);

			ulong v5_r_v1 = 0x1d697486dcc59400ul;
			ulong v5_r_v2 = v5_r_v1 ^ (0x9edf701c6843c8c8ul);
			ulong v5_r_v3 = v5_r_v2 << (int) (((0x8384506d45c7d8eaul) % 64ul) | 1ul);
			ulong v5_r_v4 = Mathematics.RotateLeft(v5_r_v3, (int) (((0x42259f45f5f12378ul) % 64ul) | 1ul));
			ulong v5_r_v5 = v5_r_v4 | (Configuration.NtBuildNumber);

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong StartHash_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xf8560e4418df7a73ul;
			ulong Input_l_v2 = Input_l_v1 - (0x4bd00d4d9375492ul);
			ulong Input_l_v3 = Input_l_v2 * (0xb70a70eb668ef980ul);
			ulong Input_l_v4 = Input_l_v3 + (0x19f29d66672f95d4ul);
			ulong Input_l_v5 = Input_l_v4 ^ (0x1560342f37ca021ul);

			ulong Input_r_v1 = 0x4a97378f05afb205ul;
			ulong Input_r_v2 = Input_r_v1 * (0xf04eb1cc922f2476ul);
			ulong Input_r_v3 = Input_r_v2 + (0x869615d9ff56c81ful);
			ulong Input_r_v4 = Input_r_v3 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong Input_r_v5 = Input_r_v4 * (0x37c7f554ef9f5acbul);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x78812c3881c357d1ul;
			ulong v1_l_v2 = v1_l_v1 - (0x6dcbec23fc4bb137ul);
			ulong v1_l_v3 = ~v1_l_v2;
			ulong v1_l_v4 = v1_l_v3 - (0xecace90630deb3f4ul);

			ulong v1_r_v1 = 0xba43d200d18d4753ul;
			ulong v1_r_v2 = v1_r_v1 ^ (0xcfb39466917a8dfful);
			ulong v1_r_v3 = v1_r_v2 >> (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v1_r_v4 = v1_r_v3 * (Configuration.NtBuildNumber);
			ulong v1_r_v5 = v1_r_v4 << (int) (((0xd09ac4af2b86aed6ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xa612a6bb5151bbd8ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 << (int) (((0x948064f0767fd317ul) % 64ul) | 1ul);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);
			ulong v2_v5 = v2_v4 >> (int) (((0x2cdad46dc8dd29a8ul) % 64ul) | 1ul);

			ulong v3 = v2 ^ ((v2_v5));

			ulong v3_v1 = 0xa11301dfd64ecd5ful;
			ulong v3_v2 = v3_v1 ^ (0xe23efc1e955625aaul);
			ulong v3_v3 = v3_v2 & (0xe6a99e5cdfa85b21ul);
			ulong v3_v4 = v3_v3 | (0x1a79a23fd69a1ceul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));


			ulong v5 = ~v4;

			ulong v5_l_v1 = 0x18833f38374eb95cul;
			ulong v5_l_v2 = v5_l_v1 + (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong v5_l_v3 = BinaryPrimitives.ReverseEndianness(v5_l_v2);
			ulong v5_l_v4 = v5_l_v3 << (int) (((0x4c72828a3c16f8d7ul) % 64ul) | 1ul);
			ulong v5_l_v5 = v5_l_v4 + (0x7ea170d42957d5d1ul);

			ulong v5_r_v1 = 0x23ebe95f86675631ul;
			ulong v5_r_v2 = Mathematics.RotateLeft(v5_r_v1, (int) (((0xd3e816fc96dafd9cul) % 64ul) | 1ul));
			ulong v5_r_v3 = BinaryPrimitives.ReverseEndianness(v5_r_v2);
			ulong v5_r_v4 = v5_r_v3 >> (int) (((0xa70b0db6b0eb887dul) % 64ul) | 1ul);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0x3533edd4a5eceaa4ul;
			ulong v6_l_v2 = v6_l_v1 ^ (0xb5ab2db8fe766585ul);
			ulong v6_l_v3 = v6_l_v2 * (0x45b5aad9d968b799ul);
			ulong v6_l_v4 = v6_l_v3 | (0x61ad6f560546ae0ul);

			ulong v6_r_v1 = 0x2fdeaa5bada3de2aul;
			ulong v6_r_v2 = v6_r_v1 ^ (0xef38726f0d3251c2ul);
			ulong v6_r_v3 = ~v6_r_v2;
			ulong v6_r_v4 = v6_r_v3 & (Configuration.NtMajorVersion);

			ulong v7 = Mathematics.InverseRotationRightRight(v6, (int) (((v6_l_v4 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0xffe5e120ca024e2ul;
			ulong v7_v2 = v7_v1 << (int) (((Configuration.CpuBrandString2[0] & 0xffffffff) % 64ul) | 1ul);
			ulong v7_v3 = ~v7_v2;
			ulong v7_v4 = BinaryPrimitives.ReverseEndianness(v7_v3);

			ulong v8 = v7 ^ ((v7_v4));

			return v8;
		}

		public static ulong StartHash_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xc33e38b24e58cdcul;
			ulong Input_v2 = ~Input_v1;
			ulong Input_v3 = Input_v2 >> (int) (((0x8876360188d5a9a5ul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 ^ (0x8d6423950bccac8dul);
			ulong Input_v5 = ~Input_v4;

			ulong v1 = Mathematics.RotateRight(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x2cae5a0e1dc46c6eul;
			ulong v1_v2 = v1_v1 & (Configuration.NtMinorVersion);
			ulong v1_v3 = BinaryPrimitives.ReverseEndianness(v1_v2);
			ulong v1_v4 = v1_v3 << (int) (((0xe1844a4562f6ef11ul) % 64ul) | 1ul);

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0x15b594f0156bfcbbul;
			ulong v2_l_v2 = v2_l_v1 * (0x11abcd77e823470dul);
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0x79602bb2fac32857ul) % 64ul) | 1ul));
			ulong v2_l_v4 = ~v2_l_v3;
			ulong v2_l_v5 = v2_l_v4 * (0xc0354fd7f40916eful);

			ulong v2_r_v1 = 0x612d92a14fa8fcbcul;
			ulong v2_r_v2 = ~v2_r_v1;
			ulong v2_r_v3 = v2_r_v2 & (0x3e58108dbb7dddebul);
			ulong v2_r_v4 = v2_r_v3 - (0x2387107c6f73c2d7ul);
			ulong v2_r_v5 = v2_r_v4 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationLeftRight(v2, (int) (((v2_l_v5 % 64ul) | 1ul)), (int) (((v2_r_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0x604f05f3d96dcdb3ul;
			ulong v3_v2 = Mathematics.RotateLeft(v3_v1, (int) (((0xbdaab3ddb0f1e5feul) % 64ul) | 1ul));
			ulong v3_v3 = Mathematics.RotateRight(v3_v2, (int) (((0x7ed303a8ca42b75ul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 >> (int) (((0xf4afc3b5669dd335ul) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 & (0xa9a0232f6fd25dc2ul);

			ulong v4 = Mathematics.RotateLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));


			ulong v5 = BinaryPrimitives.ReverseEndianness(v4);

			ulong v5_l_v1 = 0xf951aec1068e6d49ul;
			ulong v5_l_v2 = v5_l_v1 & (0xe6caed73435d13c1ul);
			ulong v5_l_v3 = v5_l_v2 >> (int) (((0x6b127064847ee1e2ul) % 64ul) | 1ul);
			ulong v5_l_v4 = v5_l_v3 * (0xa0ed286398adc309ul);

			ulong v5_r_v1 = 0x2868acc36c76034cul;
			ulong v5_r_v2 = v5_r_v1 * (0xd3aea1ac3346f520ul);
			ulong v5_r_v3 = v5_r_v2 & (Configuration.NtBuildNumber);
			ulong v5_r_v4 = v5_r_v3 - (0x5581e50339a65db3ul);

			ulong v6 = Mathematics.InverseRotationLeftLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong StartHash_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xadabb8d7ab71a532ul;
			ulong Input_v2 = Input_v1 * (0xd8511c202b865927ul);
			ulong Input_v3 = Input_v2 | (0x69a20dbde9f77921ul);
			ulong Input_v4 = BinaryPrimitives.ReverseEndianness(Input_v3);
			ulong Input_v5 = Input_v4 * (0x1e57f6284ab93d4ful);

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x5ef0416ddc428e34ul;
			ulong v1_v2 = v1_v1 >> (int) (((0x996f00d5ba11dfb0ul) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 - (0x7998a628389abc19ul);
			ulong v1_v4 = Mathematics.RotateLeft(v1_v3, (int) (((0x7016b5bb1bc1bd62ul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 & (0x13d2ceb65c2d658ful);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));


			ulong v3 = BinaryPrimitives.ReverseEndianness(v2);

			ulong v3_l_v1 = 0xafed2653bb58c539ul;
			ulong v3_l_v2 = v3_l_v1 + (0x49512f63495deab8ul);
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 << (int) (((0x795c19c98a2de72ul) % 64ul) | 1ul);

			ulong v3_r_v1 = 0x804bb0276dbffc25ul;
			ulong v3_r_v2 = v3_r_v1 | (0x77a3bb52209d218ful);
			ulong v3_r_v3 = v3_r_v2 - (0xecffad009ee89479ul);
			ulong v3_r_v4 = v3_r_v3 >> (int) (((0x9256fbf418df6fbcul) % 64ul) | 1ul);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x6d622622a66525ddul;
			ulong v4_v2 = v4_v1 * (0x2bdc4ade1a467ebdul);
			ulong v4_v3 = v4_v2 - (0xa91cf1d2cbda5757ul);
			ulong v4_v4 = ~v4_v3;

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0xd32c73931b41e7fdul;
			ulong v5_v2 = v5_v1 + (0x47c5650e182307dul);
			ulong v5_v3 = v5_v2 << (int) (((0xc69a913610deb09bul) % 64ul) | 1ul);
			ulong v5_v4 = v5_v3 * (0xcbd5346f79cfc94dul);
			ulong v5_v5 = v5_v4 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);

			ulong v6 = v5 * Mathematics.InverseMultiplication(((v5_v5 | 1ul)));

			ulong v6_v1 = 0x8e5375e33f6965b7ul;
			ulong v6_v2 = ~v6_v1;
			ulong v6_v3 = v6_v2 + (Configuration.NtMajorVersion);
			ulong v6_v4 = v6_v3 >> (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);

			ulong v7 = Mathematics.RotateRight(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong StartHash_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x4aa0331332693aa3ul;
			ulong Input_v2 = Input_v1 >> (int) (((0x401feb56505da945ul) % 64ul) | 1ul);
			ulong Input_v3 = Input_v2 & (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong Input_v4 = Input_v3 - (0xdce8bb75276e9b29ul);
			ulong Input_v5 = BinaryPrimitives.ReverseEndianness(Input_v4);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0xfc854a3c190ffb74ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = v1_l_v2 * (0x28767ab11c746183ul);
			ulong v1_l_v4 = v1_l_v3 + (0xbce05371b1aef7ecul);

			ulong v1_r_v1 = 0x59916cab76ce3141ul;
			ulong v1_r_v2 = Mathematics.RotateRight(v1_r_v1, (int) (((0x11caf6e3b610cdf7ul) % 64ul) | 1ul));
			ulong v1_r_v3 = BinaryPrimitives.ReverseEndianness(v1_r_v2);
			ulong v1_r_v4 = v1_r_v3 | (0x88633eb12c75c4b9ul);
			ulong v1_r_v5 = ~v1_r_v4;

			ulong v2 = Mathematics.InverseRotationLeftRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x714b64735cf6a5eul;
			ulong v2_v2 = Mathematics.RotateRight(v2_v1, (int) (((0x527419bf9b8a1a99ul) % 64ul) | 1ul));
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 + (0x9f3055f8823a60eeul);

			ulong v3 = v2 - ((v2_v4));


			ulong v4 = ~v3;

			ulong v4_v1 = 0x90d425fdeadb25c4ul;
			ulong v4_v2 = ~v4_v1;
			ulong v4_v3 = v4_v2 ^ (0xb0d8d5cd248ac1c3ul);
			ulong v4_v4 = v4_v3 * (0xd1152fa4c2baac8ul);
			ulong v4_v5 = Mathematics.RotateLeft(v4_v4, (int) (((0x8932107df3cd74a0ul) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x15c19e8efc6a86e0ul;
			ulong v5_l_v2 = v5_l_v1 ^ (0x5b35477316534426ul);
			ulong v5_l_v3 = v5_l_v2 >> (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v5_l_v4 = Mathematics.RotateLeft(v5_l_v3, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v5_l_v5 = BinaryPrimitives.ReverseEndianness(v5_l_v4);

			ulong v5_r_v1 = 0xb7589a8980bf8b6bul;
			ulong v5_r_v2 = ~v5_r_v1;
			ulong v5_r_v3 = v5_r_v2 ^ (0x1e40fda149d23516ul);
			ulong v5_r_v4 = ~v5_r_v3;

			ulong v6 = Mathematics.InverseRotationRightRight(v5, (int) (((v5_l_v5 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));

			ulong v6_l_v1 = 0xa03068508c12d60aul;
			ulong v6_l_v2 = BinaryPrimitives.ReverseEndianness(v6_l_v1);
			ulong v6_l_v3 = v6_l_v2 ^ (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v6_l_v4 = Mathematics.RotateRight(v6_l_v3, (int) (((0x8230cab7c09beed7ul) % 64ul) | 1ul));
			ulong v6_l_v5 = v6_l_v4 & (0x5a087e0478dbbf9cul);

			ulong v6_r_v1 = 0x8c45cb9139afdd44ul;
			ulong v6_r_v2 = v6_r_v1 + (0x3512360ff9e7db4bul);
			ulong v6_r_v3 = v6_r_v2 & (0x714ddb8ae371a669ul);
			ulong v6_r_v4 = v6_r_v3 ^ (0x4b9fcee2e9b645e0ul);

			ulong v7 = Mathematics.InverseRotationRightLeft(v6, (int) (((v6_l_v5 % 64ul) | 1ul)), (int) (((v6_r_v4 % 64ul) | 1ul)));

			return v7;
		}

		public static ulong UpdateHash_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xa21ad3c8e3a4c237ul;
			ulong Input_l_v2 = Input_l_v1 << (int) (((Configuration.CpuBrandString2[1] & 0xffffffff) % 64ul) | 1ul);
			ulong Input_l_v3 = BinaryPrimitives.ReverseEndianness(Input_l_v2);
			ulong Input_l_v4 = Input_l_v3 & (0xa14c4bf6d6d0d5e6ul);
			ulong Input_l_v5 = Input_l_v4 << (int) (((0xc1c4c9b7998f4a72ul) % 64ul) | 1ul);

			ulong Input_r_v1 = 0xd2636e8e5fa1aabaul;
			ulong Input_r_v2 = Input_r_v1 * (0xd1e6403b2dd4a566ul);
			ulong Input_r_v3 = Mathematics.RotateLeft(Input_r_v2, (int) (((0x3385bdd81a97a6d0ul) % 64ul) | 1ul));
			ulong Input_r_v4 = Input_r_v3 * (Configuration.CpuBrandString2[3] & 0xffffffff);
			ulong Input_r_v5 = Input_r_v4 + (Configuration.NtMajorVersion);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0x45e96f8200697999ul;
			ulong v1_l_v2 = v1_l_v1 * (0xeffa969c43fde7f6ul);
			ulong v1_l_v3 = v1_l_v2 + (0x2e48e48496df3126ul);
			ulong v1_l_v4 = Mathematics.RotateLeft(v1_l_v3, (int) (((Configuration.CpuBrandString2[3] & 0xffffffff) % 64ul) | 1ul));

			ulong v1_r_v1 = 0xa9ce9bf6d04ea7f9ul;
			ulong v1_r_v2 = Mathematics.RotateRight(v1_r_v1, (int) (((0xbd74beb18761c79eul) % 64ul) | 1ul));
			ulong v1_r_v3 = v1_r_v2 ^ (0x82a3d706356be543ul);
			ulong v1_r_v4 = v1_r_v3 + (0xc887f531aa800a20ul);
			ulong v1_r_v5 = Mathematics.RotateLeft(v1_r_v4, (int) (((0x6d4963d34089064aul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x80f2fb23e3d1aa74ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = v2_v2 << (int) (((0x425ffc175b63f496ul) % 64ul) | 1ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0xfdedee3643dd9535ul) % 64ul) | 1ul));
			ulong v2_v5 = Mathematics.RotateLeft(v2_v4, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v5 | 1ul)));

			ulong v3_v1 = 0x9406a7916a186a63ul;
			ulong v3_v2 = v3_v1 << (int) (((0x1492553322eab2acul) % 64ul) | 1ul);
			ulong v3_v3 = ~v3_v2;
			ulong v3_v4 = BinaryPrimitives.ReverseEndianness(v3_v3);
			ulong v3_v5 = v3_v4 << (int) (((0x20a7f7e2e9ef406cul) % 64ul) | 1ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0x6268f2640311461dul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 >> (int) (((0xaab98addc1931694ul) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 | (0xf0434707d491f174ul);
			ulong v4_v5 = v4_v4 >> (int) (((0xb0364c9620dcc94ful) % 64ul) | 1ul);

			ulong v5 = v4 ^ ((v4_v5));

			ulong v5_l_v1 = 0x232e0262b9ef7b43ul;
			ulong v5_l_v2 = BinaryPrimitives.ReverseEndianness(v5_l_v1);
			ulong v5_l_v3 = v5_l_v2 & (0xcad288312331018dul);
			ulong v5_l_v4 = v5_l_v3 | (0xca151e80e1c9e3b6ul);

			ulong v5_r_v1 = 0x7f91ec8f444fbc1aul;
			ulong v5_r_v2 = ~v5_r_v1;
			ulong v5_r_v3 = BinaryPrimitives.ReverseEndianness(v5_r_v2);
			ulong v5_r_v4 = v5_r_v3 + (0xec70719a38cfdaedul);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v4 % 64ul) | 1ul)));


			ulong v7 = BinaryPrimitives.ReverseEndianness(v6);

			return v7;
		}

		public static ulong UpdateHash_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xc8ad1fa7ef78bdfcul;
			ulong Input_v2 = Input_v1 - (0xca350024697100cul);
			ulong Input_v3 = Mathematics.RotateRight(Input_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong Input_v4 = BinaryPrimitives.ReverseEndianness(Input_v3);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_v1 = 0x956fd0a41612cb15ul;
			ulong v1_v2 = v1_v1 >> (int) (((0xf1276b74fde9d3e1ul) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 * (0xc70100bbc1429db8ul);
			ulong v1_v4 = v1_v3 - (0xfe7e5f1815fd55e7ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xed38731f7b1f9768ul;
			ulong v2_v2 = BinaryPrimitives.ReverseEndianness(v2_v1);
			ulong v2_v3 = v2_v2 & (0xec780e156144a368ul);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);
			ulong v2_v5 = v2_v4 ^ (0x140cc0c63a71d0aful);

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v5 % 64ul) | 1ul)));

			ulong v3_v1 = 0xfabd7049a822fafaul;
			ulong v3_v2 = Mathematics.RotateRight(v3_v1, (int) (((0x50eab95eb314cc4aul) % 64ul) | 1ul));
			ulong v3_v3 = v3_v2 << (int) (((0xdfa4eaf24bbc4c9aul) % 64ul) | 1ul);
			ulong v3_v4 = Mathematics.RotateLeft(v3_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v3_v5 = Mathematics.RotateRight(v3_v4, (int) (((0xb1fb035af6076c9ful) % 64ul) | 1ul));

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v5 | 1ul)));

			ulong v4_v1 = 0x6680f7ad1d9ff352ul;
			ulong v4_v2 = v4_v1 - (0xa940ff71342b7a01ul);
			ulong v4_v3 = v4_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 * (0xcef8723af731021ul);
			ulong v4_v5 = v4_v4 | (Configuration.NtMajorVersion);

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			return v5;
		}

		public static ulong UpdateHash_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xe0cc5e7a8e94acecul;
			ulong Input_v2 = Input_v1 << (int) (((0x9f5e40eba2a04a7ful) % 64ul) | 1ul);
			ulong Input_v3 = Input_v2 & (0x45f52f8b181248c7ul);
			ulong Input_v4 = Input_v3 * (Configuration.CpuBrandString3[3] & 0xffffffff);

			ulong v1 = Mathematics.RotateLeft(Input, (int) (((Input_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x4f8cae8db12ec9deul;
			ulong v1_v2 = BinaryPrimitives.ReverseEndianness(v1_v1);
			ulong v1_v3 = v1_v2 << (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x3d4be8835eeb4f46ul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 + (0x92c17ce11d9f6e69ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xf21d65542d015101ul;
			ulong v2_v2 = v2_v1 << (int) (((0xf31af02a12824591ul) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 + (0x9e0544034a213c18ul);
			ulong v2_v4 = BinaryPrimitives.ReverseEndianness(v2_v3);
			ulong v2_v5 = v2_v4 >> (int) (((0xb34a6f47a643109aul) % 64ul) | 1ul);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0x29923eb71ecafc73ul;
			ulong v3_v2 = v3_v1 ^ (0xfb0888e952641a2ul);
			ulong v3_v3 = v3_v2 - (0x84a20b939d4447d3ul);
			ulong v3_v4 = v3_v3 ^ (0xa719affb10ba0249ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v3_v4 % 64ul) | 1ul))));

			ulong v4_v1 = 0x2659155c2fef85c5ul;
			ulong v4_v2 = v4_v1 + (0x1faad7714f4db31bul);
			ulong v4_v3 = v4_v2 >> (int) (((0xb4314c7938f8dfedul) % 64ul) | 1ul);
			ulong v4_v4 = v4_v3 & (0x6b92ad03287a15c5ul);

			ulong v5 = v4 + ((v4_v4));

			ulong v5_v1 = 0x7423dea1de12b788ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = ~v5_v2;
			ulong v5_v4 = Mathematics.RotateLeft(v5_v3, (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v5_v4 % 64ul) | 1ul))));

			ulong v6_v1 = 0xe44030f5811a74fbul;
			ulong v6_v2 = v6_v1 >> (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul);
			ulong v6_v3 = v6_v2 * (0x2fef4eedb8875fa5ul);
			ulong v6_v4 = v6_v3 + (0xa2133832d22563feul);
			ulong v6_v5 = Mathematics.RotateLeft(v6_v4, (int) (((0x54c4a6ec6259aea4ul) % 64ul) | 1ul));

			ulong v7 = Mathematics.RotateRight(v6, (int) (((v6_v5 % 64ul) | 1ul)));

			ulong v7_v1 = 0x86bc216a47440206ul;
			ulong v7_v2 = BinaryPrimitives.ReverseEndianness(v7_v1);
			ulong v7_v3 = ~v7_v2;
			ulong v7_v4 = v7_v3 | (0xb04dfd3ff8fa5ba8ul);

			ulong v8 = v7 ^ ((v7_v4));

			return v8;
		}

		public static ulong UpdateHash_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x7239417d6e1de51aul;
			ulong Input_v2 = Input_v1 << (int) (((0xc7f015ea513abc38ul) % 64ul) | 1ul);
			ulong Input_v3 = Input_v2 & (0x38ff615697536a85ul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0xf63159b27ae0c1c4ul) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x8dd8e92ff91059e4ul;
			ulong v1_l_v2 = ~v1_l_v1;
			ulong v1_l_v3 = v1_l_v2 | (0x210591ef93c04257ul);
			ulong v1_l_v4 = v1_l_v3 - (0xc5fbece15b3790a3ul);
			ulong v1_l_v5 = BinaryPrimitives.ReverseEndianness(v1_l_v4);

			ulong v1_r_v1 = 0x353374a64b4728e2ul;
			ulong v1_r_v2 = v1_r_v1 * (Configuration.NtMinorVersion);
			ulong v1_r_v3 = v1_r_v2 + (0x2bd1364877875fb8ul);
			ulong v1_r_v4 = v1_r_v3 - (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v1_r_v5 = ~v1_r_v4;

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x23c30a91fcb629aul;
			ulong v2_v2 = v2_v1 + (0x4bb6fc5bcfd60df4ul);
			ulong v2_v3 = v2_v2 ^ (0xa6c45f277d93001aul);
			ulong v2_v4 = v2_v3 << (int) (((0x3ae353cb3d5c5645ul) % 64ul) | 1ul);
			ulong v2_v5 = v2_v4 ^ (0xc4f130e3a1145568ul);

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v5 | 1ul)));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_l_v1 = 0x758f1f4a74065671ul;
			ulong v4_l_v2 = v4_l_v1 >> (int) (((0xcce4ef097d345163ul) % 64ul) | 1ul);
			ulong v4_l_v3 = ~v4_l_v2;
			ulong v4_l_v4 = v4_l_v3 + (0x28099713223d8cdbul);
			ulong v4_l_v5 = v4_l_v4 - (0x9e9e6a298dd47aa2ul);

			ulong v4_r_v1 = 0x3d4761472a55abc9ul;
			ulong v4_r_v2 = v4_r_v1 | (0x79f6d14be1b4fa5cul);
			ulong v4_r_v3 = v4_r_v2 * (0x1d530a058b1bcd1eul);
			ulong v4_r_v4 = Mathematics.RotateLeft(v4_r_v3, (int) (((Configuration.CpuBrandString2[1] & 0xffffffff) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseRotationLeftRight(v4, (int) (((v4_l_v5 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong UpdateHash_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x12b38e3a25403025ul;
			ulong Input_l_v2 = ~Input_l_v1;
			ulong Input_l_v3 = Input_l_v2 & (0x84b8548438680ee2ul);
			ulong Input_l_v4 = Mathematics.RotateLeft(Input_l_v3, (int) (((0xed2ced7047e1b2eeul) % 64ul) | 1ul));
			ulong Input_l_v5 = Input_l_v4 & (0x5b26a55428c7a0f4ul);

			ulong Input_r_v1 = 0x7b71bda566daded3ul;
			ulong Input_r_v2 = Mathematics.RotateLeft(Input_r_v1, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));
			ulong Input_r_v3 = ~Input_r_v2;
			ulong Input_r_v4 = Input_r_v3 | (0x179ebc1f131f3c7eul);
			ulong Input_r_v5 = Input_r_v4 + (Configuration.NtMajorVersion);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x21794445ba6ceab1ul;
			ulong v1_v2 = v1_v1 + (Configuration.CpuBrandString3[1] & 0xffffffff);
			ulong v1_v3 = v1_v2 * (0x1276094cf0b9dda3ul);
			ulong v1_v4 = v1_v3 + (0x41b9a93a498b4f9dul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xb76b1f57aec0305ful;
			ulong v2_v2 = v2_v1 | (0xfe59f82670ba1d83ul);
			ulong v2_v3 = v2_v2 ^ (0x121fedb14ba530a1ul);
			ulong v2_v4 = Mathematics.RotateLeft(v2_v3, (int) (((0x55dcb3f285b49b1cul) % 64ul) | 1ul));

			ulong v3 = v2 - ((v2_v4));

			ulong v3_l_v1 = 0x96dda583088a352eul;
			ulong v3_l_v2 = BinaryPrimitives.ReverseEndianness(v3_l_v1);
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((0xc428d4cc126f7a7cul) % 64ul) | 1ul));
			ulong v3_l_v4 = Mathematics.RotateRight(v3_l_v3, (int) (((0x694c53ab9ed5bb0aul) % 64ul) | 1ul));
			ulong v3_l_v5 = ~v3_l_v4;

			ulong v3_r_v1 = 0xd86c500445fe8b24ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = v3_r_v2 - (0x76f6faf000c20f19ul);
			ulong v3_r_v4 = v3_r_v3 + (Configuration.NtMajorVersion);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));


			ulong v5 = BinaryPrimitives.ReverseEndianness(v4);

			ulong v5_v1 = 0xf3ae46d965ed06bdul;
			ulong v5_v2 = v5_v1 - (0x1246fe40bdf19ebful);
			ulong v5_v3 = v5_v2 << (int) (((0xc0c5adf77760aa93ul) % 64ul) | 1ul);
			ulong v5_v4 = BinaryPrimitives.ReverseEndianness(v5_v3);
			ulong v5_v5 = v5_v4 << (int) (((0x40a9e5c964dd314dul) % 64ul) | 1ul);

			ulong v6 = v5 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v5_v5 % 64ul) | 1ul))));

			ulong v6_v1 = 0xbace726428e342f3ul;
			ulong v6_v2 = v6_v1 << (int) (((0x3a30d57984ebd582ul) % 64ul) | 1ul);
			ulong v6_v3 = Mathematics.RotateRight(v6_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v6_v4 = ~v6_v3;

			ulong v7 = Mathematics.RotateLeft(v6, (int) (((v6_v4 % 64ul) | 1ul)));

			ulong v7_v1 = 0xdc63f3b53d97d966ul;
			ulong v7_v2 = ~v7_v1;
			ulong v7_v3 = v7_v2 * (0x89274034cce06e99ul);
			ulong v7_v4 = v7_v3 << (int) (((0xa326597194a43b4eul) % 64ul) | 1ul);
			ulong v7_v5 = v7_v4 >> (int) (((0xdc23ba297b2f1e60ul) % 64ul) | 1ul);

			ulong v8 = v7 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v7_v5 % 64ul) | 1ul))));

			return v8;
		}

		public static ulong EndHash_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xb790559de68589a4ul;
			ulong Input_l_v2 = Input_l_v1 << (int) (((0x257ea26ec6649d31ul) % 64ul) | 1ul);
			ulong Input_l_v3 = Mathematics.RotateRight(Input_l_v2, (int) (((0x971435d4cfff06c6ul) % 64ul) | 1ul));
			ulong Input_l_v4 = Mathematics.RotateLeft(Input_l_v3, (int) (((0xfb3bdbfcb3acba94ul) % 64ul) | 1ul));
			ulong Input_l_v5 = Input_l_v4 ^ (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong Input_r_v1 = 0x5e0dab6c7cc3550ul;
			ulong Input_r_v2 = Mathematics.RotateRight(Input_r_v1, (int) (((0x836e2f4e62cf321ul) % 64ul) | 1ul));
			ulong Input_r_v3 = Input_r_v2 | (0x2758dca84a8e4393ul);
			ulong Input_r_v4 = Input_r_v3 << (int) (((0xee2e7a6dcea3369bul) % 64ul) | 1ul);
			ulong Input_r_v5 = Input_r_v4 >> (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_l_v1 = 0xbe3f3fc2e61e62a3ul;
			ulong v1_l_v2 = v1_l_v1 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v1_l_v3 = v1_l_v2 | (0x11da09d9ea595f73ul);
			ulong v1_l_v4 = v1_l_v3 * (Configuration.CpuBrandString1[0] & 0xffffffff);
			ulong v1_l_v5 = v1_l_v4 & (0x64139d889a43e677ul);

			ulong v1_r_v1 = 0x130e118def659327ul;
			ulong v1_r_v2 = v1_r_v1 - (0xced926f771965b8ul);
			ulong v1_r_v3 = v1_r_v2 | (0x854d67522a47b3dcul);
			ulong v1_r_v4 = v1_r_v3 + (Configuration.NtBuildNumber);
			ulong v1_r_v5 = Mathematics.RotateRight(v1_r_v4, (int) (((0x5ce80f29f5d8cba6ul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xb5643ba572d52cc4ul;
			ulong v2_v2 = v2_v1 & (0x4476630d5fa48e67ul);
			ulong v2_v3 = Mathematics.RotateLeft(v2_v2, (int) (((0x16d4213f6a254d2eul) % 64ul) | 1ul));
			ulong v2_v4 = ~v2_v3;

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v4 % 64ul) | 1ul))));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_v1 = 0xa3b35b71d094d62ul;
			ulong v4_v2 = Mathematics.RotateRight(v4_v1, (int) (((0x56cd3ea03e7231dul) % 64ul) | 1ul));
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((0xcee48f9dbfb39269ul) % 64ul) | 1ul));
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);
			ulong v4_v5 = Mathematics.RotateLeft(v4_v4, (int) (((0x8622c83b5046bc1cul) % 64ul) | 1ul));

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v4_v5 % 64ul) | 1ul))));

			ulong v5_v1 = 0x8aa4ec5366cd57a9ul;
			ulong v5_v2 = ~v5_v1;
			ulong v5_v3 = BinaryPrimitives.ReverseEndianness(v5_v2);
			ulong v5_v4 = v5_v3 >> (int) (((0x8f3c76fc22a72976ul) % 64ul) | 1ul);
			ulong v5_v5 = ~v5_v4;

			ulong v6 = v5 ^ ((v5_v5));

			return v6;
		}

		public static ulong EndHash_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xde85a07463b3a5dcul;
			ulong Input_v2 = Mathematics.RotateLeft(Input_v1, (int) (((0x5f02bd549c24338bul) % 64ul) | 1ul));
			ulong Input_v3 = Input_v2 >> (int) (((0x235d5c045a851522ul) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 | (0x751e2eb1a660d19ul);
			ulong Input_v5 = Input_v4 & (0x591a906fb11061b3ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x544cbf8a5b89451ful;
			ulong v1_v2 = v1_v1 + (0x56e3f751a4120d64ul);
			ulong v1_v3 = v1_v2 >> (int) (((0x518a0151611c6b87ul) % 64ul) | 1ul);
			ulong v1_v4 = BinaryPrimitives.ReverseEndianness(v1_v3);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_l_v1 = 0x3d0991689ec99205ul;
			ulong v2_l_v2 = v2_l_v1 + (0x8b8b2310a458fa1eul);
			ulong v2_l_v3 = Mathematics.RotateLeft(v2_l_v2, (int) (((0xb64a6e4958f8ab8cul) % 64ul) | 1ul));
			ulong v2_l_v4 = v2_l_v3 | (0xb0fa9ff722b0d499ul);

			ulong v2_r_v1 = 0x63db18c8b8178b46ul;
			ulong v2_r_v2 = v2_r_v1 >> (int) (((0xadf4733c21cab3c6ul) % 64ul) | 1ul);
			ulong v2_r_v3 = Mathematics.RotateLeft(v2_r_v2, (int) (((0x19deafbc360c592ul) % 64ul) | 1ul));
			ulong v2_r_v4 = v2_r_v3 >> (int) (((0xa0bfa8df4a83552ul) % 64ul) | 1ul);

			ulong v3 = Mathematics.InverseRotationRightLeft(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_l_v1 = 0x5d5d67d921b59dcaul;
			ulong v3_l_v2 = v3_l_v1 ^ (0xf2f935fcab2fa28ul);
			ulong v3_l_v3 = Mathematics.RotateRight(v3_l_v2, (int) (((0x114e01276d3275f2ul) % 64ul) | 1ul));
			ulong v3_l_v4 = Mathematics.RotateLeft(v3_l_v3, (int) (((0x76410e6e36768db9ul) % 64ul) | 1ul));
			ulong v3_l_v5 = v3_l_v4 & (0xfb85bde8a5ddf569ul);

			ulong v3_r_v1 = 0x1ad8ce94772b368cul;
			ulong v3_r_v2 = v3_r_v1 + (0x6a39189d4da49400ul);
			ulong v3_r_v3 = Mathematics.RotateRight(v3_r_v2, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v3_r_v4 = ~v3_r_v3;

			ulong v4 = Mathematics.InverseRotationRightRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x62dfda5ed517adb6ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((0xc88201d3ccfe386dul) % 64ul) | 1ul));
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = v4_v3 - (0x628d2b617dd7e797ul);

			ulong v5 = Mathematics.InverseShiftRight(v4, (int) (((v4_v4 % 64ul) | 1ul)));


			ulong v6 = ~v5;

			ulong v6_v1 = 0x19696712a33b3dbbul;
			ulong v6_v2 = v6_v1 * (0x2d38ad9585f7230dul);
			ulong v6_v3 = v6_v2 - (0x436ae9034e3938adul);
			ulong v6_v4 = Mathematics.RotateLeft(v6_v3, (int) (((0xb77eccfcdbcfba17ul) % 64ul) | 1ul));

			ulong v7 = v6 - ((v6_v4));

			ulong v7_v1 = 0x5fcf325307160afcul;
			ulong v7_v2 = v7_v1 + (0x7c3bc8f5d19e97ccul);
			ulong v7_v3 = v7_v2 - (0x8d354bd283218c0ul);
			ulong v7_v4 = v7_v3 >> (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul);
			ulong v7_v5 = Mathematics.RotateLeft(v7_v4, (int) (((0x8d44cbee31cc16f3ul) % 64ul) | 1ul));

			ulong v8 = v7 + ((v7_v5));

			return v8;
		}

		public static ulong EndHash_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x584422a2950a6495ul;
			ulong Input_l_v2 = Input_l_v1 & (0x9de8da2de94ee28eul);
			ulong Input_l_v3 = Input_l_v2 << (int) (((0x74419e375751dbdcul) % 64ul) | 1ul);
			ulong Input_l_v4 = Input_l_v3 - (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong Input_l_v5 = Input_l_v4 | (0xd9f1875cd4e3eb3aul);

			ulong Input_r_v1 = 0x1bcf3a885dea9ee6ul;
			ulong Input_r_v2 = Input_r_v1 & (0x551ec151b7269050ul);
			ulong Input_r_v3 = Input_r_v2 | (0xb320d41625f35412ul);
			ulong Input_r_v4 = Mathematics.RotateLeft(Input_r_v3, (int) (((0xdef91279d2a44f67ul) % 64ul) | 1ul));
			ulong Input_r_v5 = Mathematics.RotateRight(Input_r_v4, (int) (((0xcdf377f9a7f4d3bcul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x2411c17384474848ul;
			ulong v1_v2 = v1_v1 - (Configuration.CpuBrandString1[2] & 0xffffffff);
			ulong v1_v3 = v1_v2 << (int) (((0xdf67acf63adac9c2ul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 - (0x9f8996674a401160ul);

			ulong v2 = Mathematics.RotateRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x2ab6dfb417fd67f8ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 * (0x66440a43d2a8fful);

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v2_v4 % 64ul) | 1ul))));


			ulong v4 = BinaryPrimitives.ReverseEndianness(v3);

			ulong v4_v1 = 0x74cdb6e96498b660ul;
			ulong v4_v2 = v4_v1 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((0xb9cb5417683d29c6ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 & (0xa2ac70e63d585794ul);

			ulong v5 = v4 + ((v4_v5));

			ulong v5_v1 = 0x3df197cf16dbedb7ul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = v5_v2 + (0x3639025a0749eedul);
			ulong v5_v4 = v5_v3 - (0xa5dad3d79aeff86eul);

			ulong v6 = Mathematics.InverseShiftRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));


			ulong v7 = BinaryPrimitives.ReverseEndianness(v6);

			ulong v7_v1 = 0x93906e297ca00193ul;
			ulong v7_v2 = v7_v1 >> (int) (((0xb2eee7a8ca367fccul) % 64ul) | 1ul);
			ulong v7_v3 = v7_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v7_v4 = v7_v3 & (0x4ec274e3a13353b1ul);

			ulong v8 = Mathematics.InverseShiftRight(v7, (int) (((v7_v4 % 64ul) | 1ul)));

			return v8;
		}

		public static ulong EndHash_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x4b8616faeff247e2ul;
			ulong Input_l_v2 = Input_l_v1 | (0x59df9afd5bde0676ul);
			ulong Input_l_v3 = Input_l_v2 * (0x30fee3c1e7f85e64ul);
			ulong Input_l_v4 = Mathematics.RotateLeft(Input_l_v3, (int) (((0x2a7b7aca1e4d6e12ul) % 64ul) | 1ul));

			ulong Input_r_v1 = 0x33fee5cdba213c05ul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = Mathematics.RotateRight(Input_r_v2, (int) (((0xe3e72df294ce99deul) % 64ul) | 1ul));
			ulong Input_r_v4 = Input_r_v3 | (0xc1cd46c8639cd5e1ul);
			ulong Input_r_v5 = Mathematics.RotateLeft(Input_r_v4, (int) (((0xad9d8d2d76654893ul) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0xa8745cb03de19618ul;
			ulong v1_v2 = ~v1_v1;
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0xbc084d93846773b0ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 - (0xd30941c1ee632039ul);

			ulong v2 = v1 + ((v1_v4));

			ulong v2_v1 = 0xbf2d6535922cf0a8ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = Mathematics.RotateLeft(v2_v2, (int) (((0xdd50fba1cc065be3ul) % 64ul) | 1ul));
			ulong v2_v4 = v2_v3 | (0x54a935dff42b4691ul);
			ulong v2_v5 = Mathematics.RotateLeft(v2_v4, (int) (((0x6bbf062998925bd4ul) % 64ul) | 1ul));

			ulong v3 = v2 * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((v2_v5 % 64ul) | 1ul))));

			ulong v3_v1 = 0xddbd3923c1929052ul;
			ulong v3_v2 = v3_v1 << (int) (((0x1a271bd74c1b1e8bul) % 64ul) | 1ul);
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 + (0xc324c76c766a847cul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v4 | 1ul)));

			ulong v4_v1 = 0x35f9092fc446ed91ul;
			ulong v4_v2 = v4_v1 + (0x1f2aec3b2e3667aeul);
			ulong v4_v3 = v4_v2 * (Configuration.NtBuildNumber);
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((0x8a0568359510e3a8ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 ^ (0x1a6835b12188d525ul);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			ulong v5_l_v1 = 0x643b6233c7277f24ul;
			ulong v5_l_v2 = ~v5_l_v1;
			ulong v5_l_v3 = Mathematics.RotateLeft(v5_l_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v5_l_v4 = v5_l_v3 >> (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);

			ulong v5_r_v1 = 0xbf5756345aeb897eul;
			ulong v5_r_v2 = v5_r_v1 ^ (0xb0b1957b9ca49fdful);
			ulong v5_r_v3 = Mathematics.RotateRight(v5_r_v2, (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul));
			ulong v5_r_v4 = v5_r_v3 | (Configuration.NtMajorVersion);
			ulong v5_r_v5 = BinaryPrimitives.ReverseEndianness(v5_r_v4);

			ulong v6 = Mathematics.InverseRotationRightLeft(v5, (int) (((v5_l_v4 % 64ul) | 1ul)), (int) (((v5_r_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong EndHash_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x5884d65051db3da0ul;
			ulong Input_v2 = Input_v1 | (0xd5f7190dd4ddfbc7ul);
			ulong Input_v3 = Input_v2 & (0xde72f7ec8b61adaaul);
			ulong Input_v4 = Input_v3 + (Configuration.NtMajorVersion);

			ulong v1 = Input ^ ((Input_v4));
			ulong v1_v1 = 0xda43ae5f47b42600ul;
			ulong v1_v2 = v1_v1 >> (int) (((0xbe2f39cf1a52f17ful) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 & (Configuration.NtBuildNumber);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x3aa067f67c25662dul) % 64ul) | 1ul));
			ulong v1_v5 = v1_v4 + (0x57a5c1ca41ceb3b5ul);

			ulong v2 = Mathematics.RotateLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));


			ulong v3 = ~v2;

			ulong v3_l_v1 = 0xcfdec58c44b9d95cul;
			ulong v3_l_v2 = BinaryPrimitives.ReverseEndianness(v3_l_v1);
			ulong v3_l_v3 = v3_l_v2 << (int) (((0x9f5f379b32f00969ul) % 64ul) | 1ul);
			ulong v3_l_v4 = v3_l_v3 * (0x7739cfba13806919ul);

			ulong v3_r_v1 = 0xa87f5168eeef4bf0ul;
			ulong v3_r_v2 = v3_r_v1 << (int) (((0x60e5b07161cfdd51ul) % 64ul) | 1ul);
			ulong v3_r_v3 = v3_r_v2 & (0xb7904663b8c64d30ul);
			ulong v3_r_v4 = v3_r_v3 + (0x9911301cf985c283ul);
			ulong v3_r_v5 = v3_r_v4 ^ (0xdbc673593e8f9060ul);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x7cbe11b5b82e3adbul;
			ulong v4_v2 = v4_v1 & (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v4_v3 = v4_v2 - (0x44dedf9a30cb8feeul);
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((0xd2618fa8c790e290ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 + (Configuration.CpuBrandString1[0] & 0xffffffff);

			ulong v5 = v4 ^ ((v4_v5));

			ulong v5_v1 = 0x2195e95f71f1866bul;
			ulong v5_v2 = v5_v1 >> (int) (((0xd42ea4752c6a5265ul) % 64ul) | 1ul);
			ulong v5_v3 = v5_v2 - (0xb1864670b5866046ul);
			ulong v5_v4 = Mathematics.RotateRight(v5_v3, (int) (((0xe19f9e1a35dd9966ul) % 64ul) | 1ul));

			ulong v6 = Mathematics.InverseShiftRight(v5, (int) (((v5_v4 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong EndHash_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x3e54760c123716b6ul;
			ulong Input_l_v2 = Input_l_v1 | (0xdc18427d7ee1ac34ul);
			ulong Input_l_v3 = Input_l_v2 - (0x374f98332a60f341ul);
			ulong Input_l_v4 = Input_l_v3 | (0x11b5f6151e5090b9ul);
			ulong Input_l_v5 = Input_l_v4 * (0x9ea64e120e1904a3ul);

			ulong Input_r_v1 = 0x5e85fdcfda15fe05ul;
			ulong Input_r_v2 = Input_r_v1 | (0xf350959fd2a16706ul);
			ulong Input_r_v3 = Input_r_v2 + (0xd71f610eccefe547ul);
			ulong Input_r_v4 = Mathematics.RotateRight(Input_r_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong Input_r_v5 = Mathematics.RotateLeft(Input_r_v4, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));

			ulong v1 = Mathematics.InverseRotationLeftLeft(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v5 % 64ul) | 1ul)));
			ulong v1_v1 = 0x1da74917819512c7ul;
			ulong v1_v2 = v1_v1 ^ (0xb283da1f3db142cul);
			ulong v1_v3 = v1_v2 - (0xb7f489760c1df3fcul);
			ulong v1_v4 = Mathematics.RotateRight(v1_v3, (int) (((0x6a588e170daaa515ul) % 64ul) | 1ul));

			ulong v2 = v1 ^ ((v1_v4));

			ulong v2_v1 = 0x1c01b7eb62579e76ul;
			ulong v2_v2 = v2_v1 ^ (0x9726c221bf4a1a7ful);
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 << (int) (((Configuration.CpuBrandString2[2] & 0xffffffff) % 64ul) | 1ul);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));


			ulong v4 = ~v3;

			ulong v4_v1 = 0x8f0be7ea048b3c6bul;
			ulong v4_v2 = v4_v1 * (0x3163470e1693584cul);
			ulong v4_v3 = v4_v2 & (0x49f487d8b956a7e5ul);
			ulong v4_v4 = ~v4_v3;
			ulong v4_v5 = v4_v4 ^ (0xcb0deae65f3d540dul);

			ulong v5 = Mathematics.RotateRight(v4, (int) (((v4_v5 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong EndHash_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x579a262b17369dc5ul;
			ulong Input_v2 = Input_v1 - (Configuration.CpuBrandString3[3] & 0xffffffff);
			ulong Input_v3 = Input_v2 * (0x99194a09ae1b44cbul);
			ulong Input_v4 = Input_v3 + (0x3825e24c004d1ef7ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_v1 = 0xc905d985fea3a190ul;
			ulong v1_v2 = v1_v1 * (0x5c9bd2c461907930ul);
			ulong v1_v3 = v1_v2 << (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong v1_v4 = ~v1_v3;
			ulong v1_v5 = v1_v4 & (0xeff113a501b40481ul);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0x6493619a22ae8378ul;
			ulong v2_v2 = ~v2_v1;
			ulong v2_v3 = BinaryPrimitives.ReverseEndianness(v2_v2);
			ulong v2_v4 = v2_v3 << (int) (((0x5abd43ebba52bffaul) % 64ul) | 1ul);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x402828c71c16c03ful;
			ulong v3_v2 = v3_v1 ^ (0x6ce183ac00726d84ul);
			ulong v3_v3 = v3_v2 | (0xa60d3aabbae89160ul);
			ulong v3_v4 = v3_v3 - (0xb579458b2f88953dul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(((v3_v4 | 1ul)));

			ulong v4_v1 = 0x21c253291a0e44aaul;
			ulong v4_v2 = v4_v1 | (0xb849539b764408abul);
			ulong v4_v3 = v4_v2 * (Configuration.NtBuildNumber);
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((Configuration.CpuBrandString3[3] & 0xffffffff) % 64ul) | 1ul));

			ulong v5 = v4 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v4_v4 % 64ul) | 1ul))));

			ulong v5_v1 = 0x56ff926aa052e9a4ul;
			ulong v5_v2 = ~v5_v1;
			ulong v5_v3 = BinaryPrimitives.ReverseEndianness(v5_v2);
			ulong v5_v4 = v5_v3 * (0x713387069543bb48ul);
			ulong v5_v5 = Mathematics.RotateRight(v5_v4, (int) (((0xe65716640658b152ul) % 64ul) | 1ul));

			ulong v6 = Mathematics.RotateRight(v5, (int) (((v5_v5 % 64ul) | 1ul)));

			return v6;
		}

		public static ulong EndHash_7_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x51abcb56264ff90ul;
			ulong Input_v2 = ~Input_v1;
			ulong Input_v3 = Input_v2 + (Configuration.NtBuildNumber);
			ulong Input_v4 = Mathematics.RotateRight(Input_v3, (int) (((0x932e4da203439118ul) % 64ul) | 1ul));
			ulong Input_v5 = Input_v4 & (0x121c893c56353daful);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_v1 = 0x2e849731fe6829f2ul;
			ulong v1_v2 = v1_v1 << (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 - (0x312e820d1a40e610ul);
			ulong v1_v4 = v1_v3 | (0xe16ed6cae60b8c1eul);
			ulong v1_v5 = v1_v4 & (0xbf80675ded7a2f44ul);

			ulong v2 = v1 - ((v1_v5));

			ulong v2_l_v1 = 0xa191553656fa4e8dul;
			ulong v2_l_v2 = v2_l_v1 * (0x9dc37f01608a163cul);
			ulong v2_l_v3 = BinaryPrimitives.ReverseEndianness(v2_l_v2);
			ulong v2_l_v4 = ~v2_l_v3;

			ulong v2_r_v1 = 0x4d08b6692bdd44aaul;
			ulong v2_r_v2 = v2_r_v1 + (Configuration.NtMajorVersion);
			ulong v2_r_v3 = Mathematics.RotateRight(v2_r_v2, (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul));
			ulong v2_r_v4 = ~v2_r_v3;

			ulong v3 = Mathematics.InverseRotationLeftLeft(v2, (int) (((v2_l_v4 % 64ul) | 1ul)), (int) (((v2_r_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x1e44c4f80bb2d635ul;
			ulong v3_v2 = v3_v1 << (int) (((0x9bb974287b2619acul) % 64ul) | 1ul);
			ulong v3_v3 = BinaryPrimitives.ReverseEndianness(v3_v2);
			ulong v3_v4 = v3_v3 & (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v3_v5 = v3_v4 ^ (0x493772f8e70c16d2ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0x25b20d22c021af90ul;
			ulong v4_v2 = v4_v1 - (Configuration.NtBuildNumber);
			ulong v4_v3 = v4_v2 & (0xdefa9b81e3052d38ul);
			ulong v4_v4 = Mathematics.RotateRight(v4_v3, (int) (((0xe40e1909b602feb2ul) % 64ul) | 1ul));

			ulong v5 = v4 - ((v4_v4));


			ulong v6 = ~v5;

			return v6;
		}

		public static ulong Return_0_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xe8d74c2b86a5e3d4ul;
			ulong Input_l_v2 = Input_l_v1 * (0xe542003d5661aaa8ul);
			ulong Input_l_v3 = Input_l_v2 >> (int) (((0xbc092d2571ac49b1ul) % 64ul) | 1ul);
			ulong Input_l_v4 = Input_l_v3 - (0x7dd9c2c1daf5e34ful);

			ulong Input_r_v1 = 0xcdc6b408fef9d848ul;
			ulong Input_r_v2 = Input_r_v1 + (0x921fb8611d27841eul);
			ulong Input_r_v3 = Input_r_v2 * (0x314fe8740023f196ul);
			ulong Input_r_v4 = Input_r_v3 | (0x7a773983410e620cul);

			ulong v1 = Mathematics.InverseRotationRightLeft(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xbf0cc02f5eaed526ul;
			ulong v1_v2 = v1_v1 ^ (0xa30eaf905ff2e8dul);
			ulong v1_v3 = v1_v2 + (0x39f6b07d02496953ul);
			ulong v1_v4 = BinaryPrimitives.ReverseEndianness(v1_v3);
			ulong v1_v5 = v1_v4 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);

			ulong v2 = Mathematics.InverseShiftLeft(v1, (int) (((v1_v5 % 64ul) | 1ul)));


			ulong v3 = ~v2;

			ulong v3_v1 = 0x345314d32a786d43ul;
			ulong v3_v2 = v3_v1 << (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul);
			ulong v3_v3 = Mathematics.RotateLeft(v3_v2, (int) (((0xdd083c5dcaf1ead5ul) % 64ul) | 1ul));
			ulong v3_v4 = v3_v3 + (0xe3e876146cfaea98ul);
			ulong v3_v5 = v3_v4 - (0x9fbb645094694b10ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0x363172e14700f4fbul;
			ulong v4_v2 = v4_v1 * (0x8f5f40877a271101ul);
			ulong v4_v3 = v4_v2 - (0x8820ed2e92729861ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = v4 * Mathematics.InverseMultiplication(((v4_v4 | 1ul)));

			return v5;
		}

		public static ulong Return_1_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0xa2f50a8b3ed52e4eul;
			ulong Input_l_v2 = Input_l_v1 ^ (0x80226d49a418fb66ul);
			ulong Input_l_v3 = Input_l_v2 | (Configuration.NtBuildNumber);
			ulong Input_l_v4 = Input_l_v3 & (0x219ac2072611de0ul);

			ulong Input_r_v1 = 0x267d5d1d75476a4ul;
			ulong Input_r_v2 = BinaryPrimitives.ReverseEndianness(Input_r_v1);
			ulong Input_r_v3 = Input_r_v2 | (0x73c17b1743b38edbul);
			ulong Input_r_v4 = Input_r_v3 >> (int) (((0xf0f0e279abc169c6ul) % 64ul) | 1ul);

			ulong v1 = Mathematics.InverseRotationRightRight(Input, (int) (((Input_l_v4 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0xcf1265c2cb203713ul;
			ulong v1_v2 = v1_v1 << (int) (((0xed52884d409948dful) % 64ul) | 1ul);
			ulong v1_v3 = v1_v2 >> (int) (((0xcf1f8692f1f0e8aaul) % 64ul) | 1ul);
			ulong v1_v4 = v1_v3 + (0xf9a8d58d409d1933ul);

			ulong v2 = Mathematics.InverseShiftRight(v1, (int) (((v1_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0xddfae01bee19fcdaul;
			ulong v2_v2 = v2_v1 - (0x845ca4e44a47ae5aul);
			ulong v2_v3 = Mathematics.RotateRight(v2_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v2_v4 = Mathematics.RotateLeft(v2_v3, (int) (((0x2710faee1e34e030ul) % 64ul) | 1ul));

			ulong v3 = Mathematics.RotateLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x59ecd0b89892c35ul;
			ulong v3_v2 = v3_v1 + (0xb501436d0910c8bdul);
			ulong v3_v3 = v3_v2 | (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v3_v4 = v3_v3 + (0xd61c1803b5dbdee4ul);

			ulong v4 = Mathematics.InverseShiftLeft(v3, (int) (((v3_v4 % 64ul) | 1ul)));

			ulong v4_v1 = 0x79f20637e18e91c9ul;
			ulong v4_v2 = Mathematics.RotateLeft(v4_v1, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v4_v3 = ~v4_v2;
			ulong v4_v4 = v4_v3 | (0xfadccae420245b44ul);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			return v5;
		}

		public static ulong Return_2_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x69268ef579a1e8b9ul;
			ulong Input_v2 = BinaryPrimitives.ReverseEndianness(Input_v1);
			ulong Input_v3 = Mathematics.RotateLeft(Input_v2, (int) (((0xde0be2338e2ab93eul) % 64ul) | 1ul));
			ulong Input_v4 = Input_v3 + (Configuration.NtMinorVersion);
			ulong Input_v5 = BinaryPrimitives.ReverseEndianness(Input_v4);

			ulong v1 = Input - ((Input_v5));
			ulong v1_l_v1 = 0xeb30155ebbe988d0ul;
			ulong v1_l_v2 = v1_l_v1 + (Configuration.NtMajorVersion);
			ulong v1_l_v3 = v1_l_v2 << (int) (((0xc38a363ea8152633ul) % 64ul) | 1ul);
			ulong v1_l_v4 = v1_l_v3 & (0xfef9319d1f66f4a0ul);

			ulong v1_r_v1 = 0x77a3ec228d2796f9ul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = Mathematics.RotateLeft(v1_r_v2, (int) (((0xd29a764f30b9421dul) % 64ul) | 1ul));
			ulong v1_r_v4 = v1_r_v3 | (0x94a3eba70fba4ec2ul);
			ulong v1_r_v5 = Mathematics.RotateLeft(v1_r_v4, (int) (((0x81e4055b09cfdc33ul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationLeftRight(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xcb6f674130efd006ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((0xb7c547e1dc08d343ul) % 64ul) | 1ul));
			ulong v2_v3 = v2_v2 + (0xffc17cf7d1a0fabeul);
			ulong v2_v4 = v2_v3 & (Configuration.CpuBrandString3[1] & 0xffffffff);

			ulong v3 = Mathematics.RotateRight(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0x93bf324683a26fcdul;
			ulong v3_v2 = v3_v1 | (Configuration.NtMajorVersion);
			ulong v3_v3 = ~v3_v2;
			ulong v3_v4 = v3_v3 + (0x61d1d2b7cb657028ul);

			ulong v4 = v3 ^ ((v3_v4));

			ulong v4_v1 = 0x705e4ef389402395ul;
			ulong v4_v2 = v4_v1 ^ (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong v4_v3 = Mathematics.RotateLeft(v4_v2, (int) (((0xac70fd5f07a17a3ful) % 64ul) | 1ul));
			ulong v4_v4 = v4_v3 ^ (0x315f9841ef2dc486ul);
			ulong v4_v5 = v4_v4 & (0x7e72b288377de795ul);

			ulong v5 = v4 + ((v4_v5));

			ulong v5_v1 = 0xbb972301a012aee2ul;
			ulong v5_v2 = v5_v1 & (0xcc62c81ffe2b9ed1ul);
			ulong v5_v3 = BinaryPrimitives.ReverseEndianness(v5_v2);
			ulong v5_v4 = v5_v3 & (0xbe6cf0f1ec57a4dcul);

			ulong v6 = Mathematics.InverseShiftLeft(v5, (int) (((v5_v4 % 64ul) | 1ul)));


			ulong v7 = ~v6;

			return v7;
		}

		public static ulong Return_3_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0x71a5840f45f6543bul;
			ulong Input_v2 = Input_v1 + (0xe4fa1077cca55c71ul);
			ulong Input_v3 = Input_v2 >> (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul);
			ulong Input_v4 = Input_v3 ^ (0x7b4aae9fca3c7191ul);

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_v1 = 0xd6a8d06d0412ce94ul;
			ulong v1_v2 = v1_v1 + (0xe9e14689f3b1fa40ul);
			ulong v1_v3 = v1_v2 | (Configuration.CpuBrandString2[1] & 0xffffffff);
			ulong v1_v4 = v1_v3 - (Configuration.CpuBrandString1[3] & 0xffffffff);
			ulong v1_v5 = v1_v4 * (0x1ff0ebb075ffd72bul);

			ulong v2 = v1 + ((v1_v5));

			ulong v2_v1 = 0xd3ed06b4fdea71c9ul;
			ulong v2_v2 = v2_v1 << (int) (((Configuration.CpuBrandString3[1] & 0xffffffff) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 + (Configuration.CpuBrandString3[0] & 0xffffffff);
			ulong v2_v4 = ~v2_v3;

			ulong v3 = Mathematics.InverseShiftLeft(v2, (int) (((v2_v4 % 64ul) | 1ul)));

			ulong v3_v1 = 0xb1dbed1d7aedde65ul;
			ulong v3_v2 = ~v3_v1;
			ulong v3_v3 = v3_v2 ^ (0x88ffe528466a6590ul);
			ulong v3_v4 = v3_v3 >> (int) (((0xd2bf7943b8a2251ul) % 64ul) | 1ul);
			ulong v3_v5 = v3_v4 + (0x99bfe819152e605eul);

			ulong v4 = v3 ^ ((v3_v5));

			ulong v4_v1 = 0x3cdcd6d69fd20511ul;
			ulong v4_v2 = v4_v1 | (0x43dd552b694698b2ul);
			ulong v4_v3 = BinaryPrimitives.ReverseEndianness(v4_v2);
			ulong v4_v4 = v4_v3 + (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v4_v5 = v4_v4 ^ (0xbab969d2f349bbc0ul);

			ulong v5 = Mathematics.InverseShiftLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			return v6;
		}

		public static ulong Return_4_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_l_v1 = 0x2db89d37b0939138ul;
			ulong Input_l_v2 = Input_l_v1 ^ (0x4942b72cc965642ul);
			ulong Input_l_v3 = Input_l_v2 | (0xd1b14c9f34175fb2ul);
			ulong Input_l_v4 = Input_l_v3 + (Configuration.NtBuildNumber);
			ulong Input_l_v5 = Mathematics.RotateLeft(Input_l_v4, (int) (((0x7ecc1d79c46216e3ul) % 64ul) | 1ul));

			ulong Input_r_v1 = 0x590643f8186f1925ul;
			ulong Input_r_v2 = ~Input_r_v1;
			ulong Input_r_v3 = Input_r_v2 ^ (0x76ef5e8bd9a1e175ul);
			ulong Input_r_v4 = Input_r_v3 | (0x87a1c3c4db9c46c5ul);

			ulong v1 = Mathematics.InverseRotationLeftRight(Input, (int) (((Input_l_v5 % 64ul) | 1ul)), (int) (((Input_r_v4 % 64ul) | 1ul)));
			ulong v1_v1 = 0x730eac7e5a415dd4ul;
			ulong v1_v2 = v1_v1 >> (int) (((0xe7af9753c1b0252bul) % 64ul) | 1ul);
			ulong v1_v3 = Mathematics.RotateRight(v1_v2, (int) (((0xd7a77805ed222251ul) % 64ul) | 1ul));
			ulong v1_v4 = v1_v3 | (0x36c8e3f1774eacul);
			ulong v1_v5 = v1_v4 + (0xad6b7092c9feb01bul);

			ulong v2 = v1 * Mathematics.InverseMultiplication(((v1_v5 | 1ul)));

			ulong v2_v1 = 0x6982251ccf9ce71dul;
			ulong v2_v2 = v2_v1 - (0xa5adf830e09559bful);
			ulong v2_v3 = v2_v2 >> (int) (((0xf565dc42966d0f39ul) % 64ul) | 1ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((0x97a39fe19596f46eul) % 64ul) | 1ul));
			ulong v2_v5 = BinaryPrimitives.ReverseEndianness(v2_v4);

			ulong v3 = v2 + ((v2_v5));

			ulong v3_v1 = 0x7e99d5b87201a665ul;
			ulong v3_v2 = BinaryPrimitives.ReverseEndianness(v3_v1);
			ulong v3_v3 = v3_v2 ^ (0xecb12ac6541ecc52ul);
			ulong v3_v4 = v3_v3 & (0x8c85056dbc328fbdul);
			ulong v3_v5 = v3_v4 | (0xb0c9580fd2c5c7e9ul);

			ulong v4 = v3 * Mathematics.InverseMultiplication(1ul - (1ul << (int) (((v3_v5 % 64ul) | 1ul))));

			ulong v4_v1 = 0x7f989fa10d091e86ul;
			ulong v4_v2 = v4_v1 & (Configuration.NtMinorVersion);
			ulong v4_v3 = v4_v2 - (0xb6b537beddc8af93ul);
			ulong v4_v4 = Mathematics.RotateLeft(v4_v3, (int) (((0xd17735b36b2aaff5ul) % 64ul) | 1ul));
			ulong v4_v5 = v4_v4 * (0x554a3d62f867c59eul);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v5 % 64ul) | 1ul)));


			ulong v6 = BinaryPrimitives.ReverseEndianness(v5);

			ulong v6_l_v1 = 0xf3648699884d955bul;
			ulong v6_l_v2 = v6_l_v1 | (0xcf67bc6c0becf0d2ul);
			ulong v6_l_v3 = ~v6_l_v2;
			ulong v6_l_v4 = v6_l_v3 << (int) (((0xea308358849722ddul) % 64ul) | 1ul);
			ulong v6_l_v5 = v6_l_v4 - (0x7dc7af7e7f903f7bul);

			ulong v6_r_v1 = 0xbabfc0e64de4ad44ul;
			ulong v6_r_v2 = Mathematics.RotateLeft(v6_r_v1, (int) (((0x44071fd1a6319b15ul) % 64ul) | 1ul));
			ulong v6_r_v3 = v6_r_v2 >> (int) (((0x3547a2589b2c11deul) % 64ul) | 1ul);
			ulong v6_r_v4 = BinaryPrimitives.ReverseEndianness(v6_r_v3);
			ulong v6_r_v5 = v6_r_v4 - (0xd19dda993782c60ful);

			ulong v7 = Mathematics.InverseRotationRightRight(v6, (int) (((v6_l_v5 % 64ul) | 1ul)), (int) (((v6_r_v5 % 64ul) | 1ul)));

			ulong v7_l_v1 = 0x25a4dd49550adbdful;
			ulong v7_l_v2 = BinaryPrimitives.ReverseEndianness(v7_l_v1);
			ulong v7_l_v3 = v7_l_v2 ^ (0x66457582fa956df2ul);
			ulong v7_l_v4 = v7_l_v3 >> (int) (((0xb168e4314293c45dul) % 64ul) | 1ul);
			ulong v7_l_v5 = v7_l_v4 + (0xfae5853f96117043ul);

			ulong v7_r_v1 = 0xee9929892f1a1962ul;
			ulong v7_r_v2 = Mathematics.RotateLeft(v7_r_v1, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong v7_r_v3 = v7_r_v2 | (Configuration.CpuBrandString2[2] & 0xffffffff);
			ulong v7_r_v4 = Mathematics.RotateRight(v7_r_v3, (int) (((0x7f107866030f7506ul) % 64ul) | 1ul));
			ulong v7_r_v5 = v7_r_v4 >> (int) (((Configuration.CpuBrandString1[3] & 0xffffffff) % 64ul) | 1ul);

			ulong v8 = Mathematics.InverseRotationRightLeft(v7, (int) (((v7_l_v5 % 64ul) | 1ul)), (int) (((v7_r_v5 % 64ul) | 1ul)));

			ulong v8_l_v1 = 0x94b05af4ad48474bul;
			ulong v8_l_v2 = v8_l_v1 & (Configuration.NtMinorVersion);
			ulong v8_l_v3 = BinaryPrimitives.ReverseEndianness(v8_l_v2);
			ulong v8_l_v4 = v8_l_v3 << (int) (((0x1caadb779b022652ul) % 64ul) | 1ul);

			ulong v8_r_v1 = 0x889121164dbc897dul;
			ulong v8_r_v2 = v8_r_v1 ^ (0x47cfd02266ce10a9ul);
			ulong v8_r_v3 = v8_r_v2 >> (int) (((0xf47d30535502b0cful) % 64ul) | 1ul);
			ulong v8_r_v4 = v8_r_v3 * (0xc6960dfa2e604d10ul);

			ulong v9 = Mathematics.InverseRotationRightRight(v8, (int) (((v8_l_v4 % 64ul) | 1ul)), (int) (((v8_r_v4 % 64ul) | 1ul)));

			return v9;
		}

		public static ulong Return_5_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xdb4a9906d93162baul;
			ulong Input_v2 = Input_v1 ^ (0xe4930ec32bef6aecul);
			ulong Input_v3 = Input_v2 >> (int) (((0xa575a868ffcc7a3ful) % 64ul) | 1ul);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((Configuration.NtMinorVersion) % 64ul) | 1ul));
			ulong Input_v5 = Mathematics.RotateRight(Input_v4, (int) (((0xf8ed79776d86f96aul) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v5 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x9e8dff1bc435d63aul;
			ulong v1_l_v2 = Mathematics.RotateLeft(v1_l_v1, (int) (((Configuration.CpuBrandString1[0] & 0xffffffff) % 64ul) | 1ul));
			ulong v1_l_v3 = v1_l_v2 + (0x47507fdb0d56f18ful);
			ulong v1_l_v4 = v1_l_v3 * (0xdd86556229d96911ul);
			ulong v1_l_v5 = v1_l_v4 | (Configuration.CpuBrandString2[2] & 0xffffffff);

			ulong v1_r_v1 = 0x58533e8c6cc7332cul;
			ulong v1_r_v2 = BinaryPrimitives.ReverseEndianness(v1_r_v1);
			ulong v1_r_v3 = v1_r_v2 | (0x1d8e7d54961e182aul);
			ulong v1_r_v4 = Mathematics.RotateRight(v1_r_v3, (int) (((0x3c8426fc7897a7b8ul) % 64ul) | 1ul));
			ulong v1_r_v5 = v1_r_v4 | (0x4a375da2a8ad1770ul);

			ulong v2 = Mathematics.InverseRotationRightLeft(v1, (int) (((v1_l_v5 % 64ul) | 1ul)), (int) (((v1_r_v5 % 64ul) | 1ul)));

			ulong v2_v1 = 0xdbbb017a6d03790ful;
			ulong v2_v2 = v2_v1 << (int) (((0x9729c23b53f84eaul) % 64ul) | 1ul);
			ulong v2_v3 = v2_v2 >> (int) (((0xdbb67e74a0aac5d8ul) % 64ul) | 1ul);
			ulong v2_v4 = Mathematics.RotateRight(v2_v3, (int) (((Configuration.CpuBrandString3[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v3 = v2 * Mathematics.InverseMultiplication(((v2_v4 | 1ul)));

			ulong v3_l_v1 = 0x48221722ce9583e3ul;
			ulong v3_l_v2 = Mathematics.RotateRight(v3_l_v1, (int) (((0xce154d8036960621ul) % 64ul) | 1ul));
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((Configuration.NtBuildNumber) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 & (0x36c4f3606f6d812cul);
			ulong v3_l_v5 = v3_l_v4 >> (int) (((0xfae29c902397b956ul) % 64ul) | 1ul);

			ulong v3_r_v1 = 0x93b4326e2bb1744ul;
			ulong v3_r_v2 = ~v3_r_v1;
			ulong v3_r_v3 = v3_r_v2 * (0x1f1b236331d93073ul);
			ulong v3_r_v4 = Mathematics.RotateLeft(v3_r_v3, (int) (((0xa570b858b474d382ul) % 64ul) | 1ul));
			ulong v3_r_v5 = v3_r_v4 << (int) (((0x1c81a5a4c1e562ceul) % 64ul) | 1ul);

			ulong v4 = Mathematics.InverseRotationLeftRight(v3, (int) (((v3_l_v5 % 64ul) | 1ul)), (int) (((v3_r_v5 % 64ul) | 1ul)));

			ulong v4_v1 = 0xe9e7c31516b77b9dul;
			ulong v4_v2 = BinaryPrimitives.ReverseEndianness(v4_v1);
			ulong v4_v3 = v4_v2 + (0x7d964577acc74326ul);
			ulong v4_v4 = BinaryPrimitives.ReverseEndianness(v4_v3);

			ulong v5 = Mathematics.RotateLeft(v4, (int) (((v4_v4 % 64ul) | 1ul)));

			ulong v5_v1 = 0x44fe3b45f349a20dul;
			ulong v5_v2 = BinaryPrimitives.ReverseEndianness(v5_v1);
			ulong v5_v3 = v5_v2 << (int) (((0x47d293d8d812aa8bul) % 64ul) | 1ul);
			ulong v5_v4 = ~v5_v3;
			ulong v5_v5 = Mathematics.RotateLeft(v5_v4, (int) (((Configuration.CpuBrandString1[2] & 0xffffffff) % 64ul) | 1ul));

			ulong v6 = v5 ^ ((v5_v5));

			ulong v6_v1 = 0x710d5e57089ea8dul;
			ulong v6_v2 = Mathematics.RotateRight(v6_v1, (int) (((0xadf1bd18ba0793c4ul) % 64ul) | 1ul));
			ulong v6_v3 = v6_v2 >> (int) (((0x779272dc4eae5f8bul) % 64ul) | 1ul);
			ulong v6_v4 = v6_v3 * (0xf17ef89d5b78b392ul);
			ulong v6_v5 = v6_v4 | (0x27a984d717155037ul);

			ulong v7 = v6 * Mathematics.InverseMultiplication(((v6_v5 | 1ul)));

			return v7;
		}

		public static ulong Return_6_Obf(ulong Input, SystemConfiguration Configuration)
		{

			ulong Input_v1 = 0xd158b63c73c4c75eul;
			ulong Input_v2 = Input_v1 + (Configuration.NtMajorVersion);
			ulong Input_v3 = Input_v2 & (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong Input_v4 = Mathematics.RotateLeft(Input_v3, (int) (((0x50de79e58178c077ul) % 64ul) | 1ul));

			ulong v1 = Input * Mathematics.InverseMultiplication(1ul + (1ul << (int) (((Input_v4 % 64ul) | 1ul))));
			ulong v1_l_v1 = 0x5848e10df7ffe374ul;
			ulong v1_l_v2 = Mathematics.RotateRight(v1_l_v1, (int) (((0x6f9c73cb0746becul) % 64ul) | 1ul));
			ulong v1_l_v3 = v1_l_v2 << (int) (((Configuration.NtMajorVersion) % 64ul) | 1ul);
			ulong v1_l_v4 = BinaryPrimitives.ReverseEndianness(v1_l_v3);

			ulong v1_r_v1 = 0xdce642ad5b0840fbul;
			ulong v1_r_v2 = ~v1_r_v1;
			ulong v1_r_v3 = v1_r_v2 + (Configuration.CpuBrandString1[1] & 0xffffffff);
			ulong v1_r_v4 = Mathematics.RotateLeft(v1_r_v3, (int) (((0x7e6be35133cdbda9ul) % 64ul) | 1ul));

			ulong v2 = Mathematics.InverseRotationLeftLeft(v1, (int) (((v1_l_v4 % 64ul) | 1ul)), (int) (((v1_r_v4 % 64ul) | 1ul)));

			ulong v2_v1 = 0x6dd8d275dcb51de8ul;
			ulong v2_v2 = Mathematics.RotateLeft(v2_v1, (int) (((0xdcae94c9235649ccul) % 64ul) | 1ul));
			ulong v2_v3 = ~v2_v2;
			ulong v2_v4 = v2_v3 >> (int) (((0x5ad0289b5608ae4ful) % 64ul) | 1ul);
			ulong v2_v5 = ~v2_v4;

			ulong v3 = v2 - ((v2_v5));

			ulong v3_l_v1 = 0x350f82df2b53c954ul;
			ulong v3_l_v2 = ~v3_l_v1;
			ulong v3_l_v3 = Mathematics.RotateLeft(v3_l_v2, (int) (((0x978ddadc368d2d0ful) % 64ul) | 1ul));
			ulong v3_l_v4 = v3_l_v3 * (0x94c305d655e84f03ul);

			ulong v3_r_v1 = 0xfa0a7f9822fce3bbul;
			ulong v3_r_v2 = Mathematics.RotateRight(v3_r_v1, (int) (((0xd9dc8ae584de5902ul) % 64ul) | 1ul));
			ulong v3_r_v3 = v3_r_v2 - (0x21079658c7a9a21dul);
			ulong v3_r_v4 = v3_r_v3 + (0xc19d407018f9d75eul);

			ulong v4 = Mathematics.InverseRotationLeftLeft(v3, (int) (((v3_l_v4 % 64ul) | 1ul)), (int) (((v3_r_v4 % 64ul) | 1ul)));

			ulong v4_l_v1 = 0x1beead8110c4f50dul;
			ulong v4_l_v2 = v4_l_v1 * (0x97fd383f4d178a9aul);
			ulong v4_l_v3 = v4_l_v2 << (int) (((0x6a142ff5761bb1ful) % 64ul) | 1ul);
			ulong v4_l_v4 = v4_l_v3 ^ (Configuration.NtMajorVersion);

			ulong v4_r_v1 = 0x536e9546029bb92ul;
			ulong v4_r_v2 = v4_r_v1 & (0x5374f8c2a002c67bul);
			ulong v4_r_v3 = v4_r_v2 >> (int) (((0x3a0a4ab3122d451ul) % 64ul) | 1ul);
			ulong v4_r_v4 = Mathematics.RotateRight(v4_r_v3, (int) (((0x40402a947a7ccd29ul) % 64ul) | 1ul));

			ulong v5 = Mathematics.InverseRotationRightRight(v4, (int) (((v4_l_v4 % 64ul) | 1ul)), (int) (((v4_r_v4 % 64ul) | 1ul)));

			return v5;
		}

	}
}
