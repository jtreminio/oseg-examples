import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ExperimentsApi(api_client).get_experiments(
            project_key=None,
            environment_key=None,
            limit=None,
            offset=None,
            filter=None,
            expand=None,
            lifecycle_state=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#get_experiments: %s\n" % e)
