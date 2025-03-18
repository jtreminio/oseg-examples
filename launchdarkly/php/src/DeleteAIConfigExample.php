<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->deleteAIConfig(
        ld_api_version: "beta",
        project_key: "default",
        config_key: "configKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#deleteAIConfig: {$e->getMessage()}";
}
