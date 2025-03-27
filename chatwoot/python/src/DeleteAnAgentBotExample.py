import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AgentBotsApi(api_client).delete_an_agent_bot(
            id=0,
        )
    except ApiException as e:
        print("Exception when calling AgentBotsApi#delete_an_agent_bot: %s\n" % e)
