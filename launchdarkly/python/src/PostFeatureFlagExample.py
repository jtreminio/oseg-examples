import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    client_side_availability = models.ClientSideAvailabilityPost(
        usingEnvironmentId=True,
        usingMobileKey=True,
    )

    feature_flag_body = models.FeatureFlagBody(
        name="My Flag",
        key="flag-key-123abc",
        clientSideAvailability=client_side_availability,
    )

    try:
        response = api.FeatureFlagsApi(api_client).post_feature_flag(
            project_key="projectKey_string",
            feature_flag_body=feature_flag_body,
            clone=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsApi#post_feature_flag: %s\n" % e)
