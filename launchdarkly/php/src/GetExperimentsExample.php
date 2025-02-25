<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->getExperiments(
        project_key: null,
        environment_key: null,
        limit: null,
        offset: null,
        filter: null,
        expand: null,
        lifecycle_state: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Experiments#getExperiments: {$e->getMessage()}";
}
