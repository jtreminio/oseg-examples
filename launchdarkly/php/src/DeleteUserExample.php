<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\UsersApi(config: $config))->deleteUser(
        project_key: null,
        environment_key: null,
        user_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling UsersApi#deleteUser: {$e->getMessage()}";
}
