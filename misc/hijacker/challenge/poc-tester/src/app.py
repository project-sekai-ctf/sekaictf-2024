import traceback
from typing import List
from flask import Flask, render_template, request, jsonify, send_file, session
from threading import Thread
from time import sleep
import os
import uuid
import re
import signal

from type import Status, Client, Queue
from utils import run_process, timeout_handler

from lamda.client import Device
from pow import Challenge, check
import glob
from importlib import import_module

app = Flask(__name__)
app.secret_key = os.urandom(24)

device = Device('localhost', 65000)
queue: List[Queue] = []

clients: List[Client] = []
client_files = glob.glob("challenges/*/client.py")
for client_file in client_files:
    client: Client = import_module(client_file.replace("/", ".")[:-3])
    clients.append(client)

print("Challenges Loaded:")
print("----------------------------------------------")
for client in clients:
    print(f"Challenge Name: {client.CHALLENGE_NAME}")
    print(f"Main Package Name: {client.MAIN_PACKAGE_NAME}")
    print(f"Process Timeout: {client.PROCESS_TIMEOUT}")
    print("----------------------------------------------")

challenge_files = glob.glob("challenges/*/*.apk")

for challenge_file in challenge_files:
    run_process('adb', ['install', '-r', challenge_file])

signal.signal(signal.SIGALRM, timeout_handler)

class QueueThread(Thread):
    def __init__(self):
        super().__init__()

    def run(self):
        while True:
            for q in queue:
                if q.status == Status.PENDING_QUEUE:
                    pocPackageName = None
                    signal.alarm(q.client.PROCESS_TIMEOUT)
                    try:
                        q.status = Status.INSTALLING_PROOF_OF_CONCEPT

                        out, err = run_process('aapt', ['dump', 'badging', f'uploads/' + q.id + '.apk'])
                        if err:
                            q.status = Status.ERROR
                            q.error = err
                            continue

                        pocPackageName = re.search(r"package: name='(.*?)'", out).group(1)
                        if not pocPackageName or pocPackageName == q.client.MAIN_PACKAGE_NAME:
                            q.status = Status.ERROR
                            q.error = 'Invalid package name!'
                            continue

                        out, err = run_process('adb', ['install', '-r', 'uploads/' + q.id + '.apk'])
                        if 'Success' not in out:
                            q.status = Status.ERROR
                            q.error = err
                            continue

                        if q.client.callback:
                            q.client.callback(device, pocPackageName, q)

                        q.status = Status.TAKING_SCREENSHOT
                        device.execute_script('screencap -p /data/local/tmp/screenshot.png')
                        device.download_file('/data/local/tmp/screenshot.png', 'screenshots/' + q.id + '.png')
                        device.execute_script('rm -f /data/local/tmp/screenshot.png')
                        q.status = Status.COMPLETED
                    except Exception as e:
                        traceback.print_exc()

                        q.status = Status.ERROR
                        q.error = str(e)
                    finally:
                        signal.alarm(0)
                        if pocPackageName:
                            _, err = run_process('adb', ['uninstall', pocPackageName])
                            if err:
                                q.status = Status.ERROR
                                q.error = err

                            os.remove('uploads/' + q.id + '.apk')
            sleep(1)

@app.before_request
def before_request():
    if 'challenge' not in session:
        session['challenge'] = str(Challenge.generate(20000))

@app.route('/')
def index():
    challenges = []
    for client in clients:
        challenges.append(client.CHALLENGE_NAME)

    return render_template('index.html', challenges=challenges)

@app.route('/upload', methods=['POST'])
def upload():
    try:
        solution = request.form.get('solution')
        challenge = Challenge.from_string(session.get('challenge'))

        if not check(challenge, solution):
            return jsonify({'status': 'error', 'message': 'Incorrect solution!'})

        session.clear()
    except:
        return jsonify({'status': 'error', 'message': 'Invalid solution!'})

    chall_name = request.form.get('chall_name')
    if not chall_name:
        return jsonify({'status': 'error', 'message': 'Please specify the challenge name!'})

    client: Client = None
    for c in clients:
        if c.CHALLENGE_NAME == chall_name:
            client = c
            break

    if not client:
        return jsonify({'status': 'error', 'message': 'Challenge not found!'})

    q = Queue(
        status=Status.PENDING_QUEUE,
        id=str(uuid.uuid4()),
        client=client,
    )
    queue.append(q)

    file = request.files['file']
    file.save('uploads/' + q.id + '.apk')

    return jsonify({'status': 'success', 'id': q.id})

@app.route('/status', methods=['GET'])
def status():
    id = request.args.get('id')
    for q in queue:
        if q.id == id:
            return render_template('status.html', queue=q)

    return 'Queue not found!'

@app.route('/screenshots/<id>', methods=['GET'])
def screenshots(id):
    id = os.path.basename(id)
    if id.endswith('.png'):
        id = id[:-4]

    if not os.path.exists('screenshots/' + id + '.png'):
        return 'Screenshot not found!'

    return send_file('screenshots/' + id + '.png', mimetype='image/png')

if __name__ == '__main__':
    queue_thread = QueueThread()
    queue_thread.start()

    _, err = run_process('adb', ['wait-for-device'])
    if err:
        print(err)
        exit(1)

    app.run(host='0.0.0.0', port=5000, debug=False)
