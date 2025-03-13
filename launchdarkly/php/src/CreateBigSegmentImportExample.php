<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->createBigSegmentImport(
        project_key: null,
        environment_key: null,
        segment_key: null,
        file: null,
        mode: null,
        wait_on_approvals: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#createBigSegmentImport: {$e->getMessage()}";
}
