<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$ai_config_post = (new LaunchDarkly\Client\Model\AIConfigPost())
    ->setKey("key")
    ->setName("name")
    ->setDescription("")
    ->setTags([
        "tags",
        "tags",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->postAIConfig(
        ld_api_version: "beta",
        project_key: "projectKey_string",
        ai_config_post: $ai_config_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#postAIConfig: {$e->getMessage()}";
}
