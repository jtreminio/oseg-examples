import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.MetricsApi(api_client).get_metric(
            project_key="projectKey_string",
            metric_key="metricKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsApi#get_metric: %s\n" % e)
