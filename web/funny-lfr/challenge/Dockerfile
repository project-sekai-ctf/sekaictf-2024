FROM python:3.9-slim

RUN apt-get update && \
    apt-get install -y gnupg curl supervisor openssh-server

RUN pip install --no-cache-dir starlette uvicorn

RUN echo "PermitEmptyPasswords yes" >> /etc/ssh/sshd_config && \
    mkdir /var/run/sshd && \
    useradd -m user -s /bin/bash && \
    passwd -d user

COPY supervisord.conf /etc/supervisord.conf

COPY app.py /app/

ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisord.conf"]
