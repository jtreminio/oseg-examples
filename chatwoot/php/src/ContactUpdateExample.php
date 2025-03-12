<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$contact_update = (new Chatwoot\Client\Model\ContactUpdate())
    ->setName(null)
    ->setEmail(null)
    ->setPhoneNumber(null)
    ->setAvatarUrl(null)
    ->setIdentifier(null)
    ->setAvatar(null);

try {
    $response = (new Chatwoot\Client\Api\ContactsApi(config: $config))->contactUpdate(
        account_id: null,
        id: null,
        data: contact_update,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsApi#contactUpdate: {$e->getMessage()}";
}
