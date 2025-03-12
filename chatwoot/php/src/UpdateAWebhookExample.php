<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$webhook_create_update_payload = (new Chatwoot\Client\Model\WebhookCreateUpdatePayload())
    ->setUrl(null)
    ->setSubscriptions([
    ]);

try {
    $response = (new Chatwoot\Client\Api\WebhooksApi(config: $config))->updateAWebhook(
        account_id: null,
        webhook_id: null,
        data: webhook_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling WebhooksApi#updateAWebhook: {$e->getMessage()}";
}
