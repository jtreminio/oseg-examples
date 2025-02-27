import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ApprovalsApi(api_client).delete_approval_request_for_flag(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            id=None,
        )
    except ApiException as e:
        print("Exception when calling ApprovalsApi#delete_approval_request_for_flag: %s\n" % e)
