//! This is an example of how to statically deobfuscate the Secure Computing input
//! binary. It is incomplete and produces partially incorrect results, but it can
//! be used as a starting point if you want to solve the challenge yourself or are
//! simply interested in how to statically a challenge like this.
//!
//! To run this, you'll need to `cargo install --features code_asm iced-x86` first.
use std::collections::{HashMap, HashSet};

use iced_x86::{Decoder, Encoder, Instruction, Mnemonic, OpKind, Register};

#[derive(Debug, Clone, Copy)]
enum RegValValue {
    Immediate(u64),
    Register(Register),
}

#[derive(Debug, Clone)]
struct RegisterValue {
    value: RegValValue,
    rip: usize,  // rip of instruction that produced this value
    size: usize, // size of the instruction that produced this value
}

impl RegisterValue {
    fn val_imm(&self) -> u64 {
        match self.value {
            RegValValue::Immediate(val) => val,
            _ => panic!("Expected immediate value"),
        }
    }

    fn val_reg(&self) -> Register {
        match self.value {
            RegValValue::Register(reg) => reg,
            _ => panic!("Expected register value"),
        }
    }
}

#[derive(Debug, Clone)]
struct SyscallInvocation {
    register_values: HashMap<Register, RegisterValue>,
    previous_syscall_rip: usize, // rip of the previous syscall instruction
    rip: usize,                  // rip of the syscall instruction
}

const SYSCALL_REGS: &[Register] = &[
    Register::RAX,
    Register::R10,
    Register::RDX,
    Register::R8,
    Register::R9,
    Register::RSP,
];

