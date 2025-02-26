import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.MetricsApi(api_client).delete_metric(
            project_key=None,
            metric_key=None,
        )
    except ApiException as e:
        print("Exception when calling MetricsApi#delete_metric: %s\n" % e)
