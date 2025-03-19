<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

try {
    (new Chatwoot\Client\Api\AccountAgentBotsApi(config: $config))->deleteAnAccountAgentBot(
        account_id: 0,
        id: 0,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AccountAgentBotsApi#deleteAnAccountAgentBot: {$e->getMessage()}";
}
