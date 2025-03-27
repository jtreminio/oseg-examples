<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$create_an_account_user_request = (new Chatwoot\Client\Model\CreateAnAccountUserRequest())
    ->setRole("role_string")
    ->setUserId(0);

try {
    $response = (new Chatwoot\Client\Api\AccountUsersApi(config: $config))->createAnAccountUser(
        account_id: 0,
        data: $create_an_account_user_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AccountUsersApi#createAnAccountUser: {$e->getMessage()}";
}
