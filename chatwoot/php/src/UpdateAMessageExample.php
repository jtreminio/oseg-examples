<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

$public_message_update_payload = (new Chatwoot\Client\Model\PublicMessageUpdatePayload());

try {
    $response = (new Chatwoot\Client\Api\MessagesAPIApi(config: $config))->updateAMessage(
        inbox_identifier: null,
        contact_identifier: null,
        conversation_id: null,
        message_id: null,
        data: public_message_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling MessagesAPIApi#updateAMessage: {$e->getMessage()}";
}
