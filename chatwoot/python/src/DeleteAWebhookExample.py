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
        api.WebhooksApi(api_client).delete_a_webhook(
            account_id=None,
            webhook_id=None,
        )
    except ApiException as e:
        print("Exception when calling WebhooksApi#delete_a_webhook: %s\n" % e)
