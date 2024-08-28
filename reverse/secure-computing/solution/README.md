# Secure Computing - Writeup

### Overview

Secure Computing is is effectively a VM where the opcodes are implemented in the Windows kernel. Opening it shows a large list of only `mov` and `syscall` opcodes, indicating that this is either some weird version of the [movfuscator](https://github.com/xoreaxeaxeax/movfuscator), or something to do with syscalls. Exploring the actual thing quickly shows it's the second ;)

```
.text:0000000000401000 start           proc near
.text:0000000000401000                 mov     rbx, gs:60h
.text:0000000000401009                 mov     rbx, [rbx+20h]
.text:000000000040100D                 mov     rbx, [rbx+28h]
.text:0000000000401011                 mov     rax, 1F5168F5B2838008h
.text:000000000040101B                 mov     rdx, 0
.text:0000000000401025                 mov     r10, rbx
.text:0000000000401028                 mov     r9, 0
.text:0000000000401032                 mov     r8, 0
.text:000000000040103C                 mov     rsp, 0A14EB8h
.text:0000000000401046                 syscall                 ; Low latency system call
.text:0000000000401048                 mov     rsi, rax
.text:000000000040104B                 mov     r12, gs:60h
.text:0000000000401054                 mov     r12, [r12+20h]
.text:0000000000401059                 mov     r12, [r12+20h]
.text:000000000040105E                 mov     rax, 5FDAC94AE10F4006h
.text:0000000000401068                 mov     r10, r12
.text:000000000040106B                 mov     r8, 0
.text:0000000000401075                 mov     rdx, 0
.text:000000000040107F                 mov     r9, 0
.text:0000000000401089                 mov     rsp, 0A14F08h
.text:0000000000401093                 syscall                 ; Low latency system call
.text:0000000000401095                 mov     r14, rax
.text:0000000000401098                 mov     rbx, gs:60h
.text:00000000004010A1                 mov     rbx, [rbx+20h]
.text:00000000004010A5                 mov     rbx, [rbx+28h]
.text:00000000004010A9                 mov     rax, 7D3E837C416D0008h
.text:00000000004010B3                 mov     r10, rbx
.text:00000000004010B6                 mov     rdx, 0
.text:00000000004010C0                 mov     r9, 0
.text:00000000004010CA                 mov     r8, 0
.text:00000000004010D4                 mov     rsp, 0A14F58h
.text:00000000004010DE                 syscall                 ; Low latency system call
```

There were two different intended approaches I designed this challenge for:

- Emulating the binary using a platform like [qiling](https://github.com/qilingframework/qiling) or [unicorn](https://www.unicorn-engine.org/), manually implementing the relevant parts of the syscalls invoked by the program.
- Pattern matching the syscall invocations by disassembling the binary, and reconstructing a lifted/more readable version of the binary.

The first approach would leave you with a dynamic trace of the program; the second would give you a static version of the binary to work with. Both are equally valid approaches, and I think it is very much possible to solve the challenge with either of them.

### Syscalls Used

The VM uses certain syscalls as gadgets to perform computation or control flow. The actual challenge only uses 12 unique syscalls (the syscall ID in `rax` is and-ed with `0x1FF`), which means that manually going through `ntoskrnl.exe` and reversing the relevant syscalls is a straightforward operation.

The following syscalls were used as gadgets:

- `ZwContinue`: unconditional jumps
- `ZwContinueEx`: conditional jumps by writing into a reserved field (the jump fails if reserved field is nonzero)
- `ZwCreateSemaphore`: returns zero (success) if initial <= max, otherwise nonzero (error); combining this with `ZwContinueEx` can allow for conditionals
- `ZwCreateIoCompletion`/`ZwCreateWorkerFactory`: resource allocation/required for addition gadget
- `ZwSetInformationWorkerFactory`/`ZwQueryInformationWorkerFactory`: 32-bit addition gadget (with some caveats)
- `ZwReadVirtualMemory`/`ZwWriteVirtualMemory`: used to read bytes of the input flag in the kernel to avoid triggering hardware breakpoints
- `ZwReadFile`/`ZwWriteFile`: reading from stdin/writing to stdout
- `ZwTerminateProcess`: exiting

### Recovering The General Structure

Dumping out the general CFG of the entire program, and looking at the trace for certain instructions (particularly `ZwReadVirtualMemory`/`ZwWriteVirtualMemory`) reveals that some operation repeats exactly six times. The control flow graph of those sections is roughly identical between them.

Inspecting the control flow of one of those sections reveals that the following pattern of "linear, half-branching, linear, full-branching" generally repeats itself:

![](https://i.imgur.com/6SnAzNu.png)

In total, this pattern seems to repeat 22 times per block. This results in the following pseucodode of the algorithm:

```python
for i in range(6):
    for j in range(22):
        # ...
```

### Identifying Individual Behavior

Drilling down into one of the repeated sections reveals the following pattern repeating itself (this image was taken after static deobfuscation during my own test solve):

![](https://i.imgur.com/CBNfftJ.png)

Translating this into C reveals the following structure:

```c
if (cur > 32767) {
  cur -= 32768;
  out += 64;
}
if (cur > 16383) {
  cur -= 16384;
  out += 32;
}
if (cur > 8191) {
  cur -= 8192;
  out += 16;
}
// ...
if (cur > 1) {
  cur -= 2;
  out += 256;
}
if (cur > 0) {
  cur -= 1;
  out += 128;
}
```

Note that these constants are all powers of two, or powers of two - 1. Looking at its behavior in more detail, we can see that it is starting at the most significant bit (assuming it is a 16-bit value), conditionally doing something, then unsetting that bit. In this particular case, we can deduce that this is performing a rotation operation. In particular, this code implements `rotr(x, 7)`.

This particular pattern of combining power-of-two comparisons with subtractions repeats itself a lot during the execution of the program, because it is one of the only ways to perform bitwise arithmetic using only comparison and addition primitives. This particular style for doing bitwise arithmetic [can also be found in the ELVM standard library](https://github.com/shinh/elvm/blob/master/libc/_builtin.h#L98), for example.

Skipping ahead a bit, we find a part of the control flow that looks very symmetric and branchy:

![](https://i.imgur.com/qTkCJtk.png)

Looking at the code for this, it is clear that we are once again looking at a bitwise operation. The pseudocode looks something like this:

```c
if ( v4 <= 7 )
{
  if ( v51 > 7 )
  {
    v75 += 8;
    LODWORD(qword_A00460) = 65528;
    v50 += 65528;
    dword_A00488 = v50;
    v51 = (unsigned __int16)v50;
  }
}
else
{
  LODWORD(qword_A00460) = 65528;
  v3 += 65528;
  dword_A00488 = v3;
  v4 = (unsigned __int16)v3;
  if ( v51 <= 7 )
  {
    LODWORD(qword_A00460) = 8;
    v75 += 8;
  }
  else
  {
    LODWORD(qword_A00460) = 65528;
    v50 += 65528;
    dword_A00488 = v50;
    v51 = (unsigned __int16)v50;
  }
}
```

Some experimentation reveals that this is once again the same compare-subtract trick to work on individual bits, but now applied to two values at once. In particular, this branch implements the XOR operation.

If we apply our analysis to the entire 22-repeating block identified when we looked at the CFG earlier, we reveal roughly the following sequence of operations:

1. rotate a 16-bit value right by 7
2. add two 16-bit values
3. do something that varies between rounds
4. rotate a 16-bit value left by 2
5. xor two values

While we haven't yet figured out what step 3. does, we can already do some googling to see if this is a known algorithm. Googling "22 rounds add rotate xor" results in https://en.wikipedia.org/wiki/Speck_(cipher), whose round numbers and rotation values for the 32/64 variant are identical to what we have identified here. That also means that step 3. is likely the `x ^= k` operation.

### Identifying Constants

Now that we know that the algorithm simply implements the Speck32/64 cipher on blocks of 4 characters, there are two approaches we could do:

- Figure out some sidechannel that leaks whether a single 4-character Speck encryption resulted in a valid answer, and bruteforce try all 4-character combinations until we find one that succeeds.
- Figure out the constants used in the Speck encryption and simply decrypting the target value for each block.

Both are equally valid approaches, but for completeness we'll do the second one. For that, we need to identify the following:

- Which characters are used in which Speck block.
- Which keys are used for which Speck block.
- Which target values are expected for which Speck block.

For the input characters, we can abuse the fact that the `Zw[Read/Write]VirtualMemory` syscalls are only used for reading flag characters. We can simply log and/or find those calls and see which memory they access. The flag buffer is located at `0xA00000`; we can simply fill it with the values `0x0` through `0x24` (since we have 6 Speck blocks of 4 characters), then inspect the registers after the read to see which two 16-byte values have been read (e.g. `0x0401` represents the 2nd and 4th flag characters). This produces a mapping of how characters are shuffled.

For the target values, we can abuse the fact that comparisons are done through two `ZwCreateSemaphore` calls at the end of each block: `a <= target` and `target <= a`. Logging and/or finding these invocations will easily help us identify the two expected ciphertexts for each of the Speck blocks.

Identifying the Speck keys is the only hard part. Unfortunately, the program seems to have precomputed the round keys (instead of deriving them during encryption) and embedded the actual bit values of the literal within the CFG of the xor operation. This is also why the middle part of each Speck iteration was inconsistent with other iterations: the actual operation is hardcoded to perform an xor with a known, specific value. We can see this in the control flow, where each bit is checked but only in some cases an output bit is set:

```c
  if ( v33 <= 2047 ) // is the 11th bit mot set?
  {
    LODWORD(qword_A00860) = 2048;
    v9 += 2048; // set the bit in the output (i.e., the xor rhs has this bit set)
  }
  else
  {
    LODWORD(qword_A00860) = 2048;
    v33 -= 2048; // unset the bit in the input, don't set it in the output
  }
```

We have two approaches for extracting the round keys:

- Figure it out from the decompilation/cfg/some static analysis
- Simply log the input value and the output value, and xor the two to obtain the round key

Applying either of them results in the 22 round keys, from which you can optionally derive the full set of 64-bit input keys (although this is not really necessary, since round keys are enough to decrypt).

### Obtaining the flag

If you perform all this analysis, you will obtain the following constants:

- Character indices `[5, 9, 6, 15]`, Speck key `[eb10, c518, f25d, 7d26]`, expected ciphertext `[4b13, cf76]`
- Character indices `[3, 10, 12, 7]`, Speck key `[299c, 5008, f7d, d59a]`, expected ciphertext `[dca7, c558]`
- Character indices `[4, 16, 22, 11]`, Speck key `[f32f, 6aef, 4905, 5fe6]`, expected ciphertext `[9f86, 1482]`
- Character indices `[23, 21, 20, 8]`, Speck key `[bd1f, 9cda, 68fc, d0a3]`, expected ciphertext `[89e4, fa2a]`
- Character indices `[13, 1, 2, 17]`, Speck key `[c7f3, 3cb2, 1cfd, c69a]`, expected ciphertext `[47bb, ab57]`
- Character indices `[14, 0, 18, 19]`, Speck key `[7645, 7048, 6bbf, 562a]`, expected ciphertext `[a400, 5f70]`

To obtain the final flag, we simply perform decryption of the expected ciphertext using the key to obtain the final flag:

```
sy5c4ll_m3_m4yb3_2c94234
```

In the same folder as this writeup, you can find the `rewriting-example.rs` Rust file. This contains Rust source code that I used to validate that static deobfuscation/lifting of the input binary was a feasible way to solve the challenge. Note that it is incomplete and may produce weird or incorrect results, but it should show you a rough idea of how one could use static analysis to approach a challenge such as this one.
