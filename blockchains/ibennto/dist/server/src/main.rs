use solana_sdk::{
    signature::{Keypair, Signer},
    pubkey::Pubkey,
    instruction::{Instruction, AccountMeta},
    transaction::Transaction,
    commitment_config::CommitmentLevel,
};
use solana_program_test::tokio;
use solana_program::{system_instruction, system_program};
use sol_ctf_framework::ChallengeBuilder;
use solana_banks_interface::BanksTransactionResultWithSimulation;

use tarpc::context;
use base64::prelude::*;

use std::{
    fs,
    io::Write,
    error::Error,
    str::FromStr,
    net::{TcpListener, TcpStream},
};

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let listener = TcpListener::bind("0.0.0.0:1337")?;

    println!("Listening on port 1337 ...");

    for stream in listener.incoming() {
        let stream = stream.unwrap();

        tokio::spawn(async {
            if let Err(err) = handle_connection(stream).await {
                println!("error: {:?}", err);
            }
        });
    }
    Ok(())
}

async fn handle_connection(mut socket: TcpStream) -> Result<(), Box<dyn Error>> {
    let mut builder = ChallengeBuilder::try_from(socket.try_clone().unwrap()).unwrap();

    let pub_str = "psAFcj1WAYRvyVZRsDMeUhV7XQrT4Gfd661Fv5r5GE8";
    let program_id = builder.add_program("./chall/ProjectSEKAI.so", Some(Pubkey::from_str(&pub_str)?));
    let solve_id = builder.input_program()?;

    let mut chall = builder.build().await;

    let payer_keypair = chall.ctx.payer.insecure_clone();
    let payer = payer_keypair.pubkey();

    // create the data account
    let data_account = Keypair::new();

    let constructor_data = vec![0x87, 0x2c, 0xcd, 0xc6, 0x19, 0x01, 0x48, 0xbc];    // discriminator

    // constructor
    chall.run_ixs_full(
        &[Instruction::new_with_bytes(
            program_id,
            &constructor_data,
            vec![
                AccountMeta::new(data_account.pubkey(), true),
                AccountMeta::new(payer, true),
                AccountMeta::new_readonly(system_program::id(), false),
            ],
        )],
        &[&data_account, &payer_keypair],
        &payer
    ).await?;

    let user_keypair = Keypair::new();
    let user = user_keypair.pubkey();

    // user has 1 SOL
    chall.run_ix(system_instruction::transfer(
        &payer,
        &user,
        1_000_000_000,  // 1 SOL
    )).await?;

    // create data account for user program
    let user_data = Keypair::new();

    writeln!(socket, "program: {}", program_id)?;
    writeln!(socket, "data account: {}", data_account.pubkey())?;
    writeln!(socket, "user: {}", user)?;
    writeln!(socket, "user data: {}", user_data.pubkey())?;

    // run solve
    let solve_ix = chall.read_instruction(solve_id)?;

    let mut tx = Transaction::new_with_payer(&[solve_ix], Some(&user));
    tx.sign(&[&user_data, &user_keypair], chall.ctx.last_blockhash);

    let _ = chall.ctx.banks_client
    .process_transaction_with_preflight_and_commitment_and_context(
        context::current(),
        tx,
        CommitmentLevel::default()
    ).await
    .map(|result| match result {
        BanksTransactionResultWithSimulation {
            result: None,
            simulation_details: _,
        } => Ok(()),
        BanksTransactionResultWithSimulation {
            result: Some(Err(err)),
            simulation_details: _,
        } => Err(err),
        BanksTransactionResultWithSimulation {
            result: Some(Ok(_)),
            simulation_details: details,
        } => {
            let mut invoked = false;
            let expected_data = [
                b"\x0e\x1d\xb7G\x1f\xa5k&".as_slice(),  // event:Redeemed
                b"\x04\0\0\0FLAG".as_slice(),           // name (length + data)
                user.to_bytes().as_slice(),
            ].concat();
            let expected_encoded = BASE64_STANDARD.encode(expected_data);
            // retrieve events
            for log in details.unwrap().logs {
                if log.contains(format!("Program {} invoke", pub_str).as_str()) {
                    invoked = true;
                }
                else if log.contains(format!("Program {} success", pub_str).as_str()) {
                    invoked = false;
                }
                if invoked && log.contains("Program data") {
                    let encoded_event = log.split(" ").last().unwrap();
                    if encoded_event == expected_encoded {
                        let flag = fs::read_to_string("flag.txt").unwrap();
                        writeln!(socket, "Congrats! <3").unwrap();
                        writeln!(socket, "{}", flag).unwrap();
                        break;
                    }
                }
            }
            Ok(())
        },
    });

    writeln!(socket, "The event is over ...")?;
    Ok(())
}