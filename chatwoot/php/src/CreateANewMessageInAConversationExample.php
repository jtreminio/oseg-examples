<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");

$template_params = (new Chatwoot\Client\Model\ConversationMessageCreateTemplateParams())
    ->setName("sample_issue_resolution")
    ->setCategory("UTILITY")
    ->setLanguage("en_US");

$conversation_message_create = (new Chatwoot\Client\Model\ConversationMessageCreate())
    ->setContent(null)
    ->setMessageType(null)
    ->setPrivate(null)
    ->setContentType(Chatwoot\Client\Model\ConversationMessageCreate::CONTENT_TYPE_CARDS)
    ->setTemplateParams($template_params);

try {
    $response = (new Chatwoot\Client\Api\MessagesApi(config: $config))->createANewMessageInAConversation(
        account_id: null,
        conversation_id: null,
        data: conversation_message_create,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling MessagesApi#createANewMessageInAConversation: {$e->getMessage()}";
}
