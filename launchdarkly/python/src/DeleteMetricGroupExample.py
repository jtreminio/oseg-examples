import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.MetricsBetaApi(api_client).delete_metric_group(
            project_key="projectKey_string",
            metric_group_key="metricGroupKey_string",
        )
    except ApiException as e:
        print("Exception when calling MetricsBetaApi#delete_metric_group: %s\n" % e)
