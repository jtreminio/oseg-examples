<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$account_create_update_payload = (new Chatwoot\Client\Model\AccountCreateUpdatePayload())
    ->setName(null);

try {
    $response = (new Chatwoot\Client\Api\AccountsApi(config: $config))->updateAnAccount(
        account_id: 0,
        data: $account_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AccountsApi#updateAnAccount: {$e->getMessage()}";
}
