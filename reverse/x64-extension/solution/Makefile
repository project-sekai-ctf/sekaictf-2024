test:
	nasm -f elf64 -o AES.o AES.asm
	g++ -c main.cpp -o main.o
	g++ -o a.out AES.o main.o
clean:
	rm -f *.o a.out