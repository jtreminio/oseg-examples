<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");
// $config->setApiKey("agentBotApiKey", "AGENT_BOT_API_KEY");
// $config->setApiKey("platformAppApiKey", "PLATFORM_APP_API_KEY");

$contact_add_labels_request = (new Chatwoot\Client\Model\ContactAddLabelsRequest())
    ->setLabels([
    ]);

try {
    $response = (new Chatwoot\Client\Api\ContactLabelsApi(config: $config))->contactAddLabels(
        account_id: null,
        contact_identifier: null,
        data: contact_add_labels_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactLabelsApi#contactAddLabels: {$e->getMessage()}";
}
