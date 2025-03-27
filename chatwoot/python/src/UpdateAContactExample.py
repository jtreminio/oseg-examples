import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    public_contact_create_update_payload = models.PublicContactCreateUpdatePayload(
    )

    try:
        response = api.ContactsAPIApi(api_client).update_a_contact(
            inbox_identifier="inbox_identifier_string",
            contact_identifier="contact_identifier_string",
            data=public_contact_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactsAPIApi#update_a_contact: %s\n" % e)
