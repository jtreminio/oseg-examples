import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    public_message_update_payload = models.PublicMessageUpdatePayload(
    )

    try:
        response = api.MessagesAPIApi(api_client).update_a_message(
            inbox_identifier="inbox_identifier_string",
            contact_identifier="contact_identifier_string",
            conversation_id=0,
            message_id=0,
            data=public_message_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MessagesAPIApi#update_a_message: %s\n" % e)