fn main() {
    let contents = std::fs::read("./dist-19045.exe").unwrap();
    let begin_offset = 0x1000;

    let text_addr_to_offset = |addr: u64| -> usize { addr as usize - 0x400000 };
    let offset_to_text_addr = |offset: usize| -> u64 { offset as u64 + 0x400000 };

    let mut out = contents.clone();
    let nop_value_source = |out: &mut [u8], val: &RegisterValue| {
        let nop = vec![0x90; val.size];
        let offs = text_addr_to_offset(val.rip as u64);
        out[offs..offs + val.size].copy_from_slice(&nop);
    };

    let nop_syscall = |out: &mut [u8], syscall: &SyscallInvocation| {
        let nop = vec![0x90; 2];
        let offs = text_addr_to_offset(syscall.rip as u64);
        out[offs..offs + 2].copy_from_slice(&nop);
    };

    let read_qword = |mut addr: u64| -> u64 {
        addr -= 0xa00000; // remove base address
        addr += 0x496000; // add file offset
        u64::from_le_bytes(
            contents[addr as usize..addr as usize + 8]
                .try_into()
                .unwrap(),
        )
    };

    let mut syscalls = vec![];
    let mut decoder = Decoder::with_ip(64, &contents[begin_offset..], 0x401000u64, 0);

    // step 1: collect syscalls
    let mut reg_values = HashMap::new();
    let mut prev_ip = 0x401000u64 - 2;
    loop {
        let instr = decoder.decode();
        if instr.mnemonic() == Mnemonic::Ret {
            break;
        }

        if instr.mnemonic() == Mnemonic::Syscall {
            assert!(reg_values.contains_key(&Register::RAX)); // syscall number, should always be known
            let syscall_invocation = SyscallInvocation {
                register_values: reg_values.clone(),
                rip: instr.ip() as usize,
                previous_syscall_rip: prev_ip as usize,
            };
            syscalls.push(syscall_invocation);
            reg_values.clear();
            prev_ip = instr.ip();
        }

        if instr.mnemonic() == Mnemonic::Mov
            && instr.op0_kind() == OpKind::Register
            && instr.op1_kind() != OpKind::Memory
            && instr.op1_kind() != OpKind::Register
        {
            // mov reg, imm
            let reg = instr.op0_register();
            if !SYSCALL_REGS.contains(&reg) {
                continue;
            }

            let value = instr.immediate64();
            let register_value = RegisterValue {
                value: RegValValue::Immediate(value),
                rip: instr.ip() as usize,
                size: instr.len(),
            };

            reg_values.insert(reg, register_value);
        }

        if instr.mnemonic() == Mnemonic::Mov
            && instr.op0_kind() == OpKind::Register
            && instr.op1_kind() == OpKind::Register
        {
            // mov reg, reg
            let reg = instr.op0_register();
            if !SYSCALL_REGS.contains(&reg) {
                continue;
            }

            let register_value = RegisterValue {
                value: RegValValue::Register(instr.op1_register()),
                rip: instr.ip() as usize,
                size: instr.len(),
            };

            reg_values.insert(reg, register_value);
        }
    }

    // find continues that are prefixed by read/writes, those load a value
    // from memory into rsp
    let mut rsp_loading_continues = HashSet::new();
    for el in syscalls[..].windows(2) {
        let [prev, cur] = el else { unreachable!() };
        let prev_id = prev.register_values[&Register::RAX].val_imm() & 0x1ff;
        let cur_id = cur.register_values[&Register::RAX].val_imm() & 0x1ff;

        if matches!(prev_id, 0x03f | 0x03a) && cur_id == 0x043 {
            rsp_loading_continues.insert(cur.rip);
        }
    }

    // step 2: apply
    for syscall in syscalls {
        let syscall_no = syscall.register_values[&Register::RAX].val_imm() & 0x1ff;

        match syscall_no {
            0x043 if rsp_loading_continues.contains(&syscall.rip) => {
                // this is an obfuscated load from memory into rsp
                let context_addr = syscall.register_values[&Register::R10].val_imm();
                let rsp_addr = context_addr + 0x98;

                // find out what register it is assigned to afterwards; ida doesn't like rsp assignments very much
                let mut dec = Decoder::with_ip(
                    64,
                    &contents[text_addr_to_offset(syscall.rip as u64 + 2)..],
                    syscall.rip as u64 + 2,
                    0,
                );
                let next = dec.decode();
                assert!(next.mnemonic() == Mnemonic::Mov && next.op1_register() == Register::RSP);

                let mut a = CodeAssembler::new(64).unwrap();
                use iced_x86::code_asm::*;
                a.mov(get_gpr64(next.op0_register()).unwrap(), qword_ptr(rsp_addr))
                    .unwrap();

                // start assembling at the first relevant instruction
                let assembly_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip);

                let assembled = a.assemble(assembly_rip as u64).unwrap();
                out[text_addr_to_offset(assembly_rip as u64)..][..assembled.len()]
                    .copy_from_slice(&assembled);
                out[text_addr_to_offset((assembly_rip + assembled.len()) as u64)
                    ..text_addr_to_offset(syscall.rip as u64 + 2 + next.len() as u64)]
                    .fill(0x90); // nop remainder
            }

            // ZwContinue -> jmp
            0x043 => {
                let context_addr = syscall.register_values[&Register::R10].val_imm();
                let rip_addr = context_addr + 0xf8;
                let new_rip = read_qword(rip_addr);

                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]); // call no
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]); // ctx
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]); // interruptable
                nop_syscall(&mut out, &syscall);

                let old_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip);

                let delta = new_rip as i32 - (old_rip as i32 + 5);

                // place new jump at lowest address
                let lowest_offset = text_addr_to_offset(old_rip as u64);
                out[lowest_offset..][..1].copy_from_slice(&[0xe9]);
                out[lowest_offset + 1..][..4].copy_from_slice(&delta.to_le_bytes());
            }

            // ZwContinueEx -> jz
            0x0a1 => {
                let context_addr = syscall.register_values[&Register::R10].val_imm();
                let rip_addr = context_addr + 0xf8;
                let new_rip = read_qword(rip_addr);

                // scan backwards for a write to rdx + 0x10, that is the condition we want to check
                let mut write_rdx_rip = syscall.rip - 1;
                let mut write_rdx_rip_size = 0;
                let mut write_rdx_rip_reg = Register::None;
                loop {
                    let mut decoder = Decoder::with_ip(
                        64,
                        &contents[text_addr_to_offset(write_rdx_rip as u64)..],
                        write_rdx_rip as u64,
                        0,
                    );
                    let insn = decoder.decode();

                    if insn.mnemonic() == Mnemonic::Mov
                        && insn.op0_kind() == OpKind::Memory
                        && insn.op1_kind() == OpKind::Register
                        && insn.memory_displacement32() == 0x10
                        && insn.memory_base() == Register::RDX
                        && insn.op1_register().size() == 8
                    {
                        write_rdx_rip_size = insn.len();
                        write_rdx_rip_reg = insn.op1_register();
                        break;
                    }

                    write_rdx_rip -= 1;
                }

                // zero out the syscall, register moves, and the write to rdx + 0x10
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]); // call no
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]); // ctx
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]); // interruptable
                nop_syscall(&mut out, &syscall);
                out[text_addr_to_offset(write_rdx_rip as u64)..][..write_rdx_rip_size].fill(0x90);

                let mut start_assembling_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip);

                // assemble test reg, reg
                let mut enc = Encoder::new(64);
                enc.encode(
                    &Instruction::with2(
                        iced_x86::Code::Test_rm64_r64,
                        write_rdx_rip_reg,
                        write_rdx_rip_reg,
                    )
                    .unwrap(),
                    0,
                )
                .unwrap();

                let buffer = enc.take_buffer();
                out[text_addr_to_offset(start_assembling_rip as u64)..][..buffer.len()]
                    .copy_from_slice(&buffer);
                start_assembling_rip += buffer.len();

                let delta = new_rip as i32 - (start_assembling_rip as i32 + 6);
                out[text_addr_to_offset(start_assembling_rip as u64)..][..2]
                    .copy_from_slice(&[0x0f, 0x84]);
                out[text_addr_to_offset(start_assembling_rip as u64) + 2..][..4]
                    .copy_from_slice(&delta.to_le_bytes());
            }

            // ZwCreateSemaphore -> cmp
            0x0c0 => {
                let stack_arguments_addr = syscall.register_values[&Register::RSP].val_imm();
                let fifth_argument_addr = stack_arguments_addr + 0x28;

                // fourth argument is in register, 5th is on the stack
                // scan from last syscall to this one to see if we write a register to rsp+0x28
                // otherwise it's an immediate and already the correct value
                let dec = Decoder::with_ip(
                    64,
                    &contents[text_addr_to_offset(syscall.previous_syscall_rip as u64 + 2)
                        ..text_addr_to_offset(syscall.rip as u64)],
                    syscall.previous_syscall_rip as u64 + 2,
                    0,
                );
                // 5 * 8
                let mut fifth_argument_reg = None;
                for insn in dec {
                    // check for mov [fifth_argument_addr], r64
                    if insn.mnemonic() == Mnemonic::Mov
                        && insn.op0_kind() == OpKind::Memory
                        && insn.op1_kind() == OpKind::Register
                        && insn.memory_base() == Register::RSP
                        && insn.memory_displacement32() == 0x28
                    {
                        fifth_argument_reg = Some(insn.op1_register());
                        break;
                    }
                }

                let fourth_argument = syscall.register_values[&Register::R9].value.clone();
                let fifth_argument = match fifth_argument_reg {
                    Some(reg) => RegValValue::Register(reg),
                    None => RegValValue::Immediate(read_qword(fifth_argument_addr)),
                };

                let mut a = CodeAssembler::new(64).unwrap();
                use iced_x86::code_asm::*;

                // set up an equivalent comparison
                match (fourth_argument, fifth_argument) {
                    (RegValValue::Immediate(_), RegValValue::Immediate(_)) => unreachable!(),
                    (RegValValue::Immediate(left_imm), RegValValue::Register(right_reg)) => {
                        a.xor(rax, rax).unwrap();
                        a.mov(r9, left_imm).unwrap();
                        a.cmp(r9, get_gpr64(right_reg).unwrap()).unwrap();
                        a.setg(al).unwrap(); // nonzero if greater
                    }
                    (RegValValue::Register(left_reg), RegValValue::Immediate(right_imm)) => {
                        a.xor(rax, rax).unwrap();
                        a.mov(r9, right_imm).unwrap();
                        a.cmp(get_gpr64(left_reg).unwrap(), r9).unwrap();
                        a.setg(al).unwrap(); // nonzero if greater
                    }
                    (RegValValue::Register(right_imm), RegValValue::Register(left_reg)) => {
                        a.xor(rax, rax).unwrap();
                        a.cmp(get_gpr64(left_reg).unwrap(), get_gpr64(right_imm).unwrap())
                            .unwrap();
                        a.setg(al).unwrap(); // nonzero if greater
                    }
                }

                // start assembling at the first relevant instruction
                let assembly_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip)
                    .min(syscall.register_values[&Register::R8].rip)
                    .min(syscall.register_values[&Register::R9].rip)
                    .min(syscall.register_values[&Register::RSP].rip);

                let assembled = a.assemble(assembly_rip as u64).unwrap();
                out[text_addr_to_offset(assembly_rip as u64)..][..assembled.len()]
                    .copy_from_slice(&assembled);
                out[text_addr_to_offset((assembly_rip + assembled.len()) as u64)
                    ..text_addr_to_offset(syscall.rip as u64 + 2)]
                    .fill(0x90); // nop remainder
            }

            // ZwCreateIoCompletion -> not interesting, nop out
            0x0ad => {
                nop_syscall(&mut out, &syscall);
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R8]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R9]);
            }

            // ZwCreateWorkerFactory -> zero out handle, use handle as the counter, zero out the rest
            0x0cd => {
                // r10 contains address of handle -> we'll zero it out
                assert!(matches!(
                    syscall.register_values[&Register::R10].value,
                    RegValValue::Immediate(_)
                ));

                nop_syscall(&mut out, &syscall);
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R8]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R9]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RSP]);

                // r10 contains the handle address
                let mut a = CodeAssembler::new(64).unwrap();
                use iced_x86::code_asm::*;
                a.xor(r10, r10).unwrap();
                a.mov(
                    dword_ptr(syscall.register_values[&Register::R10].val_imm()),
                    r10d,
                )
                .unwrap();

                // start assembling at the first relevant instruction
                let assembly_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip)
                    .min(syscall.register_values[&Register::R8].rip)
                    .min(syscall.register_values[&Register::R9].rip)
                    .min(syscall.register_values[&Register::RSP].rip);

                let assembled = a.assemble(assembly_rip as u64).unwrap();
                out[text_addr_to_offset(assembly_rip as u64)..][..assembled.len()]
                    .copy_from_slice(&assembled);
                out[text_addr_to_offset((assembly_rip + assembled.len()) as u64)
                    ..text_addr_to_offset(syscall.rip as u64)]
                    .fill(0x90); // nop remainder
            }

            // NtWriteFile, just keep it
            0x008 => {}

            // NtReadFile, just keep it
            0x006 => {}

            // NtTerminateProcess, just keep it
            0x002c => {
                nop_syscall(&mut out, &syscall);
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]);

                out[text_addr_to_offset(syscall.rip as u64)..][..2].copy_from_slice(&[0xc3, 0x90]);
            }

            // NtReadVirtualMemory, todo
            0x03f => {}

            // NtWriteVirtualMemory, todo
            0x03a => {}

            // NtSetInformationWorkerFactory, perform increment on the handle
            0x1a1 => {
                // value should be an address
                assert!(matches!(
                    syscall.register_values[&Register::R8].value,
                    RegValValue::Immediate(_)
                ));

                assert!(matches!(
                    syscall.register_values[&Register::R10].value,
                    RegValValue::Register(_)
                ));

                nop_syscall(&mut out, &syscall);
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R8]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R9]);

                // r10 contains the handle address
                let mut a = CodeAssembler::new(64).unwrap();
                use iced_x86::code_asm::*;
                a.mov(
                    r10d,
                    dword_ptr(syscall.register_values[&Register::R8].val_imm()),
                )
                .unwrap();
                a.add(
                    iced_reg_to_32_bit(
                        get_gpr64(syscall.register_values[&Register::R10].val_reg()).unwrap(),
                    ),
                    r10d,
                )
                .unwrap();

                // start assembling at the first relevant instruction
                let assembly_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip)
                    .min(syscall.register_values[&Register::R8].rip)
                    .min(syscall.register_values[&Register::R9].rip);

                let assembled = a.assemble(assembly_rip as u64).unwrap();
                out[text_addr_to_offset(assembly_rip as u64)..][..assembled.len()]
                    .copy_from_slice(&assembled);
                out[text_addr_to_offset((assembly_rip + assembled.len()) as u64)
                    ..text_addr_to_offset(syscall.rip as u64)]
                    .fill(0x90); // nop remainder
            }

            // NtQueryInformationWorkerFactory, write total to address
            0x0150 => {
                // address should be an immediate
                assert!(matches!(
                    syscall.register_values[&Register::R8].value,
                    RegValValue::Immediate(_)
                ));

                assert!(matches!(
                    syscall.register_values[&Register::R10].value,
                    RegValValue::Register(_)
                ));

                nop_syscall(&mut out, &syscall);
                nop_value_source(&mut out, &syscall.register_values[&Register::RAX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R10]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RDX]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R8]);
                nop_value_source(&mut out, &syscall.register_values[&Register::R9]);
                nop_value_source(&mut out, &syscall.register_values[&Register::RSP]);

                // r10 contains the handle address
                let mut a = CodeAssembler::new(64).unwrap();
                use iced_x86::code_asm::*;
                a.mov(
                    dword_ptr(syscall.register_values[&Register::R8].val_imm() + 0x20),
                    iced_reg_to_32_bit(
                        get_gpr64(syscall.register_values[&Register::R10].val_reg()).unwrap(),
                    ),
                )
                .unwrap();

                // start assembling at the first relevant instruction
                let assembly_rip = syscall.register_values[&Register::RAX]
                    .rip
                    .min(syscall.register_values[&Register::R10].rip)
                    .min(syscall.register_values[&Register::RDX].rip)
                    .min(syscall.register_values[&Register::R8].rip)
                    .min(syscall.register_values[&Register::R9].rip)
                    .min(syscall.register_values[&Register::RSP].rip);

                let assembled = a.assemble(assembly_rip as u64).unwrap();
                out[text_addr_to_offset(assembly_rip as u64)..][..assembled.len()]
                    .copy_from_slice(&assembled);
                out[text_addr_to_offset((assembly_rip + assembled.len()) as u64)
                    ..text_addr_to_offset(syscall.rip as u64)]
                    .fill(0x90); // nop remainder
            }

            _ => todo!("{:x}", syscall_no),
        }
    }

    std::fs::write("./dist-19045-patched.exe", out).unwrap();
    println!("Hello, world!");
}

fn iced_reg_to_32_bit(reg: iced_x86::code_asm::AsmRegister64) -> iced_x86::code_asm::AsmRegister32 {
    use iced_x86::code_asm::*;
    match reg {
        rax => eax,
        rbx => ebx,
        rcx => ecx,
        rdx => edx,
        rdi => edi,
        rsi => esi,
        rbp => ebp,
        r8 => r8d,
        r9 => r9d,
        r10 => r10d,
        r11 => r11d,
        r12 => r12d,
        r13 => r13d,
        r14 => r14d,
        r15 => r15d,
        _ => unreachable!("where'd this reg come from"),
    }
}
