<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
    ->setComment(null)
    ->setPatch($patch);

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->patchSegment(
        project_key: null,
        environment_key: null,
        segment_key: null,
        patch_with_comment: $patch_with_comment,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Segments#patchSegment: {$e->getMessage()}";
}
