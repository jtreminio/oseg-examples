<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\UsersApi(config: $config))->deleteUser(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        user_key: "userKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling UsersApi#deleteUser: {$e->getMessage()}";
}
