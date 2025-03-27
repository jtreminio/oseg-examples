<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\AgentsApi(config: $config))->getAccountAgents(
        account_id: 0,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentsApi#getAccountAgents: {$e->getMessage()}";
}
