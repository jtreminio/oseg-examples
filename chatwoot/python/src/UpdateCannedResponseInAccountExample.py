import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    canned_response_create_update_payload = models.CannedResponseCreateUpdatePayload(
    )

    try:
        response = api.CannedResponseApi(api_client).update_canned_response_in_account(
            account_id=0,
            id=0,
            data=canned_response_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CannedResponseApi#update_canned_response_in_account: %s\n" % e)
