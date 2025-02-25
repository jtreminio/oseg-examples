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
        path="/supported",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.ApplicationsBetaApi(api_client).patch_application_version(
            application_key=None,
            version_key=None,
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApplicationsBeta#patch_application_version: %s\n" % e)
