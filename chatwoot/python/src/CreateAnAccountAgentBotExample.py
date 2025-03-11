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
    agent_bot_create_update_payload = models.AgentBotCreateUpdatePayload(
        name=None,
        description=None,
        outgoing_url=None,
    )

    try:
        response = api.AccountAgentBotsApi(api_client).create_an_account_agent_bot(
            account_id=None,
            agent_bot_create_update_payload=agent_bot_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountAgentBotsApi#create_an_account_agent_bot: %s\n" % e)
