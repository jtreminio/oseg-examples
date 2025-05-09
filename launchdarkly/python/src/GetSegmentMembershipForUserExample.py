import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.SegmentsApi(api_client).get_segment_membership_for_user(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            segment_key="segmentKey_string",
            user_key="userKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#get_segment_membership_for_user: %s\n" % e)
