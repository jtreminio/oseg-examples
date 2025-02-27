<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$ai_config_patch = (new LaunchDarkly\Client\Model\AIConfigPatch())
    ->setDescription("description")
    ->setName("name")
    ->setTags([
        "tags",
        "tags",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->patchAIConfig(
        ld_api_version: null,
        project_key: null,
        config_key: null,
        ai_config_patch: $ai_config_patch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#patchAIConfig: {$e->getMessage()}";
}
