<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\CustomAttributesApi(config: $config))->getAccountCustomAttribute(
        account_id: null,
        attribute_model: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CustomAttributesApi#getAccountCustomAttribute: {$e->getMessage()}";
}
