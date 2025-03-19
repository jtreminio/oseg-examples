<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$team_create_update_payload = (new Chatwoot\Client\Model\TeamCreateUpdatePayload())
    ->setName(null)
    ->setDescription(null)
    ->setAllowAutoAssign(null);

try {
    $response = (new Chatwoot\Client\Api\TeamsApi(config: $config))->updateATeam(
        account_id: 0,
        team_id: 0,
        data: team_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#updateATeam: {$e->getMessage()}";
}
