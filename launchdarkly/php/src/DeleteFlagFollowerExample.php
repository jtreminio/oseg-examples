<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\FollowFlagsApi(config: $config))->deleteFlagFollower(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        member_id: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FollowFlags#deleteFlagFollower: {$e->getMessage()}";
}
