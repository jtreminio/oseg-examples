import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.CannedResponsesApi(api_client).get_account_canned_response(
            account_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CannedResponsesApi#get_account_canned_response: %s\n" % e)
