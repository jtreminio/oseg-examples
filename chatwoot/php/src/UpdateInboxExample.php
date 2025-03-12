<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$channel = (new Chatwoot\Client\Model\UpdateInboxRequestChannel())
    ->setWebsiteUrl(null)
    ->setWelcomeTitle(null)
    ->setWelcomeTagline(null)
    ->setAgentAwayMessage(null)
    ->setWidgetColor(null);

$update_inbox_request = (new Chatwoot\Client\Model\UpdateInboxRequest())
    ->setEnableAutoAssignment(null)
    ->setName(null)
    ->setAvatar(null)
    ->setChannel($channel);

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->updateInbox(
        account_id: null,
        id: null,
        data: update_inbox_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#updateInbox: {$e->getMessage()}";
}
