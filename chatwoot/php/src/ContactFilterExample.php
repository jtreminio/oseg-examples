<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");
// $config->setApiKey("api_access_token", "AGENT_BOT_API_KEY");

$contact_filter_request = (new Chatwoot\Client\Model\ContactFilterRequest())
    ->setPayload(json_decode(<<<'EOD'
        [
            {
                "attribute_key": "name",
                "filter_operator": "equal_to",
                "query_operator": "AND",
                "values": [
                    "en"
                ]
            },
            {
                "attribute_key": "country_code",
                "filter_operator": "equal_to",
                "query_operator": null,
                "values": [
                    "us"
                ]
            }
        ]
    EOD, true));

try {
    $response = (new Chatwoot\Client\Api\ContactsApi(config: $config))->contactFilter(
        account_id: 0,
        body: contact_filter_request,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling ContactsApi#contactFilter: {$e->getMessage()}";
}
