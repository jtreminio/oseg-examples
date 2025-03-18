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
            project_key="projectKey_string",
            feature_flag_key="featureFlagKey_string",
            environment_key="environmentKey_string",
            id="id_string",
            flag_scheduled_changes_input=flag_scheduled_changes_input,
            ignore_conflicts=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ScheduledChangesApi#patch_flag_config_scheduled_change: %s\n" % e)
