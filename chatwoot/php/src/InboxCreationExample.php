<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$inbox_creation_request = (new Chatwoot\Client\Model\InboxCreationRequest())
    ->setName(null)
    ->setAvatar(null);

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->inboxCreation(
        account_id: 0,
        data: inbox_creation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#inboxCreation: {$e->getMessage()}";
}
