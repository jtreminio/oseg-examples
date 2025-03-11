import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    assign_a_conversation_request = models.AssignAConversationRequest(
        assignee_id=None,
        team_id=None,
    )

    try:
        response = api.ConversationAssignmentApi(api_client).assign_a_conversation(
            account_id=None,
            conversation_id=None,
            assign_a_conversation_request=assign_a_conversation_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationAssignmentApi#assign_a_conversation: %s\n" % e)
