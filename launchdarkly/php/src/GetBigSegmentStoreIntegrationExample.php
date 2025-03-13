<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\PersistentStoreIntegrationsBetaApi(config: $config))->getBigSegmentStoreIntegration(
        project_key: null,
        environment_key: null,
        integration_key: null,
        integration_id: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling PersistentStoreIntegrationsBetaApi#getBigSegmentStoreIntegration: {$e->getMessage()}";
}
