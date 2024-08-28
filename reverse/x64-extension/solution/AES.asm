; I made changes to this code to adapt to the challenge environment since it's a normal AES encryption but with a slightly different key schedule







global DecryptNix

IV					equ 0x0000
ROUND_KEYS			equ 0x0010
TOTAL_SIZE			equ 0x0100
REAL_SIZE			equ 0x0108
PADDED_BLOCK		equ 0x0110
PAD_SIZE			equ 0x0120
BOUNDARY_ALIGN_ENC	equ	0x0121
BOUNDARY_ALIGN_DEC	equ	0x0108

section .text

Zero:
	push rdx
	mov dl, 0
Zero_Loop:
	mov [rax + rcx - 1], dl
	loop Zero_Loop
	pop rdx
	ret

DecryptNix:
	mov rbx, rsi							;Get second parameter (Text Size)
	mov rax, rdi							;Get first parameter (Plaintext Ptr)
	call AESDecrypt
	ret

AESDecrypt:
	push rbp
	sub rsp, 0x109							;Create room on stack for local vars
	mov rbp, rsp
	and rsp, 0xFFFFFFFFFFFFFFF0				;Round rsp down to nearest 16 byte boundary
	sub rbp, rsp
	mov [rsp + BOUNDARY_ALIGN_DEC], bpl
	mov rbp, rsp
	
	movdqu xmm0, [rdx]						;Grab IV
	movdqa [rbp + IV], xmm0					;Store On Stack
	movdqu xmm0, [rcx]						;Grab Key Pt 1
	movdqa [rbp + ROUND_KEYS], xmm0			;Store On Stack
	movdqu xmm0, [rcx + 0x10]				;Grab Key Pt 2
	movdqa [rbp + ROUND_KEYS + 0x10], xmm0	;Store On Stack
	mov [rbp + TOTAL_SIZE], rbx				;Store Total Size
	
	push rax
	
	lea rax, [rbp + ROUND_KEYS]
	call CreateSchedule

	lea rcx, [rbp + ROUND_KEYS]
	call InvMixColRounds

	pop rax
	mov rbx, [rbp + TOTAL_SIZE]				;Will only store the size
	xor rcx, rcx							;Will keep track of progress through
AESDecrypt_Loop:
	lea rdx, [rbp + ROUND_KEYS]
	movdqu xmm0, [rax + rcx]				;Initial block data
	movdqa xmm8, xmm0						;Store to be next IV
	
	movdqa xmm1, [rdx + 0x80]
	movdqa xmm2, [rdx + 0x90]
	movdqa xmm3, [rdx + 0xA0]
	movdqa xmm4, [rdx + 0xB0]
	movdqa xmm5, [rdx + 0xC0]
	movdqa xmm6, [rdx + 0xD0]
	movdqa xmm7, [rdx + 0xE0]
	pxor xmm0, xmm7
	aesdec xmm0, xmm6
	aesdec xmm0, xmm5
	aesdec xmm0, xmm4
	aesdec xmm0, xmm3
	aesdec xmm0, xmm2
	aesdec xmm0, xmm1
	
	movdqa xmm1, [rdx + 0x10]
	movdqa xmm2, [rdx + 0x20]
	movdqa xmm3, [rdx + 0x30]
	movdqa xmm4, [rdx + 0x40]
	movdqa xmm5, [rdx + 0x50]
	movdqa xmm6, [rdx + 0x60]
	movdqa xmm7, [rdx + 0x70]
	aesdec xmm0, xmm7
	aesdec xmm0, xmm6
	aesdec xmm0, xmm5
	aesdec xmm0, xmm4
	aesdec xmm0, xmm3
	aesdec xmm0, xmm2
	aesdec xmm0, xmm1
	
	movdqa xmm1, [rbp]	 					;Get IV
	movdqa xmm2, [rdx]						;Get Key Pt 1
	aesdeclast xmm0, xmm2
	pxor xmm0, xmm1
	
	lea rdx, [r8 + rcx]						;Current pos in Plaintext
	movdqu [rdx], xmm0						;Store block
	movdqa [rbp + IV], xmm8					;Overwrite IV with original state (for CBC)
	add rcx, 0x10							;Add one block to count
	cmp rcx, rbx
	jne AESDecrypt_Loop
	
	add rdx, 0x0F							;Last byte of plaintext
	xor rbx, rbx
	mov bl, byte [rdx]
	mov rax, [rbp + TOTAL_SIZE]
	sub rax, rbx							;Get Size of message assuming PKCS 7
	
	mov rcx, rbx							;Last byte val = number to check
	lea rdx, [r8 + rax]						;Start of padding
