import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.FlagTriggersApi(api_client).delete_trigger_workflow(
            project_key=None,
            environment_key=None,
            feature_flag_key=None,
            id=None,
        )
    except ApiException as e:
        print("Exception when calling FlagTriggers#delete_trigger_workflow: %s\n" % e)
