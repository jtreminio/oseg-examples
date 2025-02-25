import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.WorkflowsApi(api_client).get_workflows(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            status=None,
            sort=None,
            limit=None,
            offset=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Workflows#get_workflows: %s\n" % e)
