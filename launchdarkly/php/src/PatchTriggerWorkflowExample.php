<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$flag_trigger_input = (new LaunchDarkly\Client\Model\FlagTriggerInput())
    ->setComment("optional comment")
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "disableTrigger"
            }
        ]
    EOD, true));

try {
    $response = (new LaunchDarkly\Client\Api\FlagTriggersApi(config: $config))->patchTriggerWorkflow(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        feature_flag_key: "featureFlagKey_string",
        id: "id_string",
        flag_trigger_input: $flag_trigger_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagTriggersApi#patchTriggerWorkflow: {$e->getMessage()}";
}
