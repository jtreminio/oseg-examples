import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.CustomRolesApi(api_client).delete_custom_role(
            custom_role_key=None,
        )
    except ApiException as e:
        print("Exception when calling CustomRolesApi#delete_custom_role: %s\n" % e)
