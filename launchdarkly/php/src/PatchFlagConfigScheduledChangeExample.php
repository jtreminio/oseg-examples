<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$flag_scheduled_changes_input = (new LaunchDarkly\Client\Model\FlagScheduledChangesInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "replaceScheduledChangesInstructions",
                "value": [
                    {
                        "kind": "turnFlagOff"
                    }
                ]
            }
        ]
    EOD, true))
    ->setComment("Optional comment describing the update to the scheduled changes");

try {
    $response = (new LaunchDarkly\Client\Api\ScheduledChangesApi(config: $config))->patchFlagConfigScheduledChange(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        id: "id_string",
        flag_scheduled_changes_input: $flag_scheduled_changes_input,
        ignore_conflicts: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ScheduledChangesApi#patchFlagConfigScheduledChange: {$e->getMessage()}";
}
