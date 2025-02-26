<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$policy_1 = (new LaunchDarkly\Client\Model\StatementPost())
    ->setEffect(LaunchDarkly\Client\Model\StatementPost::EFFECT_ALLOW)
    ->setResources([
        "proj/*:env/production:flag/*",
    ])
    ->setNotResources(null)
    ->setActions([
        "updateOn",
    ])
    ->setNotActions(null);

$policy = [
    $policy_1,
];

$custom_role_post = (new LaunchDarkly\Client\Model\CustomRolePost())
    ->setName("Ops team")
    ->setKey("role-key-123abc")
    ->setDescription("An example role for members of the ops team")
    ->setBasePermissions("reader")
    ->setResourceCategory(null)
    ->setPolicy($policy);

try {
    $response = (new LaunchDarkly\Client\Api\CustomRolesApi(config: $config))->postCustomRole(
        custom_role_post: $custom_role_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CustomRolesApi#postCustomRole: {$e->getMessage()}";
}
