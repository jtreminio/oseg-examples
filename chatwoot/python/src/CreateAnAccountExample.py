import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    account_create_update_payload = models.AccountCreateUpdatePayload(
        name=None,
    )

    try:
        response = api.AccountsApi(api_client).create_an_account(
            account_create_update_payload=account_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountsApi#create_an_account: %s\n" % e)
