<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->getExperimentResults(
        project_key: null,
        environment_key: null,
        experiment_key: null,
        metric_key: null,
        iteration_id: null,
        expand: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Experiments#getExperimentResults: {$e->getMessage()}";
}
