<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$canned_response_create_update_payload = (new Chatwoot\Client\Model\CannedResponseCreateUpdatePayload())
    ->setContent(null)
    ->setShortCode(null);

try {
    $response = (new Chatwoot\Client\Api\CannedResponseApi(config: $config))->updateCannedResponseInAccount(
        account_id: null,
        id: null,
        data: canned_response_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CannedResponseApi#updateCannedResponseInAccount: {$e->getMessage()}";
}
