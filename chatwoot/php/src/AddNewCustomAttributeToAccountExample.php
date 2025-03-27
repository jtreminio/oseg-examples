<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$custom_attribute_create_update_payload = (new Chatwoot\Client\Model\CustomAttributeCreateUpdatePayload())
    ->setAttributeDisplayName(null)
    ->setAttributeDisplayType(null)
    ->setAttributeDescription(null)
    ->setAttributeKey(null)
    ->setAttributeModel(null)
    ->setAttributeValues([
    ]);

try {
    $response = (new Chatwoot\Client\Api\CustomAttributesApi(config: $config))->addNewCustomAttributeToAccount(
        account_id: 0,
        data: $custom_attribute_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CustomAttributesApi#addNewCustomAttributeToAccount: {$e->getMessage()}";
}
