<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$delete_agent_in_inbox_request = (new Chatwoot\Client\Model\DeleteAgentInInboxRequest())
    ->setInboxId("inbox_id_string")
    ->setUserIds([
    ]);

try {
    (new Chatwoot\Client\Api\InboxesApi(config: $config))->deleteAgentInInbox(
        account_id: 0,
        data: delete_agent_in_inbox_request,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling InboxesApi#deleteAgentInInbox: {$e->getMessage()}";
}
