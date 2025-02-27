<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$messages_1 = (new LaunchDarkly\Client\Model\Message())
    ->setContent("content")
    ->setRole("role");

$messages_2 = (new LaunchDarkly\Client\Model\Message())
    ->setContent("content")
    ->setRole("role");

$messages = [
    $messages_1,
    $messages_2,
];

$ai_config_variation_patch = (new LaunchDarkly\Client\Model\AIConfigVariationPatch())
    ->setModelConfigKey("modelConfigKey")
    ->setName("name")
    ->setPublished(true)
    ->setMessages($messages);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->patchAIConfigVariation(
        ld_api_version: null,
        project_key: null,
        config_key: null,
        variation_key: null,
        ai_config_variation_patch: $ai_config_variation_patch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#patchAIConfigVariation: {$e->getMessage()}";
}
