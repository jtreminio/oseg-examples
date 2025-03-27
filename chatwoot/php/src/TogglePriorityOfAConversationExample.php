<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$toggle_priority_of_a_conversation_request = (new Chatwoot\Client\Model\TogglePriorityOfAConversationRequest())
    ->setPriority(Chatwoot\Client\Model\TogglePriorityOfAConversationRequest::PRIORITY_URGENT);

try {
    (new Chatwoot\Client\Api\ConversationsApi(config: $config))->togglePriorityOfAConversation(
        account_id: 0,
        conversation_id: 0,
        data: $toggle_priority_of_a_conversation_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#togglePriorityOfAConversation: {$e->getMessage()}";
}
