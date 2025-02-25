import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    team_patch_input = models.TeamPatchInput(
        instructions=json.loads("""
            [
                {
                    "kind": "updateDescription",
                    "value": "New description for the team"
                }
            ]
        """),
        comment="Optional comment about the update",
    )

    try:
        response = api.TeamsApi(api_client).patch_team(
            team_key=None,
            team_patch_input=team_patch_input,
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Teams#patch_team: %s\n" % e)
