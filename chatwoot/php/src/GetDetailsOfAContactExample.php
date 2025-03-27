<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

try {
    $response = (new Chatwoot\Client\Api\ContactsAPIApi(config: $config))->getDetailsOfAContact(
        inbox_identifier: "inbox_identifier_string",
        contact_identifier: "contact_identifier_string",
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsAPIApi#getDetailsOfAContact: {$e->getMessage()}";
}
