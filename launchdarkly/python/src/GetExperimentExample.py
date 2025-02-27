import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ExperimentsApi(api_client).get_experiment(
            project_key=None,
            environment_key=None,
            experiment_key=None,
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#get_experiment: %s\n" % e)
