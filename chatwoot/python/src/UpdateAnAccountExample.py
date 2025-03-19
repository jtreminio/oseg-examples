import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    account_create_update_payload = models.AccountCreateUpdatePayload(
    )

    try:
        response = api.AccountsApi(api_client).update_an_account(
            account_id=0,
            data=account_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountsApi#update_an_account: %s\n" % e)
