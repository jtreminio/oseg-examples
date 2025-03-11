import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.UsersApi(api_client).get_sso_url_of_a_user(
            id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UsersApi#get_sso_url_of_a_user: %s\n" % e)
