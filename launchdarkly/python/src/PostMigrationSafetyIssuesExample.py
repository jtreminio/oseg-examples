import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    flag_sempatch = models.FlagSempatch(
        instructions=[],
    )

    try:
        response = api.FeatureFlagsApi(api_client).post_migration_safety_issues(
            project_key="projectKey_string",
            flag_key="flagKey_string",
            environment_key="environmentKey_string",
            flag_sempatch=flag_sempatch,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsApi#post_migration_safety_issues: %s\n" % e)
