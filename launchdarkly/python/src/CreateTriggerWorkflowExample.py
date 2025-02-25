import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    trigger_post = models.TriggerPost(
        integrationKey="generic-trigger",
        comment="example comment",
        instructions=json.loads("""
            [
                {
                    "kind": "turnFlagOn"
                }
            ]
        """),
    )

    try:
        response = api.FlagTriggersApi(api_client).create_trigger_workflow(
            project_key=None,
            environment_key=None,
            feature_flag_key=None,
            trigger_post=trigger_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagTriggers#create_trigger_workflow: %s\n" % e)
