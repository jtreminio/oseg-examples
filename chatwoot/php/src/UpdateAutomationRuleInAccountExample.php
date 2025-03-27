<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$automation_rule_create_update_payload = (new Chatwoot\Client\Model\AutomationRuleCreateUpdatePayload())
    ->setName("Add label on message create event")
    ->setDescription("Add label support and sales on message create event if incoming message content contains text help")
    ->setEventName(Chatwoot\Client\Model\AutomationRuleCreateUpdatePayload::EVENT_NAME_MESSAGE_CREATED)
    ->setActive(null)
    ->setActions(json_decode(<<<'EOD'
        [
            {
                "action_name": "add_label",
                "action_params": [
                    "support"
                ]
            }
        ]
    EOD, true))
    ->setConditions(json_decode(<<<'EOD'
        [
            {
                "attribute_key": "content",
                "filter_operator": "contains",
                "query_operator": "nil",
                "values": [
                    "help"
                ]
            }
        ]
    EOD, true));

try {
    $response = (new Chatwoot\Client\Api\AutomationRuleApi(config: $config))->updateAutomationRuleInAccount(
        account_id: 0,
        id: 0,
        data: $automation_rule_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AutomationRuleApi#updateAutomationRuleInAccount: {$e->getMessage()}";
}
