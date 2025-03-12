<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$conversation_add_labels_request = (new Chatwoot\Client\Model\ConversationAddLabelsRequest())
    ->setLabels([
    ]);

try {
    $response = (new Chatwoot\Client\Api\ConversationLabelsApi(config: $config))->conversationAddLabels(
        account_id: null,
        conversation_id: null,
        data: conversation_add_labels_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationLabelsApi#conversationAddLabels: {$e->getMessage()}";
}
