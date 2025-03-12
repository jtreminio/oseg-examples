<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$message_template_params = (new Chatwoot\Client\Model\NewConversationRequestMessageTemplateParams())
    ->setName("sample_issue_resolution")
    ->setCategory("UTILITY")
    ->setLanguage("en_US");

$message = (new Chatwoot\Client\Model\NewConversationRequestMessage())
    ->setContent(null)
    ->setTemplateParams($message_template_params);

$new_conversation_request = (new Chatwoot\Client\Model\NewConversationRequest())
    ->setInboxId(null)
    ->setSourceId(null)
    ->setContactId(null)
    ->setStatus(null)
    ->setAssigneeId(null)
    ->setTeamId(null)
    ->setMessage($message);

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->newConversation(
        account_id: null,
        data: new_conversation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#newConversation: {$e->getMessage()}";
}
