<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->getBigSegmentImport(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        segment_key: "segmentKey_string",
        import_id: "importID_string",
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#getBigSegmentImport: {$e->getMessage()}";
}
