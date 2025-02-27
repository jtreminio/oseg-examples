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
        path="/phases/0/complete",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.ReleasesBetaApi(api_client).patch_release_by_flag_key(
            project_key=None,
            flag_key=None,
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasesBetaApi#patch_release_by_flag_key: %s\n" % e)
