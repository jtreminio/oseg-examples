<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$update_agent_bot_request = (new Chatwoot\Client\Model\UpdateAgentBotRequest())
    ->setAgentBot(0);

try {
    (new Chatwoot\Client\Api\InboxesApi(config: $config))->updateAgentBot(
        account_id: 0,
        id: 0,
        data: $update_agent_bot_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#updateAgentBot: {$e->getMessage()}";
}
