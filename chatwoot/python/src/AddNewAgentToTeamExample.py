import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    add_new_agent_to_team_request = models.AddNewAgentToTeamRequest(
        user_ids=[
        ],
    )

    try:
        response = api.TeamsApi(api_client).add_new_agent_to_team(
            account_id=0,
            team_id=0,
            data=add_new_agent_to_team_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling TeamsApi#add_new_agent_to_team: %s\n" % e)
