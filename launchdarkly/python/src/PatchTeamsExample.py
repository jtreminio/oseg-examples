import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    teams_patch_input = models.TeamsPatchInput(
        instructions=json.loads("""
            [
                {
                    "kind": "addMembersToTeams",
                    "memberIDs": [
                        "1234a56b7c89d012345e678f"
                    ],
                    "teamKeys": [
                        "example-team-1",
                        "example-team-2"
                    ]
                }
            ]
        """),
        comment="Optional comment about the update",
    )

    try:
        response = api.TeamsBetaApi(api_client).patch_teams(
            teams_patch_input=teams_patch_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling TeamsBeta#patch_teams: %s\n" % e)
