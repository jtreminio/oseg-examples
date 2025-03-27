import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    update_custom_attributes_of_a_conversation_request = models.UpdateCustomAttributesOfAConversationRequest(
        custom_attributes=json.loads("""
            {
                "order_id": "12345",
                "previous_conversation": "67890"
            }
        """),
    )

    try:
        response = api.ConversationsApi(api_client).update_custom_attributes_of_a_conversation(
            account_id=0,
            conversation_id=0,
            data=update_custom_attributes_of_a_conversation_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsApi#update_custom_attributes_of_a_conversation: %s\n" % e)
