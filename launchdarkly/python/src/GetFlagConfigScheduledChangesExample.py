import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ScheduledChangesApi(api_client).get_flag_config_scheduled_changes(
            project_key="projectKey_string",
            feature_flag_key="featureFlagKey_string",
            environment_key="environmentKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ScheduledChangesApi#get_flag_config_scheduled_changes: %s\n" % e)
