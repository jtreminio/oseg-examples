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
    try:
        api.IntegrationsApi(api_client).delete_an_integration_hook(
            account_id=None,
            hook_id=None,
        )
    except ApiException as e:
        print("Exception when calling IntegrationsApi#delete_an_integration_hook: %s\n" % e)
