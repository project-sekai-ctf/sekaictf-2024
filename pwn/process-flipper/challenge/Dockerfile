FROM python:3.11

COPY requirements.txt /tmp/requirements.txt

RUN pip install -r /tmp/requirements.txt && \
    rm -f /tmp/requirements.txt

COPY app /app

ENV CAPE_BASE_URL=
ENV CAPE_API_KEY=
ENV RECAPTCHA_PUBLIC_KEY=
ENV RECAPTCHA_PRIVATE_KEY=
ENV MONGO_URI=

EXPOSE 8080

CMD ["python", "-u", "/app/app.py"]