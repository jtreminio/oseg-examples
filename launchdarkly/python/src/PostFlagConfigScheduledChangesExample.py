import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    post_flag_scheduled_changes_input = models.PostFlagScheduledChangesInput(
        executionDate=1718467200000,
        instructions=json.loads("""
            [
                {
                    "kind": "turnFlagOn"
                }
            ]
        """),
        comment="Optional comment describing the scheduled changes",
    )

    try:
        response = api.ScheduledChangesApi(api_client).post_flag_config_scheduled_changes(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            post_flag_scheduled_changes_input=post_flag_scheduled_changes_input,
            ignore_conflicts=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ScheduledChanges#post_flag_config_scheduled_changes: %s\n" % e)
