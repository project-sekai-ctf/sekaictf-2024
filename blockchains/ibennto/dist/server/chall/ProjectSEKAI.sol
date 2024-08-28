import "libraries/minimum_balance.sol";
import "solana";

@program_id("psAFcj1WAYRvyVZRsDMeUhV7XQrT4Gfd661Fv5r5GE8")
contract ProjectSEKAI {

    address constant systemAddress = address"11111111111111111111111111111111";
    bytes constant LIVE_BONUS_SEED = "LiveBonus";
    bytes constant EVENT_INFO_SEED = "EventInfo";

    // part of the system instructions
    enum Instruction {
        CreateAccount,
        Assign,
        Transfer
    }

    struct Item {
        string name;
        uint64 price;
    }

    struct LiveBonus {
        uint64 lastClaimedAt;
        uint64 currentValue;
    }

    struct EventInfo {
        uint64 badges;
    }

    event Redeemed (string name, address redeemer);

    Item[] public itemsInShop;

    @payer(payer)
    @space(256)
    constructor() {
        itemsInShop.push(Item("Hatsune Miku", 3108));
        itemsInShop.push(Item("FLAG", 18446744073709551615));
        itemsInShop.push(Item("Live Bonus Drink", 100));
    }

    function create_account(
        address from,
        address to,
        uint64 lamports,
        uint64 space,
        address owner,
        bytes[] memory seeds
    ) internal {
        AccountMeta[2] metas = [
            AccountMeta({pubkey: from, is_signer: true, is_writable: true}),
            AccountMeta({pubkey: to, is_signer: true, is_writable: true})
        ];

        bytes memory bincode = abi.encode(uint32(Instruction.CreateAccount), lamports, space, owner);

        systemAddress.call{accounts: metas, seeds: [seeds]}(bincode);
    }

    @mutableSigner(user)
    @mutableAccount(liveBonus)
    @mutableAccount(eventInfo)
    function register() external {
        address user = tx.accounts.user.key;
        bytes memory userBytes = abi.encodePacked(user);
        (address liveBonusAddr, bytes1 liveBonusBump) = try_find_program_address(
            [LIVE_BONUS_SEED, userBytes],
            type(ProjectSEKAI).program_id
        );
        assert(liveBonusAddr == tx.accounts.liveBonus.key);
        (address eventInfoAddr, bytes1 eventInfoBump) = try_find_program_address(
            [EVENT_INFO_SEED, userBytes],
            type(ProjectSEKAI).program_id
        );
        assert(eventInfoAddr == tx.accounts.eventInfo.key);

        bytes[] memory liveBonusSeeds = [LIVE_BONUS_SEED, userBytes, liveBonusBump];
        bytes[] memory eventInfoSeeds = [EVENT_INFO_SEED, userBytes, eventInfoBump];
        create_account(
            user,  // lamports sent from this account
            liveBonusAddr,  // account to be created
            minimum_balance(128),
            128,    // space required
            type(ProjectSEKAI).program_id,   // owner
            liveBonusSeeds
        );
        create_account(
            user,
            eventInfoAddr,
            minimum_balance(64),
            64,
            type(ProjectSEKAI).program_id,
            eventInfoSeeds
        );
    }

    function getLiveBonusAccountData(AccountInfo ai) internal pure returns (LiveBonus) {
        LiveBonus data = LiveBonus({
            lastClaimedAt: ai.data.readUint64LE(0),
            currentValue: ai.data.readUint64LE(8)
        });
        return data;
    }

    function setLiveBonusAccountData(AccountInfo ai, LiveBonus data) internal {
        bytes memory bs = abi.encodePacked(data.lastClaimedAt, data.currentValue);
        // cant directly set ai.data = bs :<
        for (uint i = 0; i < 16; ++i) {
            ai.data[i] = bs[i];
        }
    }

    function getEventInfoAccountData(AccountInfo ai) internal pure returns (EventInfo) {
        EventInfo data = EventInfo({
            badges: ai.data.readUint64LE(0)
        });
        return data;
    }

    function setEventInfoAccountData(AccountInfo ai, EventInfo data) internal {
        bytes memory bs = abi.encodePacked(data.badges);
        for (uint i = 0; i < 8; ++i) {
            ai.data[i] = bs[i];
        }
    }

    @signer(user)
    @mutableAccount(liveBonus)
    function claimLiveBonus() external {
        assert(tx.accounts.liveBonus.owner == type(ProjectSEKAI).program_id);

        LiveBonus liveBonusData = getLiveBonusAccountData(tx.accounts.liveBonus);
        uint64 currentTimestamp = block.timestamp;
        assert(currentTimestamp - liveBonusData.lastClaimedAt >= 3600);

        liveBonusData.lastClaimedAt = currentTimestamp;
        liveBonusData.currentValue += 10;

        setLiveBonusAccountData(tx.accounts.liveBonus, liveBonusData);
    }

    @signer(user)
    @mutableAccount(liveBonus)
    @mutableAccount(eventInfo)
    function play(uint64 consumeLiveBonus) external {
        assert(tx.accounts.liveBonus.owner == type(ProjectSEKAI).program_id);
        assert(tx.accounts.eventInfo.owner == type(ProjectSEKAI).program_id);

        LiveBonus liveBonusData = getLiveBonusAccountData(tx.accounts.liveBonus);
        EventInfo eventInfoData = getEventInfoAccountData(tx.accounts.eventInfo);
        assert(liveBonusData.currentValue >= consumeLiveBonus);

        liveBonusData.currentValue -= consumeLiveBonus;
        eventInfoData.badges += consumeLiveBonus * 10;

        setLiveBonusAccountData(tx.accounts.liveBonus, liveBonusData);
        setEventInfoAccountData(tx.accounts.eventInfo, eventInfoData);
    }

    @signer(user)
    @mutableAccount(liveBonus)
    @mutableAccount(eventInfo)
    function exchange(uint64 index) external {
        assert(tx.accounts.eventInfo.owner == type(ProjectSEKAI).program_id);

        EventInfo eventInfoData = getEventInfoAccountData(tx.accounts.eventInfo);
        assert(index < itemsInShop.length);
        Item storage item = itemsInShop[index];
        assert(eventInfoData.badges >= item.price);
        if (item.name == "Live Bonus Drink") {
            assert(tx.accounts.liveBonus.owner == type(ProjectSEKAI).program_id);
            LiveBonus liveBonusData = getLiveBonusAccountData(tx.accounts.liveBonus);
            liveBonusData.currentValue += 10;
            setLiveBonusAccountData(tx.accounts.liveBonus, liveBonusData);
        }
        eventInfoData.badges -= item.price;
        setEventInfoAccountData(tx.accounts.eventInfo, eventInfoData);
        itemsInShop[index] = itemsInShop[itemsInShop.length - 1];
        itemsInShop.pop();
        emit Redeemed(item.name, tx.accounts.user.key);
    }
}
