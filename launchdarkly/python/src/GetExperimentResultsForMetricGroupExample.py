import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ExperimentsApi(api_client).get_experiment_results_for_metric_group(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            experiment_key="experimentKey_string",
            metric_group_key="metricGroupKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#get_experiment_results_for_metric_group: %s\n" % e)
