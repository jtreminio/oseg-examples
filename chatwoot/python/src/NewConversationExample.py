import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    message_template_params = models.NewConversationRequestMessageTemplateParams(
        name="sample_issue_resolution",
        category="UTILITY",
        language="en_US",
        processed_params=json.loads("""
            {
                "1": "Chatwoot"
            }
        """),
    )

    message = models.NewConversationRequestMessage(
        content="content_string",
        template_params=message_template_params,
    )

    new_conversation_request = models.NewConversationRequest(
        inbox_id="inbox_id_string",
        source_id="source_id_string",
        custom_attributes=json.loads("""
            {
                "attribute_key": "attribute_value",
                "priority_conversation_number": 3
            }
        """),
        message=message,
    )

    try:
        response = api.ConversationsApi(api_client).new_conversation(
            account_id=0,
            data=new_conversation_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsApi#new_conversation: %s\n" % e)
