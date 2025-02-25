import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.EnvironmentsApi(api_client).reset_environment_sdk_key(
            project_key=None,
            environment_key=None,
            expiry=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Environments#reset_environment_sdk_key: %s\n" % e)
