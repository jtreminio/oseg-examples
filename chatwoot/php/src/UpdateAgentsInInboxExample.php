<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$add_new_agent_to_inbox_request = (new Chatwoot\Client\Model\AddNewAgentToInboxRequest())
    ->setInboxId("inbox_id_string")
    ->setUserIds([
    ]);

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->updateAgentsInInbox(
        account_id: 0,
        data: $add_new_agent_to_inbox_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#updateAgentsInInbox: {$e->getMessage()}";
}
