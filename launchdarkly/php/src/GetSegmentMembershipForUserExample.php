<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->getSegmentMembershipForUser(
        project_key: null,
        environment_key: null,
        segment_key: null,
        user_key: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Segments#getSegmentMembershipForUser: {$e->getMessage()}";
}