AESDecrypt_CheckPad_Loop:
	cmp byte [rdx + rcx - 1], bl
	jne AESDecrypt_BadPad
	mov byte [rdx + rcx - 1], 0x00			;Zero it (it's padding, we don't need it. Plus helps out good ol' c strings)
	loop AESDecrypt_CheckPad_Loop
	
	push rax
	
	mov rax, rbp							;Position of stack vars
	mov rcx, 0x108							;Size of stack
	call Zero								;Zero it
	
	pop rax
	add rsp, 0x109							;Adjust stack pointer back
	xor rbx, rbx
	mov bl, byte [rbp + BOUNDARY_ALIGN_DEC]
	add rsp, rbx							;Add back boundary offset
	pop rbp

	ret
AESDecrypt_BadPad:
	mov rax, rbp							;Position of stack vars
	mov rcx, 0x108							;Size of stack
	call Zero								;Zero it
	
	mov rax, -1
	add rsp, 0x109							;Adjust stack pointer back
	xor rbx, rbx
	mov bl, byte [rbp + BOUNDARY_ALIGN_DEC]
	add rsp, rbx							;Add back boundary offset
	pop rbp
	
	ret

CreateSchedule:
	movdqa xmm1, [rax]						;Bytes 0-15 of 256bit private key
	movdqa xmm2, [rax + 0x10]				;Bytes 16-31 of 256bit private key
	
	add rax, 0x20							;Roundkeys offset, set to 32 bytes
	aeskeygenassist xmm3, xmm2, 0x13
	call KeyExpansion_1
	movdqa [rax], xmm1						;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0x10], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0x33
	call KeyExpansion_1
	movdqa [rax + 0x20], xmm1				;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0x30], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0x37
	call KeyExpansion_1
	movdqa [rax + 0x40], xmm1				;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0x50], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0xba
	call KeyExpansion_1
	movdqa [rax + 0x60], xmm1				;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0x70], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0xda
	call KeyExpansion_1
	movdqa [rax + 0x80], xmm1				;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0x90], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0x55
	call KeyExpansion_1
	movdqa [rax + 0xA0], xmm1				;Store in schedule
	call KeyExpansion_2
	movdqa [rax + 0xB0], xmm2				;Store in schedule
	aeskeygenassist xmm3, xmm2, 0x66
	call KeyExpansion_1
	movdqa [rax + 0xC0], xmm1				;Store in schedule
	ret

InvMixColRounds:
	movdqa xmm2, [rcx + 0x10]
	movdqa xmm3, [rcx + 0x20]
	movdqa xmm4, [rcx + 0x30]
	movdqa xmm5, [rcx + 0x40]
	movdqa xmm6, [rcx + 0x50]
	movdqa xmm7, [rcx + 0x60]
    aesimc xmm1, xmm2
    movdqa [rcx + 0x10], xmm1
    aesimc xmm1, xmm3
    movdqa [rcx + 0x20], xmm1
    aesimc xmm1, xmm4
    movdqa [rcx + 0x30], xmm1
    aesimc xmm1, xmm5
    movdqa [rcx + 0x40], xmm1
    aesimc xmm1, xmm6
    movdqa [rcx + 0x50], xmm1
    aesimc xmm1, xmm7
    movdqa [rcx + 0x60], xmm1
	
	movdqa xmm2, [rcx + 0x70]
	movdqa xmm3, [rcx + 0x80]
	movdqa xmm4, [rcx + 0x90]
	movdqa xmm5, [rcx + 0xA0]
	movdqa xmm6, [rcx + 0xB0]
	movdqa xmm7, [rcx + 0xC0]
    aesimc xmm1, xmm2
    movdqa [rcx + 0x70], xmm1
    aesimc xmm1, xmm3
    movdqa [rcx + 0x80], xmm1
    aesimc xmm1, xmm4
    movdqa [rcx + 0x90], xmm1
    aesimc xmm1, xmm5
    movdqa [rcx + 0xA0], xmm1
    aesimc xmm1, xmm6
    movdqa [rcx + 0xB0], xmm1
    aesimc xmm1, xmm7
    movdqa [rcx + 0xC0], xmm1
	
	movdqa xmm2, [rcx + 0xD0]
    aesimc xmm1, xmm2
    movdqa [rcx + 0xD0], xmm1
	ret 
	
KeyExpansion_1:
	pshufd xmm3, xmm3, 0xFF
	vpslldq xmm4, xmm1, 4
	pxor xmm1, xmm4
	pslldq xmm4, 4
	pxor xmm1, xmm4
	pslldq xmm4, 4
	pxor xmm1, xmm4
	pxor xmm1, xmm3
	ret

KeyExpansion_2:
	aeskeygenassist xmm4, xmm1, 0x00
	pshufd xmm3, xmm4, 0xaa
	vpslldq xmm4, xmm2, 4
	pxor xmm2, xmm4
	pslldq xmm4, 4
	pxor xmm2, xmm4
	pslldq xmm4, 4
	pxor xmm2, xmm4
	pxor xmm2, xmm3
	ret
