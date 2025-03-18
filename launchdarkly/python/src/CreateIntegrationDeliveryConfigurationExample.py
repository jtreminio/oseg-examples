import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    integration_delivery_configuration_post = models.IntegrationDeliveryConfigurationPost(
        config=json.loads("""
            {
                "optional": "example value for optional formVariables property for sample-integration",
                "required": "example value for required formVariables property for sample-integration"
            }
        """),
        on=False,
        name="Sample integration",
        tags=[
            "example-tag",
        ],
    )

    try:
        response = api.IntegrationDeliveryConfigurationsBetaApi(api_client).create_integration_delivery_configuration(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            integration_key="integrationKey_string",
            integration_delivery_configuration_post=integration_delivery_configuration_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationDeliveryConfigurationsBetaApi#create_integration_delivery_configuration: %s\n" % e)
