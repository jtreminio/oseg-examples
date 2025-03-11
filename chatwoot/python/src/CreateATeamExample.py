import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
    # api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    team_create_update_payload = models.TeamCreateUpdatePayload(
        name=None,
        description=None,
        allow_auto_assign=None,
    )

    try:
        response = api.TeamsApi(api_client).create_a_team(
            account_id=None,
            team_create_update_payload=team_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling TeamsApi#create_a_team: %s\n" % e)
