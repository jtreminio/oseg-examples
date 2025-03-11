import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AccountsApi(api_client).get_details_of_an_account(
            account_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountsApi#get_details_of_an_account: %s\n" % e)
