import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.FeatureFlagsApi(api_client).get_feature_flag_statuses(
            project_key=None,
            environment_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlags#get_feature_flag_statuses: %s\n" % e)
