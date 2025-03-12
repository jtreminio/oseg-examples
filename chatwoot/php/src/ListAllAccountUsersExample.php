<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\AccountUsersApi(config: $config))->listAllAccountUsers(
        account_id: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AccountUsersApi#listAllAccountUsers: {$e->getMessage()}";
}
