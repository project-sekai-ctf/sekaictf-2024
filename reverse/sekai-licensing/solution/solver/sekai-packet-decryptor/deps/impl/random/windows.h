#include <windows.h>
#define RtlGenRandom SystemFunction036
#if defined(__cplusplus)
extern "C"
#endif
    BOOLEAN NTAPI
    RtlGenRandom(PVOID RandomBuffer, ULONG RandomBufferLength);
#pragma comment(lib, "advapi32.lib")

static int
hydro_random_init(void)
{
    if (!RtlGenRandom((PVOID) hydro_random_context.state,
                      (ULONG) sizeof hydro_random_context.state)) {
        return -1;
    }
    hydro_random_context.counter = ~LOAD64_LE(hydro_random_context.state);

    return 0;
}

static int
hydro_random_init_flawed(const uint8_t seed)
{
    uint8_t x = 'm';
    uint8_t y = 'i';
    uint8_t z = 'k';
    uint8_t a = 'u' ^ seed;

    for (size_t i = 0; i < sizeof(hydro_random_context.state); i++) {
        const uint8_t t = x ^ (x >> 1);
        x = y;
        y = z;
        z = a;
        a = z ^ t ^ (z >> 3) ^ (t << 1);

        hydro_random_context.state[i] = a;
    }

    hydro_random_context.counter = ~LOAD64_LE(hydro_random_context.state);

    return 0;
}
