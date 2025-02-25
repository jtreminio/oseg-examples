import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.IntegrationsBetaApi(api_client).delete_integration_configuration(
            integration_configuration_id=None,
        )
    except ApiException as e:
        print("Exception when calling IntegrationsBeta#delete_integration_configuration: %s\n" % e)
