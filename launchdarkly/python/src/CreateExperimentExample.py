import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    iteration_treatments_1_parameters_1 = models.TreatmentParameterInput(
        flagKey="example-flag-for-experiment",
        variationId="e432f62b-55f6-49dd-a02f-eb24acf39d05",
    )

    iteration_treatments_1_parameters = [
        iteration_treatments_1_parameters_1,
    ]

    iteration_metrics_1 = models.MetricInput(
        key="metric-key-123abc",
        isGroup=True,
        primary=True,
    )

    iteration_metrics = [
        iteration_metrics_1,
    ]

    iteration_treatments_1 = models.TreatmentInput(
        name="Treatment 1",
        baseline=True,
        allocationPercent="10",
        parameters=iteration_treatments_1_parameters,
    )

    iteration_treatments = [
        iteration_treatments_1,
    ]

    iteration = models.IterationInput(
        hypothesis="Example hypothesis, the new button placement will increase conversion",
        flags={},
        canReshuffleTraffic=True,
        primarySingleMetricKey="metric-key-123abc",
        primaryFunnelKey="metric-group-key-123abc",
        randomizationUnit="user",
        attributes=[
            "country",
            "device",
            "os",
        ],
        metrics=iteration_metrics,
        treatments=iteration_treatments,
    )

    experiment_post = models.ExperimentPost(
        name="Example experiment",
        key="experiment-key-123abc",
        description="An example experiment, used in testing",
        maintainerId="12ab3c45de678910fgh12345",
        holdoutId="f3b74309-d581-44e1-8a2b-bb2933b4fe40",
        iteration=iteration,
    )

    try:
        response = api.ExperimentsApi(api_client).create_experiment(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            experiment_post=experiment_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#create_experiment: %s\n" % e)
