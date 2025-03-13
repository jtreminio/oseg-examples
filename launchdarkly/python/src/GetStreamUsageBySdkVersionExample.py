import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AccountUsageBetaApi(api_client).get_stream_usage_by_sdk_version(
            source="source_string",
            var_from=None,
            to=None,
            tz=None,
            sdk=None,
            version=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountUsageBetaApi#get_stream_usage_by_sdk_version: %s\n" % e)
