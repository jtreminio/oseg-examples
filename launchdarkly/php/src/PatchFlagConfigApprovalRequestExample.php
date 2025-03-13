<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsBetaApi(config: $config))->patchFlagConfigApprovalRequest(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        id: "id_string",
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsBetaApi#patchFlagConfigApprovalRequest: {$e->getMessage()}";
}
