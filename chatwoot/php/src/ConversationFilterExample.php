<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$payload_1 = (new Chatwoot\Client\Model\ContactFilterRequestPayloadInner())
    ->setAttributeKey("browser_language")
    ->setFilterOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::FILTER_OPERATOR_NOT_EQUAL_TO)
    ->setQueryOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::QUERY_OPERATOR_AND)
    ->setValues([
        "en",
    ]);

$payload_2 = (new Chatwoot\Client\Model\ContactFilterRequestPayloadInner())
    ->setAttributeKey("status")
    ->setFilterOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::FILTER_OPERATOR_EQUAL_TO)
    ->setQueryOperator(null)
    ->setValues([
        "pending",
    ]);

$payload = [
    $payload_1,
    $payload_2,
];

$conversation_filter_request = (new Chatwoot\Client\Model\ConversationFilterRequest())
    ->setPayload($payload);

try {
    $response = (new Chatwoot\Client\Api\ConversationsApi(config: $config))->conversationFilter(
        account_id: 123,
        body: conversation_filter_request,
        page: 1,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ConversationsApi#conversationFilter: {$e->getMessage()}";
}
