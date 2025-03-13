import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_operation_1 = models.PatchOperation(
        op="replace",
        path="/requireComments",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.EnvironmentsApi(api_client).patch_environment(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling EnvironmentsApi#patch_environment: %s\n" % e)
