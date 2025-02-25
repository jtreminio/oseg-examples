import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.MetricsBetaApi(api_client).get_metric_group(
            project_key=None,
            metric_group_key=None,
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsBeta#get_metric_group: %s\n" % e)
