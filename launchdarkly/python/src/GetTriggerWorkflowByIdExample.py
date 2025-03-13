import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.FlagTriggersApi(api_client).get_trigger_workflow_by_id(
            project_key="projectKey_string",
            feature_flag_key="featureFlagKey_string",
            environment_key="environmentKey_string",
            id="id_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagTriggersApi#get_trigger_workflow_by_id: %s\n" % e)
