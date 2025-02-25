<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->getContexts(
        project_key: null,
        environment_key: null,
        kind: null,
        key: null,
        limit: null,
        continuation_token: null,
        sort: null,
        filter: null,
        include_total_count: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Contexts#getContexts: {$e->getMessage()}";
}
