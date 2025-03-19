<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$team_patch_input = (new LaunchDarkly\Client\Model\TeamPatchInput())
    ->setInstructions(json_decode(<<<'EOD'
        [
            {
                "kind": "updateDescription",
                "value": "New description for the team"
            }
        ]
    EOD, true))
    ->setComment("Optional comment about the update");

try {
    $response = (new LaunchDarkly\Client\Api\TeamsApi(config: $config))->patchTeam(
        team_key: "teamKey_string",
        team_patch_input: $team_patch_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#patchTeam: {$e->getMessage()}";
}
