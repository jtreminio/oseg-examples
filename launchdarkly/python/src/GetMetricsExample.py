import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.MetricsApi(api_client).get_metrics(
            project_key=None,
            expand=None,
            limit=None,
            offset=None,
            sort=None,
            filter=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Metrics#get_metrics: %s\n" % e)
