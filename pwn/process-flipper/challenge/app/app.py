import os
import uuid
from zipfile import ZipFile

from flask import Flask, abort, redirect, render_template, send_file, url_for
from flask_wtf import FlaskForm
from flask_wtf.recaptcha import RecaptchaField
from lib.cape import (
    FileCreateResponse,
    TaskStatusResponse,
    file_create,
    task_screenshot,
    task_status,
)
from pymongo import MongoClient
from werkzeug.utils import secure_filename
from wtforms import FileField, SubmitField
from wtforms.validators import DataRequired

SCRIPT_ROOT = os.path.dirname(__file__)
PENDING_STATUS_MESSAGE = """\
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv="refresh" content="5">
  </head>
  <body>Your exploit is still running, please wait...</body>
</html>
"""

app = Flask(__name__)
app.config["RECAPTCHA_PUBLIC_KEY"] = os.getenv("RECAPTCHA_PUBLIC_KEY")
app.config["RECAPTCHA_PRIVATE_KEY"] = os.getenv("RECAPTCHA_PRIVATE_KEY")
app.config["MONGO_URI"] = os.getenv("MONGO_URI")
app.config["SECRET_KEY"] = os.urandom(16).hex()
app.config["UPLOAD_FOLDER"] = "/tmp"
app.config["SCREENSHOTS_FOLDER"] = os.path.join(SCRIPT_ROOT, "screenshots")
app.config["ALLOWED_EXTENSIONS"] = {"exe"}
app.config["MAX_CONTENT_LENGTH"] = 3 * 1024 * 1024

tasks_collection = MongoClient(app.config["MONGO_URI"]).get_database()["tasks"]


class UploadForm(FlaskForm):
    file = FileField("Process Flipper Exploit Submission", validators=[DataRequired()])
    recaptcha = RecaptchaField()
    submit = SubmitField("Upload")


def allowed_file(filename):
    return (
        "." in filename
        and filename.rsplit(".", 1)[1].lower() in app.config["ALLOWED_EXTENSIONS"]
    )


@app.route("/", methods=["GET", "POST"])
def upload_file():
    form = UploadForm()
    if form.validate_on_submit():
        file = form.file.data
        if file and allowed_file(file.filename):
            # Save file to the tmp folder
            filename = secure_filename(file.filename)
            filepath = os.path.join(app.config["UPLOAD_FOLDER"], filename)
            file.save(filepath)

            # Send exe file to the sandbox
            task_response: FileCreateResponse = file_create(
                filepath,
                timeout="20",
                options="free=yes,nohuman=yes,procdump=0",
                route="none",
            )
            if task_response.error:
                return 500, "An error has occurred, please try again."
            task_id = task_response.data.task_ids[0]

            # Store task details in the database
            task_doc = {
                "uuid": str(uuid.uuid4()),
                "task_id": task_id,
                "finished": False,
            }
            tasks_collection.insert_one(task_doc)

            # Redirect to the screenshot page
            return redirect(url_for("get_screenshot", uuid=task_doc["uuid"]))

    return render_template("index.html", form=form)


@app.route("/<uuid>", methods=["GET"])
def get_screenshot(uuid):
    # Check if this task exists
    task_doc = tasks_collection.find_one({"uuid": uuid})
    if not task_doc:
        abort(404)

    # Check if the task has finished and return the screenshot if it's there
    if task_doc["finished"]:
        screenshot_path = os.path.join(app.config["SCREENSHOTS_FOLDER"], f"{uuid}.jpg")
        if os.path.exists(screenshot_path):
            return send_file(screenshot_path)
        abort(404)

    # Get the task status
    status_response: TaskStatusResponse = task_status(task_doc["task_id"])
    if status_response.error:
        return 500, "An error has occurred, please try submitting your exploit again."

    if status_response.data == "reported":
        raw_zip_file = task_screenshot(task_doc["task_id"])
        zip_path = os.path.join(app.config["UPLOAD_FOLDER"], f"{uuid}.zip")

        with open(zip_path, "wb") as f:
            f.write(raw_zip_file)

        # Extract the screenshots
        with ZipFile(zip_path, "r") as zip_ref:
            output_dir = zip_path.rstrip(".zip")
            os.makedirs(output_dir, exist_ok=True)
            zip_ref.extractall(output_dir)
            screenshots = [
                f"{output_dir}/shots/{file}"
                for file in os.listdir(f"{output_dir}/shots")
                if file.endswith(".jpg")
            ]
            if screenshots:
                latest_screenshot = max(
                    screenshots, key=lambda x: int(x.rsplit("/", 1)[1].split(".")[0])
                )
                screenshot_path = os.path.join(
                    app.config["SCREENSHOTS_FOLDER"], f"{uuid}.jpg"
                )
                os.rename(latest_screenshot, screenshot_path)
                task_doc["finished"] = True
                tasks_collection.update_one(
                    {"uuid": uuid}, {"$set": {"finished": True}}
                )
                return send_file(screenshot_path)
            return (
                500,
                "An error has occurred, please try submitting your exploit again.",
            )

        return PENDING_STATUS_MESSAGE, 200

    return PENDING_STATUS_MESSAGE, 200


if __name__ == "__main__":
    if not os.path.exists(app.config["UPLOAD_FOLDER"]):
        os.makedirs(app.config["UPLOAD_FOLDER"])
    if not os.path.exists(app.config["SCREENSHOTS_FOLDER"]):
        os.makedirs(app.config["SCREENSHOTS_FOLDER"])
    app.run(host="0.0.0.0", port=8080, debug=False)
