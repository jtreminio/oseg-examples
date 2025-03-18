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

$patch = [
    $patch_1,
];

$patch_with_comment = (new LaunchDarkly\Client\Model\PatchWithComment())
    ->setPatch($patch);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->patchFeatureFlag(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        patch_with_comment: $patch_with_comment,
        ignore_conflicts: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#patchFeatureFlag: {$e->getMessage()}";
}
