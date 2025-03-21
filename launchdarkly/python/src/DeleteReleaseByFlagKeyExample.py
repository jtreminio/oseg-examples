import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ReleasesBetaApi(api_client).delete_release_by_flag_key(
            project_key="projectKey_string",
            flag_key="flagKey_string",
        )
    except ApiException as e:
        print("Exception when calling ReleasesBetaApi#delete_release_by_flag_key: %s\n" % e)
