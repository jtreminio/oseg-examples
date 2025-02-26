import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AIConfigsBetaApi(api_client).get_ai_configs(
            ld_api_version=None,
            project_key="default",
            sort=None,
            limit=None,
            offset=None,
            filter=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#get_ai_configs: %s\n" % e)
