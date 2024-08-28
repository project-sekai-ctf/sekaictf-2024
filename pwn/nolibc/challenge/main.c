#define NULL 0
#define STATIC_DATA __attribute__((section(".data")))

typedef struct user {
    char *username;
    char *password;

    int count;
    char *strings[0x7FF];
} user_t;

#include "heap.h"
#include "func.h"

STATIC_DATA static int current_user_index = -1;
STATIC_DATA static int user_count = 0;
STATIC_DATA user_t *users[10];

void login() {
    print("Username: ");
    char *username = (char *) alloc_mem(64);
    if (username == NULL) {
        print_line("Invalid username");
        free_mem(username);
        login();
        return;
    }
    read_until_newline(username, 64);
    if (string_length(username) == 0) {
        print_line("Invalid username");
        free_mem(username);
        login();
        return;
    }

    print("Password: ");
    char *password = (char *) alloc_mem(64);
    if (password == NULL) {
        print_line("Invalid password");
        free_mem(password);
        login();
        return;
    }
    read_until_newline(password, 64);
    if (string_length(password) == 0) {
        print_line("Invalid password");
        free_mem(password);
        login();
        return;
    }


    if (user_count == 0) {
        print_line("No users registered");
        return;
    }

    for (int i = 0; i < user_count; i++) {
        if (string_equals(users[i]->username, username) && string_equals(users[i]->password, password)) {
            current_user_index = i;
        }
    }

    if (current_user_index == -1) {
        print_line("Invalid username or password");
    } else {
        print_line("Logged in successfully!");
    }

    free_mem(username);
    free_mem(password);
}

void register_account() {
    if (user_count >= 1) {
        print_line("You can only register one account!");
        return;
    }

    print("Username: ");
    char *username = (char *) alloc_mem(32);
    if (username == NULL) {
        print_line("Invalid username");
        free_mem(username);
        register_account();
        return;
    }
    read_until_newline(username, 32);
    if (string_length(username) == 0) {
        print_line("Invalid username");
        free_mem(username);
        register_account();
        return;
    }

    print("Password: ");
    char *password = (char *) alloc_mem(32);
    if (password == NULL) {
        print_line("Invalid password");
        free_mem(password);
        register_account();
        return;
    }
    read_until_newline(password, 32);
    if (string_length(password) == 0) {
        print_line("Invalid password");
        free_mem(password);
        register_account();
        return;
    }

    user_t *user = (user_t *) alloc_mem(sizeof(user_t));
    user->username = username;
    user->password = password;
    user->count = 0;

    users[user_count] = user;
    user_count++;

    print_line("User registered successfully!");
}

void add_string() {
    if (users[current_user_index]->count >= 0x7FF) {
        print_line("You have reached the maximum number of strings");
        return;
    }

    print("Enter string length: ");
    int length = read_int();
    if (length <= 0 || length > 256) {
        print_line("Invalid length");
        print_line("");
        return;
    }
    
    print("Enter a string: ");
    char *str = (char *) alloc_mem(length + 1);
    if (str == NULL) {
        print_line("Failed to allocate memory");
        print_line("");
        exit();
    }
    read_until_newline(str, length + 1);

    users[current_user_index]->strings[users[current_user_index]->count] = str;
    users[current_user_index]->count++;
    print_line("String added successfully!");
    // printf("str: %p\n", str);
}

void delete_string() {
    if (users[current_user_index]->count == 0) {
        print_line("No strings to delete");
        print_line("");
        return;
    }

    print("Enter the index of the string to delete: ");
    int index = read_int();
    if (index < 0 || index >= users[current_user_index]->count) {
        print_line("Invalid index");
        print_line("");
        return;
    }

    free_mem(users[current_user_index]->strings[index]);
    for (int i = index; i < users[current_user_index]->count - 1; i++) {
        users[current_user_index]->strings[i] = users[current_user_index]->strings[i + 1];
    }
    users[current_user_index]->count--;
    print_line("String deleted successfully!");
}

