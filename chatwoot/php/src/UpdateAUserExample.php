<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$user_create_update_payload = (new Chatwoot\Client\Model\UserCreateUpdatePayload())
    ->setName(null)
    ->setEmail(null)
    ->setPassword(null);

try {
    $response = (new Chatwoot\Client\Api\UsersApi(config: $config))->updateAUser(
        id: null,
        data: user_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling UsersApi#updateAUser: {$e->getMessage()}";
}
