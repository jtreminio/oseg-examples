import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    public_contact_create_update_payload = models.PublicContactCreateUpdatePayload(
        identifier=None,
        identifier_hash=None,
        email=None,
        name=None,
        phone_number=None,
        avatar_url=None,
    )

    try:
        response = api.ContactsAPIApi(api_client).create_a_contact(
            inbox_identifier=None,
            public_contact_create_update_payload=public_contact_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactsAPIApi#create_a_contact: %s\n" % e)
