<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\ReleasesBetaApi(config: $config))->deleteReleaseByFlagKey(
        project_key: "projectKey_string",
        flag_key: "flagKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasesBetaApi#deleteReleaseByFlagKey: {$e->getMessage()}";
}
