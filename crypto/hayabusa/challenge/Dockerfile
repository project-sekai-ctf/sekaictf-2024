FROM python:3.9-slim-buster

RUN apt-get update -y && \
    apt-get install -y lib32z1 xinetd git && \
    pip3 install timeout-decorator && \
    pip3 install pycryptodome  && \
    pip3 install numpy  && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

RUN useradd -m user && \
    chown -R root:root /home/user

COPY app /home/user/
COPY xinetd /etc/xinetd.d/user

WORKDIR /home/user

RUN chmod +x ./up.sh && \
    ./up.sh

EXPOSE 9999

CMD ["/usr/sbin/xinetd", "-dontfork"]