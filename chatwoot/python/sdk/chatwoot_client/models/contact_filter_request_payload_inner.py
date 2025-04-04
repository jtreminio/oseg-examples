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

from pydantic import BaseModel, ConfigDict, Field, StrictStr, field_validator
from typing import Any, ClassVar, Dict, List, Optional
from typing import Optional, Set
from typing_extensions import Self

class ContactFilterRequestPayloadInner(BaseModel):
    """
    ContactFilterRequestPayloadInner
    """ # noqa: E501
    attribute_key: Optional[StrictStr] = Field(default=None, description="filter attribute name")
    filter_operator: Optional[StrictStr] = Field(default=None, description="filter operator name")
    values: Optional[List[StrictStr]] = Field(default=None, description="array of the attribute values to filter")
    query_operator: Optional[StrictStr] = Field(default=None, description="query operator name")
    __properties: ClassVar[List[str]] = ["attribute_key", "filter_operator", "values", "query_operator"]

    @field_validator('filter_operator')
    def filter_operator_validate_enum(cls, value):
        """Validates the enum"""
        if value is None:
            return value

        if value not in set(['equal_to', 'not_equal_to', 'contains', 'does_not_contain']):
            raise ValueError("must be one of enum values ('equal_to', 'not_equal_to', 'contains', 'does_not_contain')")
        return value

    @field_validator('query_operator')
    def query_operator_validate_enum(cls, value):
        """Validates the enum"""
        if value is None:
            return value

        if value not in set(['AND', 'OR']):
            raise ValueError("must be one of enum values ('AND', 'OR')")
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
        """Create an instance of ContactFilterRequestPayloadInner from a JSON string"""
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
        """Create an instance of ContactFilterRequestPayloadInner from a dict"""
        if obj is None:
            return None

        if not isinstance(obj, dict):
            return cls.model_validate(obj)

        _obj = cls.model_validate({
            "attribute_key": obj.get("attribute_key"),
            "filter_operator": obj.get("filter_operator"),
            "values": obj.get("values"),
            "query_operator": obj.get("query_operator")
        })
        return _obj


