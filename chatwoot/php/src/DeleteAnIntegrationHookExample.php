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
    (new Chatwoot\Client\Api\IntegrationsApi(config: $config))->deleteAnIntegrationHook(
        account_id: null,
        hook_id: null,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling IntegrationsApi#deleteAnIntegrationHook: {$e->getMessage()}";
}
