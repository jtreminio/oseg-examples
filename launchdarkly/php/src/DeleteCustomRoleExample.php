<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\CustomRolesApi(config: $config))->deleteCustomRole(
        custom_role_key: "customRoleKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CustomRolesApi#deleteCustomRole: {$e->getMessage()}";
}
