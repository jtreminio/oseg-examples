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
        response = api.ConversationsAPIApi(api_client).resolve_conversation(
            inbox_identifier=None,
            contact_identifier=None,
            conversation_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsAPIApi#resolve_conversation: %s\n" % e)
