<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

try {
    $response = (new Chatwoot\Client\Api\ContactsAPIApi(config: $config))->getDetailsOfAContact(
        inbox_identifier: null,
        contact_identifier: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsAPIApi#getDetailsOfAContact: {$e->getMessage()}";
}
