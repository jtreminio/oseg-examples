import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    metric_post = models.MetricPost(
        key="metric-key-123abc",
        kind="custom",
        isActive=True,
        isNumeric=False,
        eventKey="trackedClick",
    )

    try:
        response = api.MetricsApi(api_client).post_metric(
            project_key="projectKey_string",
            metric_post=metric_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsApi#post_metric: %s\n" % e)
