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
        response = api.ConversationsAPIApi(api_client).list_all_contact_conversations(
            inbox_identifier="inbox_identifier_string",
            contact_identifier="contact_identifier_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsAPIApi#list_all_contact_conversations: %s\n" % e)
