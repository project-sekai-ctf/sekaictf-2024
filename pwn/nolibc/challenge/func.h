#ifdef __x86_64__
#include "syscall/x86_64/syscall_arch.h"
#else
#include "syscall/x86/syscall_arch.h"
#endif

STATIC_DATA static int SYS_READ = 0;
STATIC_DATA static int SYS_WRITE = 1;
STATIC_DATA static int SYS_OPEN = 2;
STATIC_DATA static int SYS_CLOSE = 3;
STATIC_DATA static int SYS_EXIT = 60;

void print(const char *s) {
    while (*s) {
        __syscall3(SYS_WRITE, 1, (long)s, 1);
        s++;
    }
}

void print_line(const char *s) {
    print(s), __syscall3(SYS_WRITE, 1, (long)"\n", 1);
}

void print_int(int n) {
    char buf[32];
    int i = 0;
    if (n == 0) {
        buf[i++] = '0';
    } else {
        if (n < 0) {
            buf[i++] = '-';
            n = -n;
        }
        int j = i;
        while (n) {
            buf[i++] = n % 10 + '0';
            n /= 10;
        }
        for (int k = j; k < i / 2; k++) {
            char tmp = buf[k];
            buf[k] = buf[i - k - 1];
            buf[i - k - 1] = tmp;
        }
    }
    buf[i] = '\0';
    print(buf);
}

void print_hex(int n) {
    char buf[32];
    int i = 0;
    if (n == 0) {
        buf[i++] = '0';
        buf[i++] = 'x';
        buf[i++] = '0';
        buf[i++] = '0';
    } else {
        buf[i++] = '0';
        buf[i++] = 'x';
        int j = i;
        int leading_zeros = 0;
        while (n) {
            int d = n & 0xF;
            buf[i++] = d < 10 ? d + '0' : d - 10 + 'A';
            n >>= 4;
            leading_zeros++;
        }
        for (int k = j; k < i / 2; k++) {
            char tmp = buf[k];
            buf[k] = buf[i - k - 1];
            buf[i - k - 1] = tmp;
        }
        while (leading_zeros % 2 != 0) {
            buf[i++] = '0';
            leading_zeros++;
        }
    }
    buf[i] = '\0';
    print(buf);
}

int read_until_newline(char *buf, int size) {
    int i = 0;
    char c;
    while (i < size) {
        __syscall3(SYS_READ, 0, (long)&c, 1);
        if (c == '\n') {
            buf[i] = '\0';
            return i;
        }
        buf[i] = c;
        i++;
    }
    return i;
}

int read_int() {
    char buf[32];
    int n = 0;
    int i = read_until_newline(buf, 32);
    for (int j = 0; j < i; j++) {
        if (buf[j] < '0' || buf[j] > '9') {
            return -1;
        }
        n = n * 10 + (buf[j] - '0');
    }
    return n;
}

void string_copy(char *dst, const char *src, int size) {
    int i = 0;
    while (i < size && src[i]) {
        dst[i] = src[i];
        i++;
    }
    dst[i] = '\0';
}

int string_length(const char *s) {
    int i = 0;
    while (s[i]) {
        i++;
    }
    return i;
}

int string_equals(const char *s1, const char *s2) {
    int len = string_length(s1);
    if (len != string_length(s2)) {
        return 0;
    }

    int i = 0;
    while (i < len && s1[i] == s2[i]) {
        i++;
    }

    return (s1[i] == '\0' && s2[i] == '\0') && len == i;
}

int string_contains(const char *haystack, const char *needle) {
    int i = 0;
    while (haystack[i]) {
        int j = 0;
        while (needle[j] && haystack[i + j] == needle[j]) {
            j++;
        }
        if (needle[j] == '\0') {
            return 1;
        }
        i++;
    }
    return 0;
}

void exit() {
    __syscall1(SYS_EXIT, 0);
}

int read_file(const char *filename, char *buf, int size) {
    int fd = __syscall3(SYS_OPEN, (long)filename, 0, 0);
    if (fd < 0) {
        return -1;
    }

    int ret = __syscall3(SYS_READ, fd, (long)buf, size);
    __syscall3(SYS_CLOSE, fd, 0, 0);

    return ret;
}

int write_file(const char *filename, const char *buf, int size) {
    int fd = __syscall3(SYS_OPEN, (long)filename, 1 | 64, 438);
    if (fd < 0) {
        return -1;
    }

    int ret = __syscall3(SYS_WRITE, fd, (long)buf, size);
    __syscall3(SYS_CLOSE, fd, 0, 0);

    return ret;
}