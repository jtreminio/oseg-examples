<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_1 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("replace")
    ->setPath("/description");

$patch_2 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("add")
    ->setPath("/tags/0");

$patch = [
    $patch_1,
    $patch_2,
];

$patch_with_comment = (new LaunchDarkly\Client\Model\PatchWithComment())
    ->setPatch($patch);

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->patchSegment(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        segment_key: "segmentKey_string",
        patch_with_comment: $patch_with_comment,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#patchSegment: {$e->getMessage()}";
}
