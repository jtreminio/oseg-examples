<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$model_config_post = (new LaunchDarkly\Client\Model\ModelConfigPost())
    ->setId("id")
    ->setKey("key")
    ->setName("name")
    ->setIcon("icon")
    ->setProvider("provider")
    ->setTags([
        "tags",
        "tags",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\AIConfigsBetaApi(config: $config))->postModelConfig(
        ld_api_version: null,
        project_key: "default",
        model_config_post: $model_config_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AIConfigsBetaApi#postModelConfig: {$e->getMessage()}";
}
