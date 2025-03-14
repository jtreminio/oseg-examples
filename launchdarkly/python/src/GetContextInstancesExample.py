import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ContextsApi(api_client).get_context_instances(
            project_key=None,
            environment_key=None,
            id=None,
            limit=None,
            continuation_token=None,
            sort=None,
            filter=None,
            include_total_count=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContextsApi#get_context_instances: %s\n" % e)
