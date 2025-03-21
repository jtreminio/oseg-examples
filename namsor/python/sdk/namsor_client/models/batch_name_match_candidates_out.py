# coding: utf-8

"""
    NamSor API v2

    NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 

    The version of the OpenAPI document: 2.0.29
    Contact: contact@namsor.com
    Generated by OpenAPI Generator (https://openapi-generator.tech)

    Do not edit the class manually.
"""  # noqa: E501


from __future__ import annotations
import pprint
import re  # noqa: F401
import json

from pydantic import BaseModel, ConfigDict, Field
from typing import Any, ClassVar, Dict, List, Optional
from namsor_client.models.name_match_candidates_out import NameMatchCandidatesOut
from typing import Optional, Set
from typing_extensions import Self

class BatchNameMatchCandidatesOut(BaseModel):
    """
    BatchNameMatchCandidatesOut
    """ # noqa: E501
    names_and_match_candidates: Optional[List[NameMatchCandidatesOut]] = Field(default=None, description="Classified matched names", alias="namesAndMatchCandidates")
    __properties: ClassVar[List[str]] = ["namesAndMatchCandidates"]

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
        """Create an instance of BatchNameMatchCandidatesOut from a JSON string"""
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
        # override the default output from pydantic by calling `to_dict()` of each item in names_and_match_candidates (list)
        _items = []
        if self.names_and_match_candidates:
            for _item_names_and_match_candidates in self.names_and_match_candidates:
                if _item_names_and_match_candidates:
                    _items.append(_item_names_and_match_candidates.to_dict())
            _dict['namesAndMatchCandidates'] = _items
        return _dict

    @classmethod
    def from_dict(cls, obj: Optional[Dict[str, Any]]) -> Optional[Self]:
        """Create an instance of BatchNameMatchCandidatesOut from a dict"""
        if obj is None:
            return None

        if not isinstance(obj, dict):
            return cls.model_validate(obj)

        _obj = cls.model_validate({
            "namesAndMatchCandidates": [NameMatchCandidatesOut.from_dict(_item) for _item in obj["namesAndMatchCandidates"]] if obj.get("namesAndMatchCandidates") is not None else None
        })
        return _obj


