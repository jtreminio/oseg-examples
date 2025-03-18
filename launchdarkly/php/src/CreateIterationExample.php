<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$treatments_1_parameters_1 = (new LaunchDarkly\Client\Model\TreatmentParameterInput())
    ->setFlagKey("example-flag-for-experiment")
    ->setVariationId("e432f62b-55f6-49dd-a02f-eb24acf39d05");

$treatments_1_parameters = [
    $treatments_1_parameters_1,
];

$metrics_1 = (new LaunchDarkly\Client\Model\MetricInput())
    ->setKey("metric-key-123abc")
    ->setIsGroup(true)
    ->setPrimary(true);

$metrics = [
    $metrics_1,
];

$treatments_1 = (new LaunchDarkly\Client\Model\TreatmentInput())
    ->setName("Treatment 1")
    ->setBaseline(true)
    ->setAllocationPercent("10")
    ->setParameters($treatments_1_parameters);

$treatments = [
    $treatments_1,
];

$iteration_input = (new LaunchDarkly\Client\Model\IterationInput())
    ->setHypothesis("Example hypothesis, the new button placement will increase conversion")
    ->setFlags([])
    ->setCanReshuffleTraffic(true)
    ->setPrimarySingleMetricKey("metric-key-123abc")
    ->setPrimaryFunnelKey("metric-group-key-123abc")
    ->setRandomizationUnit("user")
    ->setAttributes([
        "country",
        "device",
        "os",
    ])
    ->setMetrics($metrics)
    ->setTreatments($treatments);

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->createIteration(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        experiment_key: "experimentKey_string",
        iteration_input: $iteration_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ExperimentsApi#createIteration: {$e->getMessage()}";
}
