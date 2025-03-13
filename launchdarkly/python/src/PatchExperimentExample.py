import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    experiment_patch_input = models.ExperimentPatchInput(
        instructions=json.loads("""
            [
                {
                    "kind": "updateName",
                    "value": "Updated experiment name"
                }
            ]
        """),
        comment="Example comment describing the update",
    )

    try:
        response = api.ExperimentsApi(api_client).patch_experiment(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            experiment_key="experimentKey_string",
            experiment_patch_input=experiment_patch_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#patch_experiment: %s\n" % e)
