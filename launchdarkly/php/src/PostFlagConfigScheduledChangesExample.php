<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$post_flag_scheduled_changes_input = (new LaunchDarkly\Client\Model\PostFlagScheduledChangesInput())
    ->setExecutionDate(1718467200000)
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "turnFlagOn"
            }
        ]
    EOD, true))
    ->setComment("Optional comment describing the scheduled changes");

try {
    $response = (new LaunchDarkly\Client\Api\ScheduledChangesApi(config: $config))->postFlagConfigScheduledChanges(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        post_flag_scheduled_changes_input: $post_flag_scheduled_changes_input,
        ignore_conflicts: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ScheduledChangesApi#postFlagConfigScheduledChanges: {$e->getMessage()}";
}
