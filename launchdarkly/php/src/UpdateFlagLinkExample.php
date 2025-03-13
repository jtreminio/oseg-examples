<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_operation_1 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("replace")
    ->setPath("/title");

$patch_operation = [
    $patch_operation_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\FlagLinksBetaApi(config: $config))->updateFlagLink(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        id: "id_string",
        patch_operation: $patch_operation,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagLinksBetaApi#updateFlagLink: {$e->getMessage()}";
}
