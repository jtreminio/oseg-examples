import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ContactsAPIApi(api_client).get_details_of_a_contact(
            inbox_identifier="inbox_identifier_string",
            contact_identifier="contact_identifier_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactsAPIApi#get_details_of_a_contact: %s\n" % e)
