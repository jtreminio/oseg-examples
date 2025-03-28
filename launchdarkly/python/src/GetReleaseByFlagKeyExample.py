import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ReleasesBetaApi(api_client).get_release_by_flag_key(
            project_key="projectKey_string",
            flag_key="flagKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasesBetaApi#get_release_by_flag_key: %s\n" % e)
