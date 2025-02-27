import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PersistentStoreIntegrationsBetaApi(api_client).get_big_segment_store_integration(
            project_key=None,
            environment_key=None,
            integration_key=None,
            integration_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersistentStoreIntegrationsBetaApi#get_big_segment_store_integration: %s\n" % e)
