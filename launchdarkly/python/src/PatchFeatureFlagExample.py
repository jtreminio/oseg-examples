import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_1 = models.PatchOperation(
        op="replace",
        path="/description",
    )

    patch = [
        patch_1,
    ]

    patch_with_comment = models.PatchWithComment(
        patch=patch,
    )

    try:
        response = api.FeatureFlagsApi(api_client).patch_feature_flag(
            project_key="projectKey_string",
            feature_flag_key="featureFlagKey_string",
            patch_with_comment=patch_with_comment,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsApi#patch_feature_flag: %s\n" % e)
