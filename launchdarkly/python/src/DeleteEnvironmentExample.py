import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.EnvironmentsApi(api_client).delete_environment(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
        )
    except ApiException as e:
        print("Exception when calling EnvironmentsApi#delete_environment: %s\n" % e)
