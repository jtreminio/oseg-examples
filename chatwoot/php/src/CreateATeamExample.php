<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$team_create_update_payload = (new Chatwoot\Client\Model\TeamCreateUpdatePayload())
    ->setName(null)
    ->setDescription(null)
    ->setAllowAutoAssign(null);

try {
    $response = (new Chatwoot\Client\Api\TeamsApi(config: $config))->createATeam(
        account_id: null,
        data: team_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#createATeam: {$e->getMessage()}";
}
