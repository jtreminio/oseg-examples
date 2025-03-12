<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$update_conversation_request = (new Chatwoot\Client\Model\UpdateConversationRequest())
    ->setPriority(null)
    ->setSlaPolicyId(null);

try {
    (new Chatwoot\Client\Api\ConversationsApi(config: $config))->updateConversation(
        account_id: null,
        conversation_id: null,
        data: update_conversation_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#updateConversation: {$e->getMessage()}";
}
