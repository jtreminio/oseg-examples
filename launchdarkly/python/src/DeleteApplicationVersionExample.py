import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ApplicationsBetaApi(api_client).delete_application_version(
            application_key="applicationKey_string",
            version_key="versionKey_string",
        )
    except ApiException as e:
        print("Exception when calling ApplicationsBetaApi#delete_application_version: %s\n" % e)
