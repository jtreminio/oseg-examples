import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AgentBotsApi(api_client).list_all_agent_bots()

        pprint(response)
    except ApiException as e:
        print("Exception when calling AgentBotsApi#list_all_agent_bots: %s\n" % e)
