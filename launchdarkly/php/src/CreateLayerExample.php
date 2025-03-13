<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$layer_post = (new LaunchDarkly\Client\Model\LayerPost())
    ->setKey("checkout-flow")
    ->setName("Checkout Flow")
    ->setDescription("description_string");

try {
    $response = (new LaunchDarkly\Client\Api\LayersApi(config: $config))->createLayer(
        project_key: "projectKey_string",
        layer_post: $layer_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling LayersApi#createLayer: {$e->getMessage()}";
}
