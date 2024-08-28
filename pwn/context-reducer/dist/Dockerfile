FROM ubuntu:22.04
# RUN sed -i 's@//.*.ubuntu.com@//mirrors.ustc.edu.cn@g' /etc/apt/sources.list
RUN apt-get update && \
    apt-get install -y xinetd libicu-dev python3 python3-pip

RUN useradd -m ctf

WORKDIR /home/ctf

COPY ./xinetd.conf /etc/xinetd.d/ctf
COPY ./start.sh /start.sh

RUN chmod +x /start.sh

COPY ./d8 /home/ctf/
COPY ./icudtl.dat /home/ctf/
COPY ./snapshot_blob.bin /home/ctf/
COPY ./getflag /home/ctf/
COPY ./run.sh /
COPY ./server.py /

RUN chmod +x /run.sh
RUN chmod +x /server.py

RUN find /home/ctf -type f -exec chmod 111 {} \;
RUN chmod 555 /home/ctf/snapshot_blob.bin /home/ctf/icudtl.dat
CMD ["/start.sh"]

EXPOSE 7000
