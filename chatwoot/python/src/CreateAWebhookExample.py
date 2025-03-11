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
    webhook_create_update_payload = models.WebhookCreateUpdatePayload(
        url=None,
        subscriptions=[
        ],
    )

    try:
        response = api.WebhooksApi(api_client).create_a_webhook(
            account_id=None,
            webhook_create_update_payload=webhook_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling WebhooksApi#create_a_webhook: %s\n" % e)
