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
    integrations_hook_create_payload = models.IntegrationsHookCreatePayload(
        app_id=None,
        inbox_id=None,
    )

    try:
        response = api.IntegrationsApi(api_client).create_an_integration_hook(
            account_id=None,
            integrations_hook_create_payload=integrations_hook_create_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationsApi#create_an_integration_hook: %s\n" % e)
