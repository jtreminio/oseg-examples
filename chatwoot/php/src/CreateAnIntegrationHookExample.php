<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$integrations_hook_create_payload = (new Chatwoot\Client\Model\IntegrationsHookCreatePayload())
    ->setAppId(null)
    ->setInboxId(null)
    ->setSettings(null);

try {
    $response = (new Chatwoot\Client\Api\IntegrationsApi(config: $config))->createAnIntegrationHook(
        account_id: 0,
        data: integrations_hook_create_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling IntegrationsApi#createAnIntegrationHook: {$e->getMessage()}";
}
