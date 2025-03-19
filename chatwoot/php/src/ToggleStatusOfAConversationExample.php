<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$toggle_status_of_a_conversation_request = (new Chatwoot\Client\Model\ToggleStatusOfAConversationRequest())
    ->setStatus(Chatwoot\Client\Model\ToggleStatusOfAConversationRequest::STATUS_OPEN);

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->toggleStatusOfAConversation(
        account_id: 0,
        conversation_id: 0,
        data: toggle_status_of_a_conversation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#toggleStatusOfAConversation: {$e->getMessage()}";
}
