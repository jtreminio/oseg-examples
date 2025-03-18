<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$layer_patch_input = (new LaunchDarkly\Client\Model\LayerPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "experimentKey": "checkout-button-color",
                "kind": "updateExperimentReservation",
                "reservationPercent": 25
            }
        ]
    EOD, true))
    ->setComment("Example comment describing the update")
    ->setEnvironmentKey("production");

try {
    $response = (new LaunchDarkly\Client\Api\LayersApi(config: $config))->updateLayer(
        project_key: "projectKey_string",
        layer_key: "layerKey_string",
        layer_patch_input: $layer_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling LayersApi#updateLayer: {$e->getMessage()}";
}
