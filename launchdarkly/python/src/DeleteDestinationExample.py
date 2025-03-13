import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.DataExportDestinationsApi(api_client).delete_destination(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            id="id_string",
        )
    except ApiException as e:
        print("Exception when calling DataExportDestinationsApi#delete_destination: %s\n" % e)
