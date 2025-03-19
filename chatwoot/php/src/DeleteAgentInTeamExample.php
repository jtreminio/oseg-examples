<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$delete_agent_in_team_request = (new Chatwoot\Client\Model\DeleteAgentInTeamRequest())
    ->setUserIds([
    ]);

try {
    (new Chatwoot\Client\Api\TeamsApi(config: $config))->deleteAgentInTeam(
        account_id: 0,
        team_id: 0,
        data: delete_agent_in_team_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#deleteAgentInTeam: {$e->getMessage()}";
}
