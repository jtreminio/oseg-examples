import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    flag_trigger_input = models.FlagTriggerInput(
        comment="optional comment",
        instructions=json.loads("""
            [
                {
                    "kind": "disableTrigger"
                }
            ]
        """),
    )

    try:
        response = api.FlagTriggersApi(api_client).patch_trigger_workflow(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            feature_flag_key="featureFlagKey_string",
            id="id_string",
            flag_trigger_input=flag_trigger_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagTriggersApi#patch_trigger_workflow: %s\n" % e)
