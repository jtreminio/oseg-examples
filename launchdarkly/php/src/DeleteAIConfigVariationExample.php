<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->deleteAIConfigVariation(
        ld_api_version: null,
        project_key: null,
        config_key: null,
        variation_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBeta#deleteAIConfigVariation: {$e->getMessage()}";
}
