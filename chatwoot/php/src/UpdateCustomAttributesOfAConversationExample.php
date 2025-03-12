<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$update_custom_attributes_of_a_conversation_request = (new Chatwoot\Client\Model\UpdateCustomAttributesOfAConversationRequest());

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->updateCustomAttributesOfAConversation(
        account_id: null,
        conversation_id: null,
        data: update_custom_attributes_of_a_conversation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#updateCustomAttributesOfAConversation: {$e->getMessage()}";
}
