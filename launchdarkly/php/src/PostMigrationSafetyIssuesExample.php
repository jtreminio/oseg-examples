<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$flag_sempatch = (new LaunchDarkly\Client\Model\FlagSempatch())
    ->setInstructions([]);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->postMigrationSafetyIssues(
        project_key: "projectKey_string",
        flag_key: "flagKey_string",
        environment_key: "environmentKey_string",
        flag_sempatch: $flag_sempatch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#postMigrationSafetyIssues: {$e->getMessage()}";
}
