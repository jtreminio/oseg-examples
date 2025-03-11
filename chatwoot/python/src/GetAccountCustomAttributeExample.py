import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.CustomAttributesApi(api_client).get_account_custom_attribute(
            account_id=None,
            attribute_model=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CustomAttributesApi#get_account_custom_attribute: %s\n" % e)
