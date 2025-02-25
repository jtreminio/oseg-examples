import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.SegmentsApi(api_client).create_big_segment_export(
            project_key=None,
            environment_key=None,
            segment_key=None,
        )
    except ApiException as e:
        print("Exception when calling Segments#create_big_segment_export: %s\n" % e)
