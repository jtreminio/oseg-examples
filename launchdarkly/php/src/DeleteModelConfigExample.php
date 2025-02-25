<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->deleteModelConfig(
        ld_api_version: null,
        project_key: "default",
        model_config_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBeta#deleteModelConfig: {$e->getMessage()}";
}
