<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$message_template_params = (new Chatwoot\Client\Model\NewConversationRequestMessageTemplateParams())
    ->setName("sample_issue_resolution")
    ->setCategory("UTILITY")
    ->setLanguage("en_US")
    ->setProcessedParams(json_decode(<<<'EOD'
        {
            "1": "Chatwoot"
        }
    EOD, true));

$message = (new Chatwoot\Client\Model\NewConversationRequestMessage())
    ->setContent("content_string")
    ->setTemplateParams($message_template_params);

$new_conversation_request = (new Chatwoot\Client\Model\NewConversationRequest())
    ->setInboxId("inbox_id_string")
    ->setSourceId("source_id_string")
    ->setContactId(null)
    ->setStatus(null)
    ->setAssigneeId(null)
    ->setTeamId(null)
    ->setAdditionalAttributes(null)
    ->setCustomAttributes(json_decode(<<<'EOD'
        {
            "attribute_key": "attribute_value",
            "priority_conversation_number": 3
        }
    EOD, true))
    ->setMessage($message);

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->newConversation(
        account_id: 0,
        data: new_conversation_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#newConversation: {$e->getMessage()}";
}
