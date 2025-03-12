<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\AutomationRuleApi(config: $config))->getAccountAutomationRule(
        account_id: null,
        page: 1,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AutomationRuleApi#getAccountAutomationRule: {$e->getMessage()}";
}
