import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    delete_an_account_user_request = models.DeleteAnAccountUserRequest(
        user_id=0,
    )

    try:
        api.AccountUsersApi(api_client).delete_an_account_user(
            account_id=0,
            data=delete_an_account_user_request,
        )
    except ApiException as e:
        print("Exception when calling AccountUsersApi#delete_an_account_user: %s\n" % e)
