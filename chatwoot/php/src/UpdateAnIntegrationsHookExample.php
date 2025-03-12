<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$integrations_hook_update_payload = (new Chatwoot\Client\Model\IntegrationsHookUpdatePayload());

try {
    $response = (new Chatwoot\Client\Api\IntegrationsApi(config: $config))->updateAnIntegrationsHook(
        account_id: null,
        hook_id: null,
        data: integrations_hook_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling IntegrationsApi#updateAnIntegrationsHook: {$e->getMessage()}";
}
