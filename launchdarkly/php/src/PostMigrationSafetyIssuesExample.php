<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$flag_sempatch = (new LaunchDarkly\Client\Model\FlagSempatch())
    ->setInstructions(json_decode(<<<'EOD'
        []
    EOD, true))
    ->setComment(null);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->postMigrationSafetyIssues(
        project_key: null,
        flag_key: null,
        environment_key: null,
        flag_sempatch: $flag_sempatch,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#postMigrationSafetyIssues: {$e->getMessage()}";
}
