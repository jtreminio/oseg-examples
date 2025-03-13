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
        path="/exampleField",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.ProjectsApi(api_client).patch_flag_defaults_by_project(
            project_key="projectKey_string",
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ProjectsApi#patch_flag_defaults_by_project: %s\n" % e)
