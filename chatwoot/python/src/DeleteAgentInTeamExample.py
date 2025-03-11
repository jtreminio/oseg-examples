import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    delete_agent_in_team_request = models.DeleteAgentInTeamRequest(
        user_ids=[
        ],
    )

    try:
        api.TeamsApi(api_client).delete_agent_in_team(
            account_id=None,
            team_id=None,
            delete_agent_in_team_request=delete_agent_in_team_request,
        )
    except ApiException as e:
        print("Exception when calling TeamsApi#delete_agent_in_team: %s\n" % e)
