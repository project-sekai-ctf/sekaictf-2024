from lamda.client import Device

class Queue:
    def __init__(self, status: str, id: str, client: "Client", error= None):
        self.status = status
        self.id = id
        self.client = client
        self.error = error

class Status:
    PENDING_QUEUE = 'PENDING_QUEUE'
    INSTALLING_PROOF_OF_CONCEPT = 'INSTALLING_PROOF_OF_CONCEPT'
    ERROR = 'ERROR'
    RUNNING_PROOF_OF_CONCEPT = 'RUNNING_PROOF_OF_CONCEPT'
    RUNNING_VULNERABLE_APPLICATION = 'RUNNING_VULNERABLE_APPLICATION'
    TAKING_SCREENSHOT = 'TAKING_SCREENSHOT'
    CLEANING_UP = 'CLEANING_UP'
    COMPLETED = 'COMPLETED'

class Client:
    MAIN_PACKAGE_NAME: str
    PROCESS_TIMEOUT: str
    CHALLENGE_NAME: str
    POC_PACKAGE_NAME: str
    USER: int
    def callback(device: Device, pocPackageName: str, q: Queue): pass
