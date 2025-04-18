import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AIConfigsBetaApi(api_client).delete_ai_config(
            ld_api_version="beta",
            project_key="default",
            config_key="configKey_string",
        )
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#delete_ai_config: %s\n" % e)
