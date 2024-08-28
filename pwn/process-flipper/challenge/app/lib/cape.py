import os
from typing import Any, List, Optional, Type, TypeVar

import requests
from pydantic import BaseModel, TypeAdapter, ValidationError

BASE_URL = os.getenv("CAPE_BASE_URL")
TOKEN = os.getenv("CAPE_API_KEY")
HEADERS = {"Authorization": f"Token {TOKEN}"}

T = TypeVar("T")


def deserialize_response(data: dict[str, Any], model: Type[T]) -> Optional[T]:
    """Validate response JSON content.

    Args:
        response: The HTTP response.
        model: The pydantic model used to validate the JSON response.

    Returns:
        A deserialized response if the response is valid, None otherwise.
    """
    try:
        return TypeAdapter(model).validate_python(data)
    except ValidationError as e:
        raise e


class FileCreateResponse(BaseModel):
    class Data(BaseModel):
        task_ids: list[int]
        message: str

    error: bool
    error_value: Optional[str] = None
    data: Optional[Data] = None
    errors: Optional[List[Any]] = []
    url: Optional[List[str]] = []


class TaskStatusResponse(BaseModel):
    error: bool
    data: str


def file_create(filepath: str, **data) -> dict:
    with open(filepath, "rb") as f:
        response = requests.post(
            url=f"{BASE_URL}/apiv2/tasks/create/file/",
            headers=HEADERS,
            files={"file": f},
            data=data,
        )
        return deserialize_response(data=response.json(), model=FileCreateResponse)


def task_status(task_id: int) -> dict:
    response = requests.get(
        url=f"{BASE_URL}/apiv2/tasks/status/{task_id}/", headers=HEADERS
    )
    return deserialize_response(data=response.json(), model=TaskStatusResponse)


def task_screenshot(task_id: int, screenshot_number: int = None) -> bytes:
    screenshot_path = f"{screenshot_number}/" if screenshot_number else ""
    response = requests.get(
        url=f"{BASE_URL}/apiv2/tasks/get/screenshot/{task_id}/{screenshot_path}",
        headers=HEADERS,
    )
    return response.content
