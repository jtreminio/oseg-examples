import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.IntegrationDeliveryConfigurationsBetaApi(api_client).validate_integration_delivery_configuration(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            integration_key="integrationKey_string",
            id="id_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationDeliveryConfigurationsBetaApi#validate_integration_delivery_configuration: %s\n" % e)
