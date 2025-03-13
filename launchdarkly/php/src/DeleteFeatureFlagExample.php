<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->deleteFeatureFlag(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#deleteFeatureFlag: {$e->getMessage()}";
}
