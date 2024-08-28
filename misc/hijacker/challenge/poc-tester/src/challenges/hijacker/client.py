from random import randint, uniform
from lamda.client import Device, Point, ApplicationOpStub, GrantType
from time import sleep
from type import Status, Queue

MAIN_PACKAGE_NAME ="com.aimar.id.hijacker"
PROCESS_TIMEOUT = 30
CHALLENGE_NAME = "Hijacker"

def run_exploit(device: Device, pocPackageName: str):
    exploit: ApplicationOpStub = device.application(pocPackageName)
    permissions = exploit.permissions()
    for permission in permissions:
        if permission.startswith("android.permission"):
            try:
                exploit.grant(permission, mode=GrantType.GRANT_ALLOW)
            except:
                pass
        exploit.start()

    while not exploit.is_foreground():
        pass


def run_application(device: Device):
    app: ApplicationOpStub = device.application(MAIN_PACKAGE_NAME)
    procs = device.enumerate_running_processes()
    for proc in procs:
        if proc.processName == MAIN_PACKAGE_NAME:
            app.stop()
            break

    app.start()
    while not app.is_foreground():
        pass

def callback(device: Device, pocPackageName: str, q: Queue):
    q.status = Status.RUNNING_PROOF_OF_CONCEPT

    run_exploit(device, pocPackageName)

    sleep(2.5)

    q.status = Status.RUNNING_VULNERABLE_APPLICATION

    run_application(device)

    sleep(2.5)
    # pin_buttons = [None] * 10
    # clear_button = device(text='C')
    # for i in range(0, 10):
    #     pin_buttons[i] = device(text=str(i))

    # with open("/tmp/logs.txt", "w") as f:
    #     f.write('---- Buttons ----\n')
    #     for i in range(0, 10):
    #         x,y = get_middle(pin_buttons[i].info().bounds.top, pin_buttons[i].info().bounds.left, pin_buttons[i].info().bounds.bottom, pin_buttons[i].info().bounds.right)
    #         f.write(f"Button {i}: x={x}, y={y}\n")
    #     x,y = get_middle(clear_button.info().bounds.top, clear_button.info().bounds.left, clear_button.info().bounds.bottom, clear_button.info().bounds.right)
    #     f.write(f"Clear button: x={x}, y={y}\n")

    pin_buttons = [
        Point(x=269, y=1482),
        Point(x=269, y=711),
        Point(x=539, y=711),
        Point(x=809, y=711),
        Point(x=269, y=968),
        Point(x=539, y=968),
        Point(x=809, y=968),
        Point(x=269, y=1225),
        Point(x=539, y=1225),
        Point(x=809, y=1225),
    ]
    clear_button = Point(x=809, y=1482)

    pin = "593720"
    pos = 0
    while pos < len(pin):
        if randint(0, 100) < 15:
            idx = randint(0, 9)
            while idx == int(pin[pos]):
                idx = randint(0, 9)

            device.click(pin_buttons[idx])
            sleep(uniform(0.1, 0.5))

            device.click(clear_button)
            pos = 0
        else:
            device.click(pin_buttons[int(pin[pos])])
            pos += 1

        sleep(uniform(0.1, 0.5))
        pass
