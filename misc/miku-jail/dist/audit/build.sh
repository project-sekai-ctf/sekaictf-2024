#!/bin/sh
gcc -std=c99 -ggdb3 -O0 -pedantic-errors -Wall -Wextra -fpie $(python3.12-config --cflags --embed) -o 'irs' './irs.c' $(python3.12-config --embed --ldflags)
# https://github.com/dicegang/dicectf-quals-2024-challenges/blob/main/misc/irs/irs.c by kmh