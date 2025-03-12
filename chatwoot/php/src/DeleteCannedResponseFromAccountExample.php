<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

try {
    (new Chatwoot\Client\Api\CannedResponsesApi(config: $config))->deleteCannedResponseFromAccount(
        account_id: null,
        id: null,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CannedResponsesApi#deleteCannedResponseFromAccount: {$e->getMessage()}";
}
