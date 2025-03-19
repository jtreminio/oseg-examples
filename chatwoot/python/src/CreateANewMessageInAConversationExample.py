import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    template_params = models.ConversationMessageCreateTemplateParams(
        name="sample_issue_resolution",
        category="UTILITY",
        language="en_US",
        processed_params=json.loads("""
            {
                "1": "Chatwoot"
            }
        """),
    )

    conversation_message_create = models.ConversationMessageCreate(
        content="content_string",
        content_type="cards",
        template_params=template_params,
    )

    try:
        response = api.MessagesApi(api_client).create_a_new_message_in_a_conversation(
            account_id=0,
            conversation_id=0,
            data=conversation_message_create,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MessagesApi#create_a_new_message_in_a_conversation: %s\n" % e)
