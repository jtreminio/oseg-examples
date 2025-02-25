<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
        project_key: null,
        environment_key: null,
        feature_flag_key: null,
        id: null,
        flag_trigger_input: $flag_trigger_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagTriggers#patchTriggerWorkflow: {$e->getMessage()}";
}
