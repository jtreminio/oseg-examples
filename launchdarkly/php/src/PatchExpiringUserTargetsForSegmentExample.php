<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$instructions_1 = (new LaunchDarkly\Client\Model\PatchSegmentInstruction())
    ->setKind(LaunchDarkly\Client\Model\PatchSegmentInstruction::KIND_ADD_EXPIRE_USER_TARGET_DATE)
    ->setUserKey("sample-user-key")
    ->setTargetType(LaunchDarkly\Client\Model\PatchSegmentInstruction::TARGET_TYPE_INCLUDED)
    ->setValue(16534692)
    ->setVersion(0);

$instructions = [
    $instructions_1,
];

$patch_segment_request = (new LaunchDarkly\Client\Model\PatchSegmentRequest())
    ->setComment("optional comment")
    ->setInstructions($instructions);

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->patchExpiringUserTargetsForSegment(
        project_key: "the-project-key",
        environment_key: "the-environment-key",
        segment_key: "the-segment-key",
        patch_segment_request: $patch_segment_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Segments#patchExpiringUserTargetsForSegment: {$e->getMessage()}";
}
