<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

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
    ->setModel([])
    ->setMessages($messages);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->patchAIConfigVariation(
        ld_api_version: "beta",
        project_key: "projectKey_string",
        config_key: "configKey_string",
        variation_key: "variationKey_string",
        ai_config_variation_patch: $ai_config_variation_patch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#patchAIConfigVariation: {$e->getMessage()}";
}
