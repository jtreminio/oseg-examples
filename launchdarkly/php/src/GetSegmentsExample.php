<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->getSegments(
        project_key: null,
        environment_key: null,
        limit: null,
        offset: null,
        sort: null,
        filter: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#getSegments: {$e->getMessage()}";
}
