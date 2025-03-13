<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->getAIConfigMetricsByVariation(
        ld_api_version: "beta",
        project_key: "projectKey_string",
        config_key: "configKey_string",
        from: 123,
        to: 456,
        env: "env_string",
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#getAIConfigMetricsByVariation: {$e->getMessage()}";
}
