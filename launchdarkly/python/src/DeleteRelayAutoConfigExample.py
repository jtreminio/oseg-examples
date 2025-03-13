import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.RelayProxyConfigurationsApi(api_client).delete_relay_auto_config(
            id="id_string",
        )
    except ApiException as e:
        print("Exception when calling RelayProxyConfigurationsApi#delete_relay_auto_config: %s\n" % e)
