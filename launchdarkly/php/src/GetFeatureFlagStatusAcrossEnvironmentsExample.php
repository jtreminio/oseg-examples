<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->getFeatureFlagStatusAcrossEnvironments(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        env: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#getFeatureFlagStatusAcrossEnvironments: {$e->getMessage()}";
}
