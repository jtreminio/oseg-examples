<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$update_agent_in_account_request = (new Chatwoot\Client\Model\UpdateAgentInAccountRequest())
    ->setRole(Chatwoot\Client\Model\UpdateAgentInAccountRequest::ROLE_AGENT)
    ->setAvailability(null)
    ->setAutoOffline(null);

try {
    $response = (new Chatwoot\Client\Api\AgentsApi(config: $config))->updateAgentInAccount(
        account_id: 0,
        id: 0,
        data: update_agent_in_account_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentsApi#updateAgentInAccount: {$e->getMessage()}";
}
