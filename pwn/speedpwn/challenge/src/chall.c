

#include<stdio.h>
#include<stdlib.h>

unsigned long long number_of_games;
unsigned long long game_history;
unsigned long long seed;
FILE *seed_generator;

int cmp(unsigned long long a, unsigned long long b) {
    if (__builtin_popcountll(a) != __builtin_popcountll(b)) {
        return __builtin_popcountll(a) > __builtin_popcountll(b) ? 1 : 0;
    }
    for(size_t i = 0; i < 64; i++) {
        if ((a & 1) != (b & 1)) {
            return a & 1;
        }
        a >>= 1;
        b >>= 1;
    }
    return 0;
}

void print_menu() {
    puts("f) Fight bot");
    puts("s) Simulate game");
    puts("p) Print game history");
    puts("r) Reseed bot");
    printf("> ");
}

unsigned long long get_random_ull() {
    return (unsigned long long) ((unsigned long long)rand() << 32) | (unsigned long long)rand();
}

void fight_bot() {

    unsigned long long bot_num, player_num;
    bot_num = get_random_ull();
    printf("Bot plays %llu!\nPlayer plays: ", bot_num);
    scanf("%llu%*c", &player_num);
    
    if(cmp(player_num, bot_num)) {
        puts("You win!");
        *((unsigned long long*)&game_history + (number_of_games / 64)) |= ((unsigned long long)1 << (number_of_games % 64));
    }
    else {
        puts("Bot wins!");
        *((unsigned long long*)&game_history + (number_of_games / 64)) &= (~((unsigned long long)1 << (number_of_games % 64)));
    }

    number_of_games++;
    return;
}

void simulate() {
    unsigned long long bot_num, player_num;
    printf("Bot number: ");
    scanf("%llu%*c", &bot_num);
    printf("Player number: ");
    scanf("%llu%*c", &player_num);
    
    printf("Simulation result: ");
    cmp(bot_num, player_num) ? puts("Bot win!"): puts("You win!");
    return;
}

void print_game_history() {
    for(size_t i = 0; i < number_of_games; i++) {
        printf("Game %d: %s\n", (int)i+1, (*((unsigned long long*)&game_history + (number_of_games / 64)) & (1 << (i % 64))) == 1 ? "Won": "Lost");
    }
    return;
}

void reseed() {
    puts("Bot reseeded!");
    fread((char*)&seed, 1, 8, seed_generator);
    srand(seed);
    return;
}

void init() {
    setvbuf(stdout, NULL, _IONBF, 0);
    seed_generator = fopen("/dev/urandom", "r");
    return;
}

int main(int argc, char *argv[]) {

    char choice;
    init();
    reseed();
    while(1) {
        print_menu();
        while((choice = getc(stdin)), choice == '\n');
        switch(choice) {
            case 'f':
                fight_bot();
                break;
            case 's':
                simulate();
                break;
            case 'p':
                print_game_history();
                break;
            case 'r':
                reseed();
                break;
            default:
                puts("Invalid choice");
                break;
        }
    }
    return 0;
}
