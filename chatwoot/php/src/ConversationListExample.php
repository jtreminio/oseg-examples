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
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->conversationList(
        account_id: null,
        assignee_type: "all",
        status: "open",
        q: null,
        inbox_id: null,
        team_id: null,
        labels: null,
        page: 1,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#conversationList: {$e->getMessage()}";
}
