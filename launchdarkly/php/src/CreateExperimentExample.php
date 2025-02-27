<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$iteration_treatments_1_parameters_1 = (new LaunchDarkly\Client\Model\TreatmentParameterInput())
    ->setFlagKey("example-flag-for-experiment")
    ->setVariationId("e432f62b-55f6-49dd-a02f-eb24acf39d05");

$iteration_treatments_1_parameters = [
    $iteration_treatments_1_parameters_1,
];

$iteration_metrics_1 = (new LaunchDarkly\Client\Model\MetricInput())
    ->setKey("metric-key-123abc")
    ->setIsGroup(true)
    ->setPrimary(true);

$iteration_metrics = [
    $iteration_metrics_1,
];

$iteration_treatments_1 = (new LaunchDarkly\Client\Model\TreatmentInput())
    ->setName("Treatment 1")
    ->setBaseline(true)
    ->setAllocationPercent("10")
    ->setParameters($iteration_treatments_1_parameters);

$iteration_treatments = [
    $iteration_treatments_1,
];

$iteration = (new LaunchDarkly\Client\Model\IterationInput())
    ->setHypothesis("Example hypothesis, the new button placement will increase conversion")
    ->setFlags(null)
    ->setCanReshuffleTraffic(true)
    ->setPrimarySingleMetricKey("metric-key-123abc")
    ->setPrimaryFunnelKey("metric-group-key-123abc")
    ->setRandomizationUnit("user")
    ->setAttributes([
        "country",
        "device",
        "os",
    ])
    ->setMetrics($iteration_metrics)
    ->setTreatments($iteration_treatments);

$experiment_post = (new LaunchDarkly\Client\Model\ExperimentPost())
    ->setName("Example experiment")
    ->setKey("experiment-key-123abc")
    ->setDescription("An example experiment, used in testing")
    ->setMaintainerId("12ab3c45de678910fgh12345")
    ->setHoldoutId("f3b74309-d581-44e1-8a2b-bb2933b4fe40")
    ->setIteration($iteration);

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->createExperiment(
        project_key: null,
        environment_key: null,
        experiment_post: $experiment_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ExperimentsApi#createExperiment: {$e->getMessage()}";
}
