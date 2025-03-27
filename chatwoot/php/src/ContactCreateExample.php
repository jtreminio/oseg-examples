<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$contact_create = (new Chatwoot\Client\Model\ContactCreate())
    ->setInboxId(0)
    ->setName(null)
    ->setEmail(null)
    ->setPhoneNumber(null)
    ->setAvatarUrl(null)
    ->setIdentifier(null)
    ->setAvatar(null)
    ->setCustomAttributes(null);

try {
    $response = (new Chatwoot\Client\Api\ContactsApi(config: $config))->contactCreate(
        account_id: 0,
        data: $contact_create,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsApi#contactCreate: {$e->getMessage()}";
}
