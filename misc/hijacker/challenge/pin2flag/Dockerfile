FROM python:3.8-slim

RUN apt update && apt install -y xinetd && rm -rf /var/lib/apt/lists/*

RUN pip install pycryptodome

COPY ./app /app
COPY xinetd /etc/xinetd.d/chal

RUN echo "Connection blocked" > /etc/banner_fail

EXPOSE 5001

ENTRYPOINT ["/usr/sbin/xinetd", "-dontfork"]
