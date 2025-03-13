<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\AccountUsageBetaApi(config: $config))->getStreamUsageBySdkVersion(
        source: "source_string",
        from: null,
        to: null,
        tz: null,
        sdk: null,
        version: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AccountUsageBetaApi#getStreamUsageBySdkVersion: {$e->getMessage()}";
}
