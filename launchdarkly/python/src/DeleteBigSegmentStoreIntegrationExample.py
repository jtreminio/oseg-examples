import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.PersistentStoreIntegrationsBetaApi(api_client).delete_big_segment_store_integration(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            integration_key="integrationKey_string",
            integration_id="integrationId_string",
        )
    except ApiException as e:
        print("Exception when calling PersistentStoreIntegrationsBetaApi#delete_big_segment_store_integration: %s\n" % e)
