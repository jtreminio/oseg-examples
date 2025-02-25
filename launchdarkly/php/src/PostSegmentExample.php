<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
        project_key: null,
        environment_key: null,
        segment_body: $segment_body,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Segments#postSegment: {$e->getMessage()}";
}
