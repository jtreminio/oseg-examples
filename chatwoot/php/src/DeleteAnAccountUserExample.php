<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$delete_an_account_user_request = (new Chatwoot\Client\Model\DeleteAnAccountUserRequest())
    ->setUserId(null);

try {
    (new Chatwoot\Client\Api\AccountUsersApi(config: $config))->deleteAnAccountUser(
        account_id: null,
        data: delete_an_account_user_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AccountUsersApi#deleteAnAccountUser: {$e->getMessage()}";
}
