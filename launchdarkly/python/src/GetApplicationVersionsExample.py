import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ApplicationsBetaApi(api_client).get_application_versions(
            application_key="applicationKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApplicationsBetaApi#get_application_versions: %s\n" % e)
