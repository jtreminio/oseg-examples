<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        post_flag_scheduled_changes_input: $post_flag_scheduled_changes_input,
        ignore_conflicts: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ScheduledChanges#postFlagConfigScheduledChanges: {$e->getMessage()}";
}
