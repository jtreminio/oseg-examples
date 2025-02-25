<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$context_instance_search = (new LaunchDarkly\Client\Model\ContextInstanceSearch())
    ->setFilter("{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}")
    ->setSort("-ts")
    ->setLimit(10)
    ->setContinuationToken("QAGFKH1313KUGI2351");

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->searchContextInstances(
        project_key: null,
        environment_key: null,
        context_instance_search: $context_instance_search,
        limit: null,
        continuation_token: null,
        sort: null,
        filter: null,
        include_total_count: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Contexts#searchContextInstances: {$e->getMessage()}";
}
