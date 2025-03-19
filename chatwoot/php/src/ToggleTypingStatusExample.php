<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

try {
    (new Chatwoot\Client\Api\ConversationsAPIApi(config: $config))->toggleTypingStatus(
        inbox_identifier: "inbox_identifier_string",
        contact_identifier: "contact_identifier_string",
        conversation_id: 0,
        typing_status: "typing_status_string",
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsAPIApi#toggleTypingStatus: {$e->getMessage()}";
}
