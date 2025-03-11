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
    custom_filter_create_update_payload = models.CustomFilterCreateUpdatePayload(
        name=None,
        type=None,
    )

    try:
        response = api.CustomFiltersApi(api_client).update_a_custom_filter(
            account_id=None,
            custom_filter_id=None,
            custom_filter_create_update_payload=custom_filter_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CustomFiltersApi#update_a_custom_filter: %s\n" % e)
