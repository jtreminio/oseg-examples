<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->deleteAIConfigVariation(
        ld_api_version: "beta",
        project_key: "projectKey_string",
        config_key: "configKey_string",
        variation_key: "variationKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#deleteAIConfigVariation: {$e->getMessage()}";
}
