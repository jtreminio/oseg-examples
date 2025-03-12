<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$toggle_priority_of_a_conversation_request = (new Chatwoot\Client\Model\TogglePriorityOfAConversationRequest())
    ->setPriority(null);

try {
    (new Chatwoot\Client\Api\ConversationsApi(config: $config))->togglePriorityOfAConversation(
        account_id: null,
        conversation_id: null,
        data: toggle_priority_of_a_conversation_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#togglePriorityOfAConversation: {$e->getMessage()}";
}
