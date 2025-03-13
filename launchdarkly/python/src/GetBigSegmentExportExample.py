import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.SegmentsApi(api_client).get_big_segment_export(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            segment_key="segmentKey_string",
            export_id="exportID_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#get_big_segment_export: %s\n" % e)
