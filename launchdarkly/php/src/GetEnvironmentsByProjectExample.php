<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\EnvironmentsApi(config: $config))->getEnvironmentsByProject(
        project_key: "projectKey_string",
        limit: null,
        offset: null,
        filter: null,
        sort: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling EnvironmentsApi#getEnvironmentsByProject: {$e->getMessage()}";
}
