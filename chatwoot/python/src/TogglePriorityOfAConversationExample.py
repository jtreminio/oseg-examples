import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    toggle_priority_of_a_conversation_request = models.TogglePriorityOfAConversationRequest(
        priority=None,
    )

    try:
        api.ConversationsApi(api_client).toggle_priority_of_a_conversation(
            account_id=None,
            conversation_id=None,
            toggle_priority_of_a_conversation_request=toggle_priority_of_a_conversation_request,
        )
    except ApiException as e:
        print("Exception when calling ConversationsApi#toggle_priority_of_a_conversation: %s\n" % e)
