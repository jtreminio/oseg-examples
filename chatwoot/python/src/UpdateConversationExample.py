import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    update_conversation_request = models.UpdateConversationRequest(
    )

    try:
        api.ConversationsApi(api_client).update_conversation(
            account_id=0,
            conversation_id=0,
            data=update_conversation_request,
        )
    except ApiException as e:
        print("Exception when calling ConversationsApi#update_conversation: %s\n" % e)
