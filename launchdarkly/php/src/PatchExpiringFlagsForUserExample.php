<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$instructions_1 = (new LaunchDarkly\Client\Model\InstructionUserRequest())
    ->setKind(LaunchDarkly\Client\Model\InstructionUserRequest::KIND_ADD_EXPIRE_USER_TARGET_DATE)
    ->setFlagKey("sample-flag-key")
    ->setVariationId("ce12d345-a1b2-4fb5-a123-ab123d4d5f5d")
    ->setValue(16534692)
    ->setVersion(1);

$instructions = [
    $instructions_1,
];

$patch_users_request = (new LaunchDarkly\Client\Model\PatchUsersRequest())
    ->setComment("optional comment")
    ->setInstructions($instructions);

try {
    $response = (new LaunchDarkly\Client\Api\UserSettingsApi(config: $config))->patchExpiringFlagsForUser(
        project_key: "the-project-key",
        user_key: "the-user-key",
        environment_key: "the-environment-key",
        patch_users_request: $patch_users_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling UserSettingsApi#patchExpiringFlagsForUser: {$e->getMessage()}";
}
