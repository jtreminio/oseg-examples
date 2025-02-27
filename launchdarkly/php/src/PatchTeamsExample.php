<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$teams_patch_input = (new LaunchDarkly\Client\Model\TeamsPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "addMembersToTeams",
                "memberIDs": [
                    "1234a56b7c89d012345e678f"
                ],
                "teamKeys": [
                    "example-team-1",
                    "example-team-2"
                ]
            }
        ]
    EOD, true))
    ->setComment("Optional comment about the update");

try {
    $response = (new LaunchDarkly\Client\Api\TeamsBetaApi(config: $config))->patchTeams(
        teams_patch_input: $teams_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling TeamsBetaApi#patchTeams: {$e->getMessage()}";
}
