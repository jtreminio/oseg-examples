<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\SegmentsApi(config: $config))->getContextInstanceSegmentsMembershipByEnv(
        project_key: null,
        environment_key: null,
        request_body: json_decode(<<<'EOD'
            {
                "address": {
                    "city": "Springfield",
                    "street": "123 Main Street"
                },
                "jobFunction": "doctor",
                "key": "context-key-123abc",
                "kind": "user",
                "name": "Sandy"
            }
        EOD, true),
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling SegmentsApi#getContextInstanceSegmentsMembershipByEnv: {$e->getMessage()}";
}
