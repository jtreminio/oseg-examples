import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.RelayProxyConfigurationsApi(api_client).reset_relay_auto_config(
            id="id_string",
            expiry=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling RelayProxyConfigurationsApi#reset_relay_auto_config: %s\n" % e)
