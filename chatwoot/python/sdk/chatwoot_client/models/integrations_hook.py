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

from pydantic import BaseModel, ConfigDict, Field, StrictBool, StrictStr
from typing import Any, ClassVar, Dict, List, Optional
from typing import Optional, Set
from typing_extensions import Self

class IntegrationsHook(BaseModel):
    """
    IntegrationsHook
    """ # noqa: E501
    id: Optional[StrictStr] = Field(default=None, description="The ID of the integration hook")
    app_id: Optional[StrictStr] = Field(default=None, description="The ID of the integration app")
    inbox_id: Optional[StrictStr] = Field(default=None, description="Inbox ID if its an Inbox integration")
    account_id: Optional[StrictStr] = Field(default=None, description="Account ID of the integration")
    status: Optional[StrictBool] = Field(default=None, description="Whether the integration hook is enabled for the account")
    hook_type: Optional[StrictBool] = Field(default=None, description="Whether its an account or inbox integration hook")
    settings: Optional[Dict[str, Any]] = Field(default=None, description="The associated settings for the integration")
    __properties: ClassVar[List[str]] = ["id", "app_id", "inbox_id", "account_id", "status", "hook_type", "settings"]

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
        """Create an instance of IntegrationsHook from a JSON string"""
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
        """Create an instance of IntegrationsHook from a dict"""
        if obj is None:
            return None

        if not isinstance(obj, dict):
            return cls.model_validate(obj)

        _obj = cls.model_validate({
            "id": obj.get("id"),
            "app_id": obj.get("app_id"),
            "inbox_id": obj.get("inbox_id"),
            "account_id": obj.get("account_id"),
            "status": obj.get("status"),
            "hook_type": obj.get("hook_type"),
            "settings": obj.get("settings")
        })
        return _obj


