<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\CustomRolesApi(config: $config))->getCustomRole(
        custom_role_key: "customRoleKey_string",
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CustomRolesApi#getCustomRole: {$e->getMessage()}";
}
