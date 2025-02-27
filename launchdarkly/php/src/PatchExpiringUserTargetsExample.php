<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->patchExpiringUserTargets(
        project_key: null,
        environment_key: null,
        feature_flag_key: null,
        patch_flags_request: $patch_flags_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#patchExpiringUserTargets: {$e->getMessage()}";
}
