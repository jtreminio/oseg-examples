<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->getInboxMembers(
        account_id: null,
        inbox_id: null,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#getInboxMembers: {$e->getMessage()}";
}
