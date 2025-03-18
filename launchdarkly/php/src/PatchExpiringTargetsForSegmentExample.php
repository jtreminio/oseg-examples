<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$instructions_1 = (new LaunchDarkly\Client\Model\PatchSegmentExpiringTargetInstruction())
    ->setKind(LaunchDarkly\Client\Model\PatchSegmentExpiringTargetInstruction::KIND_UPDATE_EXPIRING_TARGET)
    ->setContextKey("user@email.com")
    ->setContextKind("user")
    ->setTargetType(LaunchDarkly\Client\Model\PatchSegmentExpiringTargetInstruction::TARGET_TYPE_INCLUDED)
    ->setValue(1587582000000)
    ->setVersion(0);

$instructions = [
    $instructions_1,
];

$patch_segment_expiring_target_input_rep = (new LaunchDarkly\Client\Model\PatchSegmentExpiringTargetInputRep())
    ->setComment("optional comment")
    ->setInstructions($instructions);

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->patchExpiringTargetsForSegment(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        segment_key: "segmentKey_string",
        patch_segment_expiring_target_input_rep: $patch_segment_expiring_target_input_rep,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#patchExpiringTargetsForSegment: {$e->getMessage()}";
}
