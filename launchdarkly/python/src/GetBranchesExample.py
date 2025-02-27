import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.CodeReferencesApi(api_client).get_branches(
            repo=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CodeReferencesApi#get_branches: %s\n" % e)
