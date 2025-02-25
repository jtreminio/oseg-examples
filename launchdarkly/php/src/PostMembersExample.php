<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$new_member_form_1 = (new LaunchDarkly\Client\Model\NewMemberForm())
    ->setEmail("sandy@acme.com")
    ->setPassword("***")
    ->setFirstName("Ariel")
    ->setLastName("Flores")
    ->setRole(LaunchDarkly\Client\Model\NewMemberForm::ROLE_READER)
    ->setCustomRoles([
        "customRole1",
        "customRole2",
    ])
    ->setTeamKeys([
        "team-1",
        "team-2",
    ])
    ->setRoleAttributes(null);

$new_member_form = [
    $new_member_form_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\AccountMembersApi(config: $config))->postMembers(
        new_member_form: $new_member_form,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AccountMembers#postMembers: {$e->getMessage()}";
}
