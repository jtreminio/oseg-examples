<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$contact_add_labels_request = (new Chatwoot\Client\Model\ContactAddLabelsRequest())
    ->setLabels([
    ]);

try {
    $response = (new Chatwoot\Client\Api\ConversationLabelsApi(config: $config))->conversationAddLabels(
        account_id: 0,
        conversation_id: 0,
        data: $contact_add_labels_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationLabelsApi#conversationAddLabels: {$e->getMessage()}";
}
