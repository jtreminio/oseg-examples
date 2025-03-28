<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$included = (new LaunchDarkly\Client\Model\SegmentUserList())
    ->setAdd([
    ])
    ->setRemove([
    ]);

$excluded = (new LaunchDarkly\Client\Model\SegmentUserList())
    ->setAdd([
    ])
    ->setRemove([
    ]);

$segment_user_state = (new LaunchDarkly\Client\Model\SegmentUserState())
    ->setIncluded($included)
    ->setExcluded($excluded);

try {
    (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->updateBigSegmentContextTargets(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        segment_key: "segmentKey_string",
        segment_user_state: $segment_user_state,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#updateBigSegmentContextTargets: {$e->getMessage()}";
}
