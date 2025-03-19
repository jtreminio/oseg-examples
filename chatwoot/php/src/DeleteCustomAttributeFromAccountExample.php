<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

try {
    (new Chatwoot\Client\Api\CustomAttributesApi(config: $config))->deleteCustomAttributeFromAccount(
        account_id: 0,
        id: 0,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CustomAttributesApi#deleteCustomAttributeFromAccount: {$e->getMessage()}";
}
