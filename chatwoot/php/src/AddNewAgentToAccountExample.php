<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$add_new_agent_to_account_request = (new Chatwoot\Client\Model\AddNewAgentToAccountRequest())
    ->setEmail(null)
    ->setName(null)
    ->setRole(null)
    ->setAvailabilityStatus(null)
    ->setAutoOffline(null);

try {
    $response = (new Chatwoot\Client\Api\AgentsApi(config: $config))->addNewAgentToAccount(
        account_id: null,
        data: add_new_agent_to_account_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentsApi#addNewAgentToAccount: {$e->getMessage()}";
}
