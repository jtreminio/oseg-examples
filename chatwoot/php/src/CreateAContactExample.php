<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

$public_contact_create_update_payload = (new Chatwoot\Client\Model\PublicContactCreateUpdatePayload())
    ->setIdentifier(null)
    ->setIdentifierHash(null)
    ->setEmail(null)
    ->setName(null)
    ->setPhoneNumber(null)
    ->setAvatarUrl(null);

try {
    $response = (new Chatwoot\Client\Api\ContactsAPIApi(config: $config))->createAContact(
        inbox_identifier: null,
        data: public_contact_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsAPIApi#createAContact: {$e->getMessage()}";
}
