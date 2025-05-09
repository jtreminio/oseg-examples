import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    public_conversation_create_payload = models.PublicConversationCreatePayload(
    )

    try:
        response = api.ConversationsAPIApi(api_client).create_a_conversation(
            inbox_identifier="inbox_identifier_string",
            contact_identifier="contact_identifier_string",
            data=public_conversation_create_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsAPIApi#create_a_conversation: %s\n" % e)
