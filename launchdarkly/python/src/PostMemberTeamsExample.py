import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    member_teams_post_input = models.MemberTeamsPostInput(
        teamKeys=[
            "team1",
            "team2",
        ],
    )

    try:
        response = api.AccountMembersApi(api_client).post_member_teams(
            id=None,
            member_teams_post_input=member_teams_post_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountMembersApi#post_member_teams: %s\n" % e)
