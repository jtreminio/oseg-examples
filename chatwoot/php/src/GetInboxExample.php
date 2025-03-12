<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->getInbox(
        account_id: null,
        id: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#getInbox: {$e->getMessage()}";
}
