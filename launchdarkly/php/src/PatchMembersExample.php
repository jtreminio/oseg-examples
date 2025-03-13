<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$members_patch_input = (new LaunchDarkly\Client\Model\MembersPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "replaceMembersRoles",
                "memberIDs": [
                    "1234a56b7c89d012345e678f",
                    "507f1f77bcf86cd799439011"
                ],
                "value": "reader"
            }
        ]
    EOD, true))
    ->setComment("Optional comment about the update");

try {
    $response = (new LaunchDarkly\Client\Api\AccountMembersBetaApi(config: $config))->patchMembers(
        members_patch_input: $members_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AccountMembersBetaApi#patchMembers: {$e->getMessage()}";
}
