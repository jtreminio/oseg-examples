import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.FeatureFlagsBetaApi(api_client).get_dependent_flags_by_env(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            feature_flag_key="featureFlagKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsBetaApi#get_dependent_flags_by_env: %s\n" % e)
