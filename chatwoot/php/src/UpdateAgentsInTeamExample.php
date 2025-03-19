<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$update_agents_in_team_request = (new Chatwoot\Client\Model\UpdateAgentsInTeamRequest())
    ->setUserIds([
    ]);

try {
    $response = (new Chatwoot\Client\Api\TeamsApi(config: $config))->updateAgentsInTeam(
        account_id: 0,
        team_id: 0,
        data: update_agents_in_team_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#updateAgentsInTeam: {$e->getMessage()}";
}
