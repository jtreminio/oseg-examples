import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.HelpCenterApi(api_client).get_portal(
            account_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HelpCenterApi#get_portal: %s\n" % e)
