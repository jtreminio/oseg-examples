<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$member_teams_post_input = (new LaunchDarkly\Client\Model\MemberTeamsPostInput())
    ->setTeamKeys([
        "team1",
        "team2",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\AccountMembersApi(config: $config))->postMemberTeams(
        id: "id_string",
        member_teams_post_input: $member_teams_post_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AccountMembersApi#postMemberTeams: {$e->getMessage()}";
}
