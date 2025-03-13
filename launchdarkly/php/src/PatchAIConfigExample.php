<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$ai_config_patch = (new LaunchDarkly\Client\Model\AIConfigPatch())
    ->setDescription("description")
    ->setName("name")
    ->setTags([
        "tags",
        "tags",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->patchAIConfig(
        ld_api_version: LaunchDarkly\Client\Model\AIConfigPatch::LD_API_VERSION_BETA,
        project_key: "projectKey_string",
        config_key: "configKey_string",
        ai_config_patch: $ai_config_patch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#patchAIConfig: {$e->getMessage()}";
}
