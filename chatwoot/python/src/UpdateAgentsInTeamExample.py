import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    update_agents_in_team_request = models.UpdateAgentsInTeamRequest(
        user_ids=[
        ],
    )

    try:
        response = api.TeamsApi(api_client).update_agents_in_team(
            account_id=0,
            team_id=0,
            data=update_agents_in_team_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling TeamsApi#update_agents_in_team: %s\n" % e)
