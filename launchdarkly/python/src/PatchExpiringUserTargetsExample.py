import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_flags_request = models.PatchFlagsRequest(
        instructions=json.loads("""
            [
                {
                    "kind": "addExpireUserTargetDate",
                    "userKey": "sandy",
                    "value": 1686412800000,
                    "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
                }
            ]
        """),
        comment="optional comment",
    )

    try:
        response = api.FeatureFlagsApi(api_client).patch_expiring_user_targets(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            feature_flag_key="featureFlagKey_string",
            patch_flags_request=patch_flags_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsApi#patch_expiring_user_targets: %s\n" % e)
