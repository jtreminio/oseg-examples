import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ContextsApi(api_client).delete_context_instances(
            project_key=None,
            environment_key=None,
            id=None,
        )
    except ApiException as e:
        print("Exception when calling Contexts#delete_context_instances: %s\n" % e)
