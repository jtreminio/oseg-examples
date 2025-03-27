<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$webhook_create_update_payload = (new Chatwoot\Client\Model\WebhookCreateUpdatePayload())
    ->setUrl(null)
    ->setSubscriptions([
    ]);

try {
    $response = (new Chatwoot\Client\Api\WebhooksApi(config: $config))->createAWebhook(
        account_id: 0,
        data: webhook_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling WebhooksApi#createAWebhook: {$e->getMessage()}";
}
