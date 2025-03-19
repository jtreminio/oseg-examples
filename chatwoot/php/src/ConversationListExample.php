<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->conversationList(
        account_id: 0,
        assignee_type: "all",
        status: "open",
        page: 1,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#conversationList: {$e->getMessage()}";
}
