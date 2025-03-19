<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$team_post_input = (new LaunchDarkly\Client\Model\TeamPostInput())
    ->setKey("team-key-123abc")
    ->setName("Example team")
    ->setDescription("An example team")
    ->setCustomRoleKeys([
        "example-role1",
        "example-role2",
    ])
    ->setMemberIDs([
        "12ab3c45de678910fgh12345",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\TeamsApi(config: $config))->postTeam(
        team_post_input: $team_post_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#postTeam: {$e->getMessage()}";
}
