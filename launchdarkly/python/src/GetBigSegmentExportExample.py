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
            project_key=None,
            environment_key=None,
            segment_key=None,
            export_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#get_big_segment_export: %s\n" % e)
