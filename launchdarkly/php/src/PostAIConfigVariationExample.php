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

$ai_config_variation_post = (new LaunchDarkly\Client\Model\AIConfigVariationPost())
    ->setKey("key")
    ->setName("name")
    ->setModel([])
    ->setModelConfigKey("modelConfigKey")
    ->setMessages($messages);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->postAIConfigVariation(
        ld_api_version: LaunchDarkly\Client\Model\AIConfigVariationPost::LD_API_VERSION_BETA,
        project_key: "projectKey_string",
        config_key: "configKey_string",
        ai_config_variation_post: $ai_config_variation_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#postAIConfigVariation: {$e->getMessage()}";
}
