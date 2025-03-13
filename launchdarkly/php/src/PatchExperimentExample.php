<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$experiment_patch_input = (new LaunchDarkly\Client\Model\ExperimentPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "updateName",
                "value": "Updated experiment name"
            }
        ]
    EOD, true))
    ->setComment("Example comment describing the update");

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->patchExperiment(
        project_key: null,
        environment_key: null,
        experiment_key: null,
        experiment_patch_input: $experiment_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ExperimentsApi#patchExperiment: {$e->getMessage()}";
}
