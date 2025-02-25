import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ContextsApi(api_client).evaluate_context_instance(
            project_key=None,
            environment_key=None,
            request_body=json.loads("""
                {
                    "key": "user-key-123abc",
                    "kind": "user",
                    "otherAttribute": "other attribute value"
                }
            """),
            limit=None,
            offset=None,
            sort=None,
            filter=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Contexts#evaluate_context_instance: %s\n" % e)
