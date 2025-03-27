<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$agent_bot_create_update_payload = (new Chatwoot\Client\Model\AgentBotCreateUpdatePayload())
    ->setName(null)
    ->setDescription(null)
    ->setOutgoingUrl(null);

try {
    $response = (new Chatwoot\Client\Api\AgentBotsApi(config: $config))->updateAnAgentBot(
        id: 0,
        data: $agent_bot_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentBotsApi#updateAnAgentBot: {$e->getMessage()}";
}
