import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.IntegrationsBetaApi(api_client).get_integration_configuration(
            integration_configuration_id="integrationConfigurationId_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationsBetaApi#get_integration_configuration: %s\n" % e)
