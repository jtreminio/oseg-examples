import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.SegmentsApi(api_client).create_big_segment_import(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            segment_key="segmentKey_string",
        )
    except ApiException as e:
        print("Exception when calling SegmentsApi#create_big_segment_import: %s\n" % e)
