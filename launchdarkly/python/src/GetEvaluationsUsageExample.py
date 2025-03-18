import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AccountUsageBetaApi(api_client).get_evaluations_usage(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            feature_flag_key="featureFlagKey_string",
            var_from=None,
            to=None,
            tz=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountUsageBetaApi#get_evaluations_usage: %s\n" % e)
