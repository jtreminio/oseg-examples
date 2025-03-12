<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$update_agents_in_inbox_request = (new Chatwoot\Client\Model\UpdateAgentsInInboxRequest())
    ->setInboxId(null)
    ->setUserIds([
    ]);

try {
    $response = (new Chatwoot\Client\Api\InboxesApi(config: $config))->updateAgentsInInbox(
        account_id: null,
        data: update_agents_in_inbox_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#updateAgentsInInbox: {$e->getMessage()}";
}
