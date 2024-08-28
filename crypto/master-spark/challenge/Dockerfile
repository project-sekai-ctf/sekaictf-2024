FROM sagemath/sagemath:latest

USER root

RUN apt-get -qq update && \
    apt-get -qq install -y --no-install-recommends xinetd && \
    rm -rf /var/lib/apt/lists/*

USER sage

RUN sage -pip install pycryptodome timeout-decorator

USER root

RUN echo "Connection blocked" > /etc/banner_fail
COPY xinetd /etc/xinetd.d/chal
COPY ./app /app/
RUN chown -R sage:sage /app && chmod -R 750 /app

EXPOSE 9999

ENTRYPOINT ["/usr/sbin/xinetd", "-dontfork"]