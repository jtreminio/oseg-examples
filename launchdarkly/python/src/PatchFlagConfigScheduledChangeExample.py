import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    flag_scheduled_changes_input = models.FlagScheduledChangesInput(
        instructions=json.loads("""
            [
                {
                    "kind": "replaceScheduledChangesInstructions",
                    "value": [
                        {
                            "kind": "turnFlagOff"
                        }
                    ]
                }
            ]
        """),
        comment="Optional comment describing the update to the scheduled changes",
    )

    try:
        response = api.ScheduledChangesApi(api_client).patch_flag_config_scheduled_change(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            id=None,
            flag_scheduled_changes_input=flag_scheduled_changes_input,
            ignore_conflicts=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ScheduledChangesApi#patch_flag_config_scheduled_change: %s\n" % e)
