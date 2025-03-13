<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\EnvironmentsApi(config: $config))->deleteEnvironment(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling EnvironmentsApi#deleteEnvironment: {$e->getMessage()}";
}
