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
        path="/on",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.IntegrationsBetaApi(api_client).update_integration_configuration(
            integration_configuration_id="integrationConfigurationId_string",
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationsBetaApi#update_integration_configuration: %s\n" % e)
