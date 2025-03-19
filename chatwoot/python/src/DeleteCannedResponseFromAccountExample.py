import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.CannedResponsesApi(api_client).delete_canned_response_from_account(
            account_id=0,
            id=0,
        )
    except ApiException as e:
        print("Exception when calling CannedResponsesApi#delete_canned_response_from_account: %s\n" % e)
