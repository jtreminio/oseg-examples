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
    contact_inbox_creation_request = models.ContactInboxCreationRequest(
        inbox_id=0,
    )

    try:
        response = api.ContactApi(api_client).contact_inbox_creation(
            account_id=0,
            id=0,
            data=contact_inbox_creation_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactApi#contact_inbox_creation: %s\n" % e)
