import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AIConfigsBetaApi(api_client).get_ai_config_metrics_by_variation(
            ld_api_version="beta",
            project_key="projectKey_string",
            config_key="configKey_string",
            var_from=123,
            to=456,
            env="env_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#get_ai_config_metrics_by_variation: %s\n" % e)
