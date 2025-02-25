<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\PersistentStoreIntegrationsBetaApi(config: $config))->deleteBigSegmentStoreIntegration(
        project_key: null,
        environment_key: null,
        integration_key: null,
        integration_id: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling PersistentStoreIntegrationsBeta#deleteBigSegmentStoreIntegration: {$e->getMessage()}";
}
