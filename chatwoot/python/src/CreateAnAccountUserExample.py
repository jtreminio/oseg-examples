import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    create_an_account_user_request = models.CreateAnAccountUserRequest(
        role=None,
        user_id=None,
    )

    try:
        response = api.AccountUsersApi(api_client).create_an_account_user(
            account_id=None,
            create_an_account_user_request=create_an_account_user_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountUsersApi#create_an_account_user: %s\n" % e)
