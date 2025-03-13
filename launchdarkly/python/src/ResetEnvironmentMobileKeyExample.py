import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.EnvironmentsApi(api_client).reset_environment_mobile_key(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling EnvironmentsApi#reset_environment_mobile_key: %s\n" % e)
