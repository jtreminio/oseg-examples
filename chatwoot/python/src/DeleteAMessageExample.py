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
        api.MessagesApi(api_client).delete_a_message(
            account_id=None,
            conversation_id=None,
            message_id=None,
        )
    except ApiException as e:
        print("Exception when calling MessagesApi#delete_a_message: %s\n" % e)
