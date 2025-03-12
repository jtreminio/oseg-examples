<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$contact_inbox_creation_request = (new Chatwoot\Client\Model\ContactInboxCreationRequest())
    ->setInboxId(null)
    ->setSourceId(null);

try {
    $response = (new Chatwoot\Client\Api\ContactApi(config: $config))->contactInboxCreation(
        account_id: null,
        id: null,
        data: contact_inbox_creation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactApi#contactInboxCreation: {$e->getMessage()}";
}
