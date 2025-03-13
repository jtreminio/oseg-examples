import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_operation_1 = models.PatchOperation(
        op="replace",
        path="/name",
    )

    patch_operation = [
        patch_operation_1,
    ]

    try:
        response = api.MetricsApi(api_client).patch_metric(
            project_key="projectKey_string",
            metric_key="metricKey_string",
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsApi#patch_metric: %s\n" % e)
