<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$template_params = (new Chatwoot\Client\Model\NewConversationRequestMessageTemplateParams())
    ->setName("sample_issue_resolution")
    ->setCategory("UTILITY")
    ->setLanguage("en_US")
    ->setProcessedParams(json_decode(<<<'EOD'
        {
            "1": "Chatwoot"
        }
    EOD, true));

$conversation_message_create = (new Chatwoot\Client\Model\ConversationMessageCreate())
    ->setContent("content_string")
    ->setMessageType(null)
    ->setPrivate(null)
    ->setContentType(Chatwoot\Client\Model\ConversationMessageCreate::CONTENT_TYPE_CARDS)
    ->setContentAttributes(null)
    ->setTemplateParams($template_params);

try {
    $response = (new Chatwoot\Client\Api\MessagesApi(config: $config))->createANewMessageInAConversation(
        account_id: 0,
        conversation_id: 0,
        data: conversation_message_create,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling MessagesApi#createANewMessageInAConversation: {$e->getMessage()}";
}
