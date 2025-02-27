import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.IntegrationDeliveryConfigurationsBetaApi(api_client).delete_integration_delivery_configuration(
            project_key=None,
            environment_key=None,
            integration_key=None,
            id=None,
        )
    except ApiException as e:
        print("Exception when calling IntegrationDeliveryConfigurationsBetaApi#delete_integration_delivery_configuration: %s\n" % e)
