<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->getAIConfigMetrics(
        ld_api_version: null,
        project_key: null,
        config_key: null,
        from: 123,
        to: 456,
        env: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBeta#getAIConfigMetrics: {$e->getMessage()}";
}
