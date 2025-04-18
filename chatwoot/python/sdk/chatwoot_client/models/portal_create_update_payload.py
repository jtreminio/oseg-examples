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

from pydantic import BaseModel, ConfigDict, Field, StrictBool, StrictInt, StrictStr
from typing import Any, ClassVar, Dict, List, Optional
from typing import Optional, Set
from typing_extensions import Self

class PortalCreateUpdatePayload(BaseModel):
    """
    PortalCreateUpdatePayload
    """ # noqa: E501
    archived: Optional[StrictBool] = Field(default=None, description="Status to check if portal is live")
    color: Optional[StrictStr] = Field(default=None, description="Header color for help-center")
    config: Optional[Dict[str, Any]] = Field(default=None, description="Configuration about supporting locales")
    custom_domain: Optional[StrictStr] = Field(default=None, description="Custom domain to  display help center.")
    header_text: Optional[StrictStr] = Field(default=None, description="Help center header")
    homepage_link: Optional[StrictStr] = Field(default=None, description="link to main dashboard")
    name: Optional[StrictStr] = Field(default=None, description="Name for the portal")
    slug: Optional[StrictStr] = Field(default=None, description="Slug for the portal to display in link")
    page_title: Optional[StrictStr] = Field(default=None, description="Page title for the portal")
    account_id: Optional[StrictInt] = None
    __properties: ClassVar[List[str]] = ["archived", "color", "config", "custom_domain", "header_text", "homepage_link", "name", "slug", "page_title", "account_id"]

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
        """Create an instance of PortalCreateUpdatePayload from a JSON string"""
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
        """Create an instance of PortalCreateUpdatePayload from a dict"""
        if obj is None:
            return None

        if not isinstance(obj, dict):
            return cls.model_validate(obj)

        _obj = cls.model_validate({
            "archived": obj.get("archived"),
            "color": obj.get("color"),
            "config": obj.get("config"),
            "custom_domain": obj.get("custom_domain"),
            "header_text": obj.get("header_text"),
            "homepage_link": obj.get("homepage_link"),
            "name": obj.get("name"),
            "slug": obj.get("slug"),
            "page_title": obj.get("page_title"),
            "account_id": obj.get("account_id")
        })
        return _obj


