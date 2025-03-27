<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$payload_1 = (new Chatwoot\Client\Model\ContactFilterRequestPayloadInner())
    ->setAttributeKey("name")
    ->setFilterOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::FILTER_OPERATOR_EQUAL_TO)
    ->setQueryOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::QUERY_OPERATOR_AND)
    ->setValues([
        "en",
    ]);

$payload_2 = (new Chatwoot\Client\Model\ContactFilterRequestPayloadInner())
    ->setAttributeKey("country_code")
    ->setFilterOperator(Chatwoot\Client\Model\ContactFilterRequestPayloadInner::FILTER_OPERATOR_EQUAL_TO)
    ->setQueryOperator(null)
    ->setValues([
        "us",
    ]);

$payload = [
    $payload_1,
    $payload_2,
];

$contact_filter_request = (new Chatwoot\Client\Model\ContactFilterRequest())
    ->setPayload($payload);

try {
    $response = (new Chatwoot\Client\Api\ContactsApi(config: $config))->contactFilter(
        account_id: 0,
        body: contact_filter_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsApi#contactFilter: {$e->getMessage()}";
}
