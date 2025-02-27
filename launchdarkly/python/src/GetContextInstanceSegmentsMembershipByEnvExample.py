import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.SegmentsApi(api_client).get_context_instance_segments_membership_by_env(
            project_key=None,
            environment_key=None,
            request_body=json.loads("""
                {
                    "address": {
                        "city": "Springfield",
                        "street": "123 Main Street"
                    },
                    "jobFunction": "doctor",
                    "key": "context-key-123abc",
                    "kind": "user",
                    "name": "Sandy"
                }
            """),
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#get_context_instance_segments_membership_by_env: %s\n" % e)
