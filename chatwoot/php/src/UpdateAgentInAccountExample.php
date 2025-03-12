<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$update_agent_in_account_request = (new Chatwoot\Client\Model\UpdateAgentInAccountRequest())
    ->setRole(null)
    ->setAvailability(null)
    ->setAutoOffline(null);

try {
    $response = (new Chatwoot\Client\Api\AgentsApi(config: $config))->updateAgentInAccount(
        account_id: null,
        id: null,
        data: update_agent_in_account_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentsApi#updateAgentInAccount: {$e->getMessage()}";
}