void view_strings() {
    if (users[current_user_index]->count == 0) {
        print_line("No strings to view");
        print_line("");
        return;
    }

    for (int i = 0; i < users[current_user_index]->count; i++) {
        print("String ");
        print_int(i);
        print(": ");
        print_line(users[current_user_index]->strings[i]);
    }    
}

void save_to_file() {
    print("Enter the filename: ");
    char *filename = (char *) alloc_mem(32);
    if (filename == NULL) {
        print_line("Invalid filename");
        print_line("");
        return;
    }
    read_until_newline(filename, 32);
    if (string_length(filename) == 0 || string_contains(filename, "flag")) {
        print_line("Invalid filename");
        print_line("");
        return;
    }

    char *buf = (char *) alloc_mem(0x7FFF);
    if (buf == NULL) {
        print_line("Failed to allocate memory");
        print_line("");
        exit();
    }

    int size = 0;
    for (int i = 0; i < users[current_user_index]->count; i++) {
        int length = string_length(users[current_user_index]->strings[i]);
        for (int j = 0; j < length; j++) {
            buf[size] = users[current_user_index]->strings[i][j];
            size++;
        }
        buf[size] = '\n';
        size++;
    }

    int result = write_file(filename, buf, size);
    if (result < 0) {
        print_line("Failed to write file");
        print_line("");
        return;
    }

    print_line("Strings saved to file successfully!");    

    free_mem(buf);
}

void load_from_file() {
    print("Enter the filename: ");
    char *filename = (char *) alloc_mem(32);
    if (filename == NULL) {
        print_line("Invalid filename");
        print_line("");
        return;
    }
    read_until_newline(filename, 32);
    if (string_length(filename) == 0 || string_contains(filename, "flag")) {
        print_line("Invalid filename");
        print_line("");
        return;
    }

    char *buf = (char *) alloc_mem(0x7FFF);
    if (buf == NULL) {
        print_line("Failed to allocate memory");
        print_line("");
        exit();
    }

    int size = read_file(filename, buf, 0x7FFF);
    if (size < 0) {
        print_line("Failed to read file");
        print_line("");
        return;
    }

    int i = 0;
    int j = 0;
    while (i < size) {
        int length = 0;
        while (buf[i] != '\n') {
            length++;
            i++;
        }

        char *str = (char *) alloc_mem(length + 1);
        if (str == NULL) {
            print_line("Failed to allocate memory");
            print_line("");
            exit();
        }

        for (int k = 0; k < length; k++) {
            str[k] = buf[j];
            j++;
        }
        str[length] = '\0';

        users[current_user_index]->strings[users[current_user_index]->count] = str;
        users[current_user_index]->count++;
        i++;
        j++;
    }

    print_line("Strings loaded from file successfully!");

    free_mem((char *)buf);    
}

// #include <stdio.h>

__attribute__((force_align_arg_pointer))
void _start() {
// int main() {
    init_mem();

    // printf("SYS_READ: %p\n", &SYS_READ);
login:
    print_line("Welcome to String Storage!");
    print_line("Please login or register an account to continue :)");
    print_line("");
    while (current_user_index == -1) {
        print_line("1. Login");
        print_line("2. Register");
        print_line("3. Exit");

        print("Choose an option: ");
        int option = read_int();
        print_line("");
        if (option == 1) {
            login();
        } else if (option == 2) {
            register_account();
        } else if (option == 3) {
            exit(0);
        } else {
            print_line("Invalid option");
        }
        print_line("");
    }

    print("Welcome to String Storage, ");
    print(users[current_user_index]->username);
    print_line("!");
    print_line("");
    while (1) {
        print_line("1. Add string");
        print_line("2. Delete string");
        print_line("3. View strings");
        print_line("4. Save to File");
        print_line("5. Load from File");
        print_line("6. Logout");

        print("Choose an option: ");
        int option = read_int();
        print_line("");
        if (option == 1) {
            add_string();
        } else if (option == 2) {
            delete_string();
        } else if (option == 3) {
            view_strings();
        } else if (option == 4) {
            save_to_file();
        } else if (option == 5) {
            load_from_file();
        } else if (option == 6) {
            current_user_index = -1;
            goto login;
        } else {
            print_line("Invalid option");
        }
        print_line("");
    }
}