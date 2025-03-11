import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    custom_attribute_create_update_payload = models.CustomAttributeCreateUpdatePayload(
        attribute_display_name=None,
        attribute_display_type=None,
        attribute_description=None,
        attribute_key=None,
        attribute_model=None,
        attribute_values=[
        ],
    )

    try:
        response = api.CustomAttributesApi(api_client).update_custom_attribute_in_account(
            account_id=None,
            id=None,
            custom_attribute_create_update_payload=custom_attribute_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CustomAttributesApi#update_custom_attribute_in_account: %s\n" % e)
