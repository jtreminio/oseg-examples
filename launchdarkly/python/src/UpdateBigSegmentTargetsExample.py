import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    included = models.SegmentUserList(
        add=[
        ],
        remove=[
        ],
    )

    excluded = models.SegmentUserList(
        add=[
        ],
        remove=[
        ],
    )

    segment_user_state = models.SegmentUserState(
        included=included,
        excluded=excluded,
    )

    try:
        api.SegmentsApi(api_client).update_big_segment_targets(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            segment_key="segmentKey_string",
            segment_user_state=segment_user_state,
        )
    except ApiException as e:
        print("Exception when calling SegmentsApi#update_big_segment_targets: %s\n" % e)
