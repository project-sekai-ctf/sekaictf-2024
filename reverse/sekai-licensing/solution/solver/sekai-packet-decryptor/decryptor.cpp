#include <iostream>
#include <string>
#include <vector>

#include <hydrogen.hpp>

// Streams from buffers.
struct membuf : std::streambuf {
	membuf(char const* base, size_t size) {
		char* p(const_cast<char*>(base));
		this->setg(p, p, p + size);
	}
};

struct imemstream : virtual membuf, std::istream {
	imemstream(char const* base, size_t size)
		: membuf(base, size)
		, std::istream(static_cast<std::streambuf*>(this)) {
	}
};

// Helpers.
std::vector<uint8_t> decode_from_hex(const std::string& hex) {
	std::vector<uint8_t> bytes;
	bytes.reserve(hex.size() / 2);
	for (size_t i = 0; i < hex.size(); i += 2) {
		bytes.push_back(std::stoi(hex.substr(i, 2), nullptr, 16));
	}
	return bytes;
}

std::string encode_to_hex(const std::vector<uint8_t>& bytes) {
	std::string hex;
	hex.reserve(bytes.size() * 2);
	for (const auto& byte : bytes) {
		hex += "0123456789ABCDEF"[byte >> 4];
		hex += "0123456789ABCDEF"[byte & 0x0F];
	}
	return hex;
}

std::string encode_to_hex(const uint8_t* bytes, const size_t size) {
	std::string hex;
	hex.reserve(size * 2);
	for (size_t i = 0; i < size; i++) {
		hex += "0123456789ABCDEF"[bytes[i] >> 4];
		hex += "0123456789ABCDEF"[bytes[i] & 0x0F];
	}
	return hex;
}

// Extracted from challenge.
constexpr uint8_t public_key[] = {
	0x2c, 0x14, 0x16, 0x2c, 0x89, 0x4d, 0xc6, 0xbb, 0xbf, 0xd5, 0xde, 0x37,
	0x9a, 0x9b, 0xce, 0xfe, 0xef, 0xe2, 0x9f, 0xa3, 0x7a, 0xd6, 0xb5, 0xd4,
	0xa3, 0xe9, 0xb4, 0x92, 0x2b, 0xf9, 0x34, 0x03
};

// Decrypt packet.
std::vector<uint8_t> decrypt_packet(const std::vector<uint8_t>& packet, uint8_t key[hydro_kx_SESSIONKEYBYTES]) {
	const auto message_size = packet.size() - hydro_secretbox_HEADERBYTES;
	const auto message = std::make_unique<uint8_t[]>(message_size);
	if (hydro_secretbox_decrypt(message.get(), packet.data(), packet.size(), 0, "SekaiCTF", key) != 0)
		return {};

	return std::vector<uint8_t>(message.get(), message.get() + message_size);
}

// Deobfuscation.
uint64_t reverse_bits(uint64_t x) {
	x = (x << 32) | (x >> 32);
	x = (x & 0x0001FFFF0001FFFFUL) << 15 |
		(x & 0xFFFE0000FFFE0000UL) >> 17;
	auto t = (x ^ (x >> 10)) & 0x003F801F003F801FUL;
	x = (t | (t << 10)) ^ x;
	t = (x ^ (x >> 4)) & 0x0E0384210E038421UL;
	x = (t | (t << 4)) ^ x;
	t = (x ^ (x >> 2)) & 0x2248884222488842UL;
	x = (t | (t << 2)) ^ x;
	return x;
}

uint64_t decode_serial_key_part(uint64_t part, const uint64_t mod_inv_key) {
	part = reverse_bits(part) - 0xcec942ea3098af2cULL;
	part *= mod_inv_key;
	part ^= _rotl64(part, 16) ^ _rotr64(part, 42);
	return part;
}

uint64_t decode_kernel_info_part(uint64_t part, const uint64_t mod_inv_key) {
	part ^= _rotr64(part, 8) ^ _rotl64(part, 14);
	part ^= 0x9dac012771735241ULL;
	part *= mod_inv_key;
	part = reverse_bits(part);
	return part;
}

uint64_t decode_cpuid_part(uint64_t part, const uint64_t mod_inv_key) {
	part += 0x87e3189b7d1f5464ULL;
	part ^= _rotr64(part, 12) ^ _rotl64(part, 36);
	part = reverse_bits(part);
	part *= mod_inv_key;
	return part;
}

