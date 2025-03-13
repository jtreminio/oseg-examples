import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    metrics_1 = models.MetricInput(
        key="metric-key-123abc",
        isGroup=True,
        primary=True,
    )

    metrics = [
        metrics_1,
    ]

    holdout_post_request = models.HoldoutPostRequest(
        name="holdout-one-name",
        key="holdout-key",
        description="My holdout-one description",
        randomizationunit="user",
        holdoutamount="10",
        primarymetrickey="metric-key-123abc",
        prerequisiteflagkey="flag-key-123abc",
        attributes=[
            "country",
            "device",
            "os",
        ],
        metrics=metrics,
    )

    try:
        response = api.HoldoutsBetaApi(api_client).post_holdout(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            holdout_post_request=holdout_post_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HoldoutsBetaApi#post_holdout: %s\n" % e)
