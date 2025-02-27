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
        response = api.MetricsBetaApi(api_client).patch_metric_group(
            project_key=None,
            metric_group_key=None,
            patch_operation=patch_operation,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling MetricsBetaApi#patch_metric_group: %s\n" % e)
