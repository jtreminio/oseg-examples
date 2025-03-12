<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

try {
    (new Chatwoot\Client\Api\TeamsApi(config: $config))->deleteATeam(
        account_id: null,
        team_id: null,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#deleteATeam: {$e->getMessage()}";
}
