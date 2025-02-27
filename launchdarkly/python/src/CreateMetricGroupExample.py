import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    metrics_1 = models.MetricInMetricGroupInput(
        key="metric-key-123abc",
        nameInGroup="Step 1",
    )

    metrics = [
        metrics_1,
    ]

    metric_group_post = models.MetricGroupPost(
        key="metric-group-key-123abc",
        name="My metric group",
        kind="funnel",
        maintainerId="569fdeadbeef1644facecafe",
        tags=[
            "ops",
        ],
        description="Description of the metric group",
        metrics=metrics,
    )

    try:
        response = api.MetricsBetaApi(api_client).create_metric_group(
            project_key=None,
            metric_group_post=metric_group_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsBetaApi#create_metric_group: %s\n" % e)
