FROM ubuntu:20.04

RUN useradd -ms /bin/bash ctf

USER root
RUN apt-get -y update
RUN apt-get -y install socat build-essential gcc-multilib g++-multilib libc6

WORKDIR /home/ctf

COPY . .

RUN chown -R root:root /home/ctf
RUN chmod -R 755 /home/ctf
RUN chmod 755 main

RUN mv flag.txt /flag_`cat /proc/sys/kernel/random/uuid`.txt
RUN chown root:root /flag_*.txt
RUN chmod 444 /flag_*.txt

USER ctf
EXPOSE 1337
CMD socat TCP-LISTEN:1337,reuseaddr,fork 'EXEC:./main'