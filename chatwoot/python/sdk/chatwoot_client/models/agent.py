# coding: utf-8

"""
    Chatwoot

    This is the API documentation for Chatwoot server.

    The version of the OpenAPI document: 1.0.0
    Contact: hello@chatwoot.com
    Generated by OpenAPI Generator (https://openapi-generator.tech)

    Do not edit the class manually.
"""  # noqa: E501


from __future__ import annotations
import pprint
import re  # noqa: F401
import json

from pydantic import BaseModel, ConfigDict, Field, StrictBool, StrictInt, StrictStr, field_validator
from typing import Any, ClassVar, Dict, List, Optional
from typing import Optional, Set
from typing_extensions import Self

class Agent(BaseModel):
    """
    Agent
    """ # noqa: E501
    id: Optional[StrictInt] = None
    uid: Optional[StrictStr] = None
    name: Optional[StrictStr] = None
    available_name: Optional[StrictStr] = None
    display_name: Optional[StrictStr] = None
    email: Optional[StrictStr] = None
    account_id: Optional[StrictInt] = None
    role: Optional[StrictStr] = None
    confirmed: Optional[StrictBool] = None
    availability_status: Optional[StrictStr] = Field(default=None, description="The availability status of the agent computed by Chatwoot.")
    auto_offline: Optional[StrictBool] = Field(default=None, description="Whether the availability status of agent is configured to go offline automatically when away.")
    custom_attributes: Optional[Dict[str, Any]] = Field(default=None, description="Available for users who are created through platform APIs and has custom attributes associated.")
    __properties: ClassVar[List[str]] = ["id", "uid", "name", "available_name", "display_name", "email", "account_id", "role", "confirmed", "availability_status", "auto_offline", "custom_attributes"]

    @field_validator('role')
    def role_validate_enum(cls, value):
        """Validates the enum"""
        if value is None:
            return value

        if value not in set(['agent', 'administrator']):
            raise ValueError("must be one of enum values ('agent', 'administrator')")
        return value

    @field_validator('availability_status')
    def availability_status_validate_enum(cls, value):
        """Validates the enum"""
        if value is None:
            return value

        if value not in set(['available', 'busy', 'offline']):
            raise ValueError("must be one of enum values ('available', 'busy', 'offline')")
        return value

    model_config = ConfigDict(
        populate_by_name=True,
        validate_assignment=True,
        protected_namespaces=(),
    )


    def to_str(self) -> str:
        """Returns the string representation of the model using alias"""
        return pprint.pformat(self.model_dump(by_alias=True))

    def to_json(self) -> str:
        """Returns the JSON representation of the model using alias"""
        # TODO: pydantic v2: use .model_dump_json(by_alias=True, exclude_unset=True) instead
        return json.dumps(self.to_dict())

    @classmethod
    def from_json(cls, json_str: str) -> Optional[Self]:
        """Create an instance of Agent from a JSON string"""
        return cls.from_dict(json.loads(json_str))

    def to_dict(self) -> Dict[str, Any]:
        """Return the dictionary representation of the model using alias.

        This has the following differences from calling pydantic's
        `self.model_dump(by_alias=True)`:

        * `None` is only added to the output dict for nullable fields that
          were set at model initialization. Other fields with value `None`
          are ignored.
        """
        excluded_fields: Set[str] = set([
        ])

        _dict = self.model_dump(
            by_alias=True,
            exclude=excluded_fields,
            exclude_none=True,
        )
        return _dict

    @classmethod
    def from_dict(cls, obj: Optional[Dict[str, Any]]) -> Optional[Self]:
        """Create an instance of Agent from a dict"""
        if obj is None:
            return None

        if not isinstance(obj, dict):
            return cls.model_validate(obj)

        _obj = cls.model_validate({
            "id": obj.get("id"),
            "uid": obj.get("uid"),
            "name": obj.get("name"),
            "available_name": obj.get("available_name"),
            "display_name": obj.get("display_name"),
            "email": obj.get("email"),
            "account_id": obj.get("account_id"),
            "role": obj.get("role"),
            "confirmed": obj.get("confirmed"),
            "availability_status": obj.get("availability_status"),
            "auto_offline": obj.get("auto_offline"),
            "custom_attributes": obj.get("custom_attributes")
        })
        return _obj


