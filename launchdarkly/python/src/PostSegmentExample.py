import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    segment_body = models.SegmentBody(
        name="Example segment",
        key="segment-key-123abc",
        description="Bundle our sample customers together",
        unbounded=False,
        unboundedContextKind="device",
        tags=[
            "testing",
        ],
    )

    try:
        response = api.SegmentsApi(api_client).post_segment(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            segment_body=segment_body,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#post_segment: %s\n" % e)
