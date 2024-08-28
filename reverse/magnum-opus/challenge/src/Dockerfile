FROM python:3.11.9

# dependencies
RUN apt-get update
RUN apt-get upgrade -y
RUN apt-get install -y xinetd
RUN rm -rf /var/lib/apt/lists/*
RUN pip3 install sudokum numpy pycryptodome

# setup unpriv user
RUN mkdir /ctf
RUN useradd -M -d /ctf ctf

# copy files
RUN echo "Connection blocked" > /etc/banner_fail
COPY magnum_opus.py /ctf/magnum_opus.py
COPY flag.txt /ctf/flag.txt
COPY ctf.xinetd /etc/xinetd.d/ctf
COPY start.sh /ctf/start.sh

# file perms
RUN chown -R root:ctf /ctf 
RUN chmod -R 750 /ctf

# run
CMD ["/usr/sbin/xinetd", "-dontfork"]
EXPOSE 1337