import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    custom_attribute_create_update_payload = models.CustomAttributeCreateUpdatePayload(
        attribute_values=[
        ],
    )

    try:
        response = api.CustomAttributesApi(api_client).add_new_custom_attribute_to_account(
            account_id=0,
            data=custom_attribute_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CustomAttributesApi#add_new_custom_attribute_to_account: %s\n" % e)
