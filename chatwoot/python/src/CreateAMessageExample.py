import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    public_message_create_payload = models.PublicMessageCreatePayload(
        content=None,
        echo_id=None,
    )

    try:
        response = api.MessagesAPIApi(api_client).create_a_message(
            inbox_identifier=None,
            contact_identifier=None,
            conversation_id=None,
            public_message_create_payload=public_message_create_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MessagesAPIApi#create_a_message: %s\n" % e)
