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
        response = api.ContactsApi(api_client).contact_conversations(
            account_id=0,
            id=0,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactsApi#contact_conversations: %s\n" % e)
