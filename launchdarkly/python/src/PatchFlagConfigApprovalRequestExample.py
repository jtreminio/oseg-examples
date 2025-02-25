import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ApprovalsBetaApi(api_client).patch_flag_config_approval_request(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApprovalsBeta#patch_flag_config_approval_request: %s\n" % e)
