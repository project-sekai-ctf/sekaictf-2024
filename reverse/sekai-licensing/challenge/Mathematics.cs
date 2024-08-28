using System.Runtime.CompilerServices;

namespace license_server;

public static class Mathematics
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong RotateLeft(ulong inputInteger, int rotationAmount)
        => (inputInteger << rotationAmount) | (inputInteger >> (64 - rotationAmount));

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong RotateRight(ulong inputInteger, int rotationAmount)
        => (inputInteger >> rotationAmount) | (inputInteger << (64 - rotationAmount));
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static uint RotateLeft32(uint inputInteger, int rotationAmount)
        => (inputInteger << rotationAmount) | (inputInteger >> (32 - rotationAmount));

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static uint RotateRight32(uint inputInteger, int rotationAmount)
        => (inputInteger >> rotationAmount) | (inputInteger << (32 - rotationAmount));
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseMultiplication(ulong inputInteger)
    {
        unchecked
        {
            var output = inputInteger;
            output *= 2 - output * inputInteger;
            output *= 2 - output * inputInteger;
            output *= 2 - output * inputInteger;
            output *= 2 - output * inputInteger;
            output *= 2 - output * inputInteger;
		
            return output;
        }
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseRotationLeftLeft(ulong inputInteger, int amountA, int amountB)
    {
        for (var acc = 0; acc < 5; acc++)
        {
            inputInteger ^= RotateLeft(inputInteger, amountA) ^ RotateLeft(inputInteger, amountB);
            amountA *= 2 % 64;
            amountB *= 2 % 64;
        }

        return inputInteger;
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseRotationRightRight(ulong inputInteger, int amountA, int amountB)
    {
        for (var acc = 0; acc < 5; acc++)
        {
            inputInteger ^= RotateRight(inputInteger, amountA) ^ RotateRight(inputInteger, amountB);
            amountA *= 2 % 64;
            amountB *= 2 % 64;
        }

        return inputInteger;
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseRotationLeftRight(ulong inputInteger, int amountRight, int amountLeft)
    {
        for (var acc = 0; acc < 5; acc++)
        {
            inputInteger ^= RotateLeft(inputInteger, amountRight) ^ RotateRight(inputInteger, amountLeft);
            amountRight *= 2 % 64;
            amountLeft *= 2 % 64;
        }

        return inputInteger;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseRotationRightLeft(ulong inputInteger, int amountRight, int amountLeft)
    {
        for (var acc = 0; acc < 5; acc++)
        {
            inputInteger ^= RotateRight(inputInteger, amountRight) ^ RotateLeft(inputInteger, amountLeft);
            amountRight *= 2 % 64;
            amountLeft *= 2 % 64;
        }

        return inputInteger;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseShiftLeft(ulong inputInteger, int amount)
    {
        while (amount < 64)
        {
            inputInteger ^= inputInteger << amount;
            amount *= 2;
        }

        return inputInteger;
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong InverseShiftRight(ulong inputInteger, int amount)
    {
        while (amount < 64)
        {
            inputInteger ^= inputInteger >> amount;
            amount *= 2;
        }

        return inputInteger;
    }
        
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong ReverseBits(ulong x)
    {
        x = (x << 32) | (x >> 32);   // Swap register halves.
        x = (x & 0x0001FFFF0001FFFFUL) << 15 | // Rotate left
            (x & 0xFFFE0000FFFE0000UL) >> 17;  // 15.
        var t = (x ^ (x >> 10)) & 0x003F801F003F801FUL;
        x = (t | (t << 10)) ^ x;
        t = (x ^ (x >> 4)) & 0x0E0384210E038421UL;
        x = (t | (t << 4)) ^ x;
        t = (x ^ (x >> 2)) & 0x2248884222488842UL;
        x = (t | (t << 2)) ^ x;
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static uint ReverseBits32(uint x)
    {
        x = RotateLeft32(x, 15);  // Rotate left 15.
        var t = (x ^ (x>>10)) & 0x003F801F; x = (t | (t<<10)) ^ x;
        t = (x ^ (x>> 4)) & 0x0E038421; x = (t | (t<< 4)) ^ x;
        t = (x ^ (x>> 2)) & 0x22488842; x = (t | (t<< 2)) ^ x;
        return x;
    }
}