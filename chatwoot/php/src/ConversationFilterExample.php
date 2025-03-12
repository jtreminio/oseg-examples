<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$conversation_filter_request = (new Chatwoot\Client\Model\ConversationFilterRequest())
    ->setPayload(json_decode(<<<'EOD'
        [
            {
                "attribute_key": "browser_language",
                "filter_operator": "not_eq",
                "query_operator": "AND",
                "values": [
                    "en"
                ]
            },
            {
                "attribute_key": "status",
                "filter_operator": "eq",
                "query_operator": null,
                "values": [
                    "pending"
                ]
            }
        ]
    EOD, true));

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->conversationFilter(
        account_id: null,
        body: conversation_filter_request,
        page: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#conversationFilter: {$e->getMessage()}";
}
