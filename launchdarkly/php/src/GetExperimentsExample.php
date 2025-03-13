<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->getExperiments(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        limit: null,
        offset: null,
        filter: null,
        expand: null,
        lifecycle_state: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ExperimentsApi#getExperiments: {$e->getMessage()}";
}
