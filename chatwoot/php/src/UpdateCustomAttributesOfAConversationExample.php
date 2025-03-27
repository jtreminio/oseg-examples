<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$update_custom_attributes_of_a_conversation_request = (new Chatwoot\Client\Model\UpdateCustomAttributesOfAConversationRequest())
    ->setCustomAttributes(json_decode(<<<'EOD'
        {
            "order_id": "12345",
            "previous_conversation": "67890"
        }
    EOD, true));

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->updateCustomAttributesOfAConversation(
        account_id: 0,
        conversation_id: 0,
        data: $update_custom_attributes_of_a_conversation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#updateCustomAttributesOfAConversation: {$e->getMessage()}";
}
