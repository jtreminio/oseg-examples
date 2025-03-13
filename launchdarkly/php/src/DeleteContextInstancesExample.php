<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->deleteContextInstances(
        project_key: null,
        environment_key: null,
        id: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ContextsApi#deleteContextInstances: {$e->getMessage()}";
}
