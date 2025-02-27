import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    members_patch_input = models.MembersPatchInput(
        instructions=json.loads("""
            [
                {
                    "kind": "replaceMembersRoles",
                    "memberIDs": [
                        "1234a56b7c89d012345e678f",
                        "507f1f77bcf86cd799439011"
                    ],
                    "value": "reader"
                }
            ]
        """),
        comment="Optional comment about the update",
    )

    try:
        response = api.AccountMembersBetaApi(api_client).patch_members(
            members_patch_input=members_patch_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountMembersBetaApi#patch_members: %s\n" % e)
