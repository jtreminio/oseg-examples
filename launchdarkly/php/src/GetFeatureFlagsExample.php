<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->getFeatureFlags(
        project_key: "projectKey_string",
        env: null,
        tag: null,
        limit: null,
        offset: null,
        archived: null,
        summary: null,
        filter: null,
        sort: null,
        compare: null,
        expand: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#getFeatureFlags: {$e->getMessage()}";
}
