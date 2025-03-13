import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.FollowFlagsApi(api_client).put_flag_follower(
            project_key="projectKey_string",
            feature_flag_key="featureFlagKey_string",
            environment_key="environmentKey_string",
            member_id="memberId_string",
        )
    except ApiException as e:
        print("Exception when calling FollowFlagsApi#put_flag_follower: %s\n" % e)
