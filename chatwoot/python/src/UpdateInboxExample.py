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
    update_inbox_request = models.UpdateInboxRequest(
        enable_auto_assignment=False,
    )

    try:
        response = api.InboxesApi(api_client).update_inbox(
            account_id=0,
            id=0,
            data=update_inbox_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InboxesApi#update_inbox: %s\n" % e)
