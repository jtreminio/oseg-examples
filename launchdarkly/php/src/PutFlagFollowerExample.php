<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\FollowFlagsApi(config: $config))->putFlagFollower(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        member_id: "memberId_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FollowFlagsApi#putFlagFollower: {$e->getMessage()}";
}
