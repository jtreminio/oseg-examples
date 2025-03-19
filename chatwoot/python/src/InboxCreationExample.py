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
    inbox_creation_request = models.InboxCreationRequest(
    )

    try:
        response = api.InboxesApi(api_client).inbox_creation(
            account_id=0,
            data=inbox_creation_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InboxesApi#inbox_creation: %s\n" % e)
