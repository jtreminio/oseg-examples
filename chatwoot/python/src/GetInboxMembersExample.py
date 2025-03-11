import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InboxesApi(api_client).get_inbox_members(
            account_id=None,
            inbox_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InboxesApi#get_inbox_members: %s\n" % e)
