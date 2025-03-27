<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

$public_message_update_payload = (new Chatwoot\Client\Model\PublicMessageUpdatePayload())
    ->setSubmittedValues(null);

try {
    $response = (new Chatwoot\Client\Api\MessagesAPIApi(config: $config))->updateAMessage(
        inbox_identifier: "inbox_identifier_string",
        contact_identifier: "contact_identifier_string",
        conversation_id: 0,
        message_id: 0,
        data: $public_message_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling MessagesAPIApi#updateAMessage: {$e->getMessage()}";
}
