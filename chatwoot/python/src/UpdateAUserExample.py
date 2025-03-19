import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    user_create_update_payload = models.UserCreateUpdatePayload(
    )

    try:
        response = api.UsersApi(api_client).update_a_user(
            id=0,
            data=user_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UsersApi#update_a_user: %s\n" % e)
