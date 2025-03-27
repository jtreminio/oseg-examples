<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");
// $config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

$contact_add_labels_request = (new Chatwoot\Client\Model\ContactAddLabelsRequest())
    ->setLabels([
    ]);

try {
    $response = (new Chatwoot\Client\Api\ContactLabelsApi(config: $config))->contactAddLabels(
        account_id: 0,
        contact_identifier: "contact_identifier_string",
        data: contact_add_labels_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactLabelsApi#contactAddLabels: {$e->getMessage()}";
}
