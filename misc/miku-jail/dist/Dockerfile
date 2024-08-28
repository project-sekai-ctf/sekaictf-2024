FROM ubuntu:20.04 as base

RUN apt-get update
RUN apt-get install -y git
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y build-essential
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y cmake
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y pkg-config
RUN mkdir /build
WORKDIR /build
RUN git clone -b 3.12 https://github.com/python/cpython
WORKDIR /build/cpython
RUN ./configure
COPY ./bytearrayobject.c /build/cpython/Objects/bytearrayobject.c
COPY ./bufferedio.c /build/cpython/Modules/_io/bufferedio.c
COPY ./descrobject.c /build/cpython/Objects/descrobject.c
RUN make -j 4
RUN make install; exit 0 # ignore zlib error
WORKDIR /buildaudit
COPY ./audit/* /buildaudit
RUN chmod +x ./build.sh
RUN ./build.sh
RUN cp ./irs /usr/bin/irs

FROM pwn.red/jail as chall
COPY --from=base / /srv
COPY chall.py /srv/app/run
COPY flag.txt /srv/flag.txt
# apparently im bad at docker so i stole this from kmh
RUN chmod 444 /srv/flag.txt && mv /srv/flag.txt /srv/flag.`tr -dc A-Za-z0-9 < /dev/urandom | head -c 20`.txt
RUN chmod +x /srv/app/run
ENV JAIL_MEM=20M JAIL_ENV_NUM=5 JAIL_TIME=30 JAIL_CPU=500