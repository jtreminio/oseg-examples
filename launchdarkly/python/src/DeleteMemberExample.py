import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AccountMembersApi(api_client).delete_member(
            id="id_string",
        )
    except ApiException as e:
        print("Exception when calling AccountMembersApi#delete_member: %s\n" % e)
