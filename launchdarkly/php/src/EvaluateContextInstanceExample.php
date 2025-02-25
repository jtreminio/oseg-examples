<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->evaluateContextInstance(
        project_key: null,
        environment_key: null,
        request_body: json_decode(<<<'EOD'
            {
                "key": "user-key-123abc",
                "kind": "user",
                "otherAttribute": "other attribute value"
            }
        EOD, true),
        limit: null,
        offset: null,
        sort: null,
        filter: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Contexts#evaluateContextInstance: {$e->getMessage()}";
}