int main() {
	hydro_init();

	// Streams extracted from Wireshark.
	auto request_license_key = decode_from_hex("680b70de6138966b734004d89528fdae23337f3d15a4d530b154ca2ec1b555d62057dbf974");
	auto response_license_key = decode_from_hex("6d5391e9c34809c5d9f13bca7a7c606179d40f6b7315964206c3392820e25dcd96746af2fe44f66ffb6e94e5bb58760d140c66de31a2c35e8f4e7abcad7ea4589142f323f15e7210520bc1107febc26fdae919297216e9d407f6593916a474f0e754ff805158ee7e12eff8c96a206fd26ad692ef1a6b88ce25497b38a19e8403bdecc9f0eeff404bde625dedd30181fc9f9949951effb91f5192d2cff0a6ef4f49725423098f3d50941ead26052a31f4c8db230991adb4a9adf5905db468ede614771cbeacb5a9d3cc910c638c6d8a9a918dcee11f7842d6ae31337c2585c9e0031c978928b06412aaf21accb7");

	// Bruteforce seed to find keypair.
	hydro_kx_session_keypair keypair{};
	for (uint8_t seed = 0; seed < 0xff; seed++) {
		hydro_random_reseed_flawed(seed);

		hydro_kx_session_keypair eph_keypair{};
		uint8_t packet1[hydro_kx_N_PACKET1BYTES];
		if (hydro_kx_n_1(&eph_keypair, packet1, nullptr, public_key) != 0) {
			printf("Failed to perform key exchange.\n");
			return -1;
		}

		if (decrypt_packet(request_license_key, eph_keypair.rx).empty())
			continue;

		printf("Found seed! %x\nRX: %s\nTX: %s\n\n", seed, encode_to_hex(eph_keypair.rx, sizeof eph_keypair.rx).c_str(), encode_to_hex(eph_keypair.tx, sizeof eph_keypair.tx).c_str());
		keypair = eph_keypair;
		break;
	}

	// Decrypt packets.
	auto decrypted_request_license_key = decrypt_packet(request_license_key, keypair.rx);
	auto decrypted_response_license_key = decrypt_packet(response_license_key, keypair.tx);

	printf("Decrypted request license key: %s\n", encode_to_hex(decrypted_request_license_key).c_str());
	printf("Decrypted response license key: %s\n\n", encode_to_hex(decrypted_response_license_key).c_str());

	// Parse packet.
	auto stream = imemstream(reinterpret_cast<const char*>(decrypted_response_license_key.data()), decrypted_response_license_key.size());

	uint8_t opcode{};
	stream.read(reinterpret_cast<char*>(&opcode), sizeof opcode);

	uint64_t mod_inv_key{};
	stream.read(reinterpret_cast<char*>(&mod_inv_key), sizeof mod_inv_key);
	mod_inv_key = ~mod_inv_key;

	uint64_t serial_key[4];
	for (auto& part : serial_key) {
		stream.read(reinterpret_cast<char*>(&part), sizeof part);
		part = decode_serial_key_part(part, mod_inv_key);
	}

	uint64_t number_of_processors{};
	stream.read(reinterpret_cast<char*>(&number_of_processors), sizeof number_of_processors);
	number_of_processors = decode_kernel_info_part(number_of_processors, mod_inv_key);

	uint64_t firmware_type{};
	stream.read(reinterpret_cast<char*>(&firmware_type), sizeof firmware_type);
	firmware_type = decode_kernel_info_part(firmware_type, mod_inv_key);

	uint8_t boot_identifier[16];
	stream.read(reinterpret_cast<char*>(&boot_identifier), sizeof boot_identifier);

	uint64_t nt_major_version{};
	stream.read(reinterpret_cast<char*>(&nt_major_version), sizeof nt_major_version);
	nt_major_version = decode_kernel_info_part(nt_major_version, mod_inv_key);

	uint64_t nt_minor_version{};
	stream.read(reinterpret_cast<char*>(&nt_minor_version), sizeof nt_minor_version);
	nt_minor_version = decode_kernel_info_part(nt_minor_version, mod_inv_key);

	uint64_t nt_build_number{};
	stream.read(reinterpret_cast<char*>(&nt_build_number), sizeof nt_build_number);
	nt_build_number = decode_kernel_info_part(nt_build_number, mod_inv_key);

	uint64_t image_base_address{};
	stream.read(reinterpret_cast<char*>(&image_base_address), sizeof image_base_address);
	image_base_address = decode_kernel_info_part(image_base_address, mod_inv_key);

	uint32_t cpuid[12];
	for (uint32_t& id : cpuid) {
		uint64_t part{};
		stream.read(reinterpret_cast<char*>(&part), sizeof part);
		part = decode_cpuid_part(part, mod_inv_key);

		id = static_cast<uint32_t>(part);
	}

	printf("Serial key: %s\n", encode_to_hex(reinterpret_cast<uint8_t*>(serial_key), sizeof serial_key).c_str());
	printf("Number of processors: %llu\n", number_of_processors);
	printf("Firmware type: %llx\n", firmware_type);
	printf("Boot identifier: %s\n", encode_to_hex(boot_identifier, sizeof boot_identifier).c_str());
	printf("NT major version: %llx\n", nt_major_version);
	printf("NT minor version: %llx\n", nt_minor_version);
	printf("NT build number: %llx\n", nt_build_number);
	printf("Image base address: %llx\n", image_base_address);
	printf("CPUID brand string: %s\n", std::string(reinterpret_cast<const char*>(cpuid), sizeof cpuid).c_str());
	return 0;
}
