<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$holdout_patch_input = (new LaunchDarkly\Client\Model\HoldoutPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "updateName",
                "value": "Updated holdout name"
            }
        ]
    EOD, true))
    ->setComment("Optional comment describing the update");

try {
    $response = (new LaunchDarkly\Client\Api\HoldoutsBetaApi(config: $config))->patchHoldout(
        project_key: null,
        environment_key: null,
        holdout_key: null,
        holdout_patch_input: $holdout_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling HoldoutsBeta#patchHoldout: {$e->getMessage()}";
}
