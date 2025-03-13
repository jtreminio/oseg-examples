<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_flags_request = (new LaunchDarkly\Client\Model\PatchFlagsRequest())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "addExpireUserTargetDate",
                "userKey": "sandy",
                "value": 1686412800000,
                "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
            }
        ]
    EOD, true))
    ->setComment("optional comment");

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->patchExpiringTargets(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        feature_flag_key: "featureFlagKey_string",
        patch_flags_request: $patch_flags_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#patchExpiringTargets: {$e->getMessage()}";
}
