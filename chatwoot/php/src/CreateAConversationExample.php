<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

$public_conversation_create_payload = (new Chatwoot\Client\Model\PublicConversationCreatePayload())
    ->setCustomAttributes(null);

try {
    $response = (new Chatwoot\Client\Api\ConversationsAPIApi(config: $config))->createAConversation(
        inbox_identifier: "inbox_identifier_string",
        contact_identifier: "contact_identifier_string",
        data: $public_conversation_create_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsAPIApi#createAConversation: {$e->getMessage()}";
}
