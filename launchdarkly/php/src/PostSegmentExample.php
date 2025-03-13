<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$segment_body = (new LaunchDarkly\Client\Model\SegmentBody())
    ->setName("Example segment")
    ->setKey("segment-key-123abc")
    ->setDescription("Bundle our sample customers together")
    ->setUnbounded(false)
    ->setUnboundedContextKind("device")
    ->setTags([
        "testing",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->postSegment(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        segment_body: $segment_body,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#postSegment: {$e->getMessage()}";
}
