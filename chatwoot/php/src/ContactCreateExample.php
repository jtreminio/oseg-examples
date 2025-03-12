<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$contact_create = (new Chatwoot\Client\Model\ContactCreate())
    ->setInboxId(null)
    ->setName(null)
    ->setEmail(null)
    ->setPhoneNumber(null)
    ->setAvatarUrl(null)
    ->setIdentifier(null)
    ->setAvatar(null);

try {
    $response = (new Chatwoot\Client\Api\ContactsApi(config: $config))->contactCreate(
        account_id: null,
        data: contact_create,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsApi#contactCreate: {$e->getMessage()}";
}
