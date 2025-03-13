<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$trigger_post = (new LaunchDarkly\Client\Model\TriggerPost())
    ->setIntegrationKey("generic-trigger")
    ->setComment("example comment")
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "turnFlagOn"
            }
        ]
    EOD, true));

try {
    $response = (new LaunchDarkly\Client\Api\FlagTriggersApi(config: $config))->createTriggerWorkflow(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        feature_flag_key: "featureFlagKey_string",
        trigger_post: $trigger_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagTriggersApi#createTriggerWorkflow: {$e->getMessage()}";
}
