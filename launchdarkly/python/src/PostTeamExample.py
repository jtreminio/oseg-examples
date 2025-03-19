import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    team_post_input = models.TeamPostInput(
        key="team-key-123abc",
        name="Example team",
        description="An example team",
        customRoleKeys=[
            "example-role1",
            "example-role2",
        ],
        memberIDs=[
            "12ab3c45de678910fgh12345",
        ],
    )

    try:
        response = api.TeamsApi(api_client).post_team(
            team_post_input=team_post_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling TeamsApi#post_team: %s\n" % e)
