<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$update_agent_bot_request = (new Chatwoot\Client\Model\UpdateAgentBotRequest())
    ->setAgentBot(null);

try {
    (new Chatwoot\Client\Api\InboxesApi(config: $config))->updateAgentBot(
        account_id: null,
        id: null,
        data: update_agent_bot_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#updateAgentBot: {$e->getMessage()}";
}
