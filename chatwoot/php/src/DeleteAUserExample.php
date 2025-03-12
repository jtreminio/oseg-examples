<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

try {
    (new Chatwoot\Client\Api\UsersApi(config: $config))->deleteAUser(
        id: null,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling UsersApi#deleteAUser: {$e->getMessage()}";
}
