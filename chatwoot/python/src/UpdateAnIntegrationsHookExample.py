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
    integrations_hook_update_payload = models.IntegrationsHookUpdatePayload(
    )

    try:
        response = api.IntegrationsApi(api_client).update_an_integrations_hook(
            account_id=0,
            hook_id=0,
            data=integrations_hook_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationsApi#update_an_integrations_hook: %s\n" % e)
