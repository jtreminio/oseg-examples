import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    category_create_update_payload = models.CategoryCreateUpdatePayload(
        locale="en/es",
    )

    try:
        response = api.HelpCenterApi(api_client).add_new_category_to_account(
            account_id=0,
            portal_id=0,
            data=category_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HelpCenterApi#add_new_category_to_account: %s\n" % e)
