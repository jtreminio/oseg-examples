<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "PLATFORM_APP_API_KEY");

try {
    $response = (new Chatwoot\Client\Api\AgentBotsApi(config: $config))->getDetailsOfASingleAgentBot(
        id: 0,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling AgentBotsApi#getDetailsOfASingleAgentBot: {$e->getMessage()}";
}
