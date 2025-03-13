import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    holdout_patch_input = models.HoldoutPatchInput(
        instructions=json.loads("""
            [
                {
                    "kind": "updateName",
                    "value": "Updated holdout name"
                }
            ]
        """),
        comment="Optional comment describing the update",
    )

    try:
        response = api.HoldoutsBetaApi(api_client).patch_holdout(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            holdout_key="holdoutKey_string",
            holdout_patch_input=holdout_patch_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HoldoutsBetaApi#patch_holdout: %s\n" % e)
