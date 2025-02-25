import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    treatments_1_parameters_1 = models.TreatmentParameterInput(
        flagKey="example-flag-for-experiment",
        variationId="e432f62b-55f6-49dd-a02f-eb24acf39d05",
    )

    treatments_1_parameters = [
        treatments_1_parameters_1,
    ]

    metrics_1 = models.MetricInput(
        key="metric-key-123abc",
        isGroup=True,
        primary=True,
    )

    metrics = [
        metrics_1,
    ]

    treatments_1 = models.TreatmentInput(
        name="Treatment 1",
        baseline=True,
        allocationPercent="10",
        parameters=treatments_1_parameters,
    )

    treatments = [
        treatments_1,
    ]

    iteration_input = models.IterationInput(
        hypothesis="Example hypothesis, the new button placement will increase conversion",
        flags=None,
        canReshuffleTraffic=True,
        primarySingleMetricKey="metric-key-123abc",
        primaryFunnelKey="metric-group-key-123abc",
        randomizationUnit="user",
        attributes=[
            "country",
            "device",
            "os",
        ],
        metrics=metrics,
        treatments=treatments,
    )

    try:
        response = api.ExperimentsApi(api_client).create_iteration(
            project_key=None,
            environment_key=None,
            experiment_key=None,
            iteration_input=iteration_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Experiments#create_iteration: %s\n" % e)
