<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$context_search = (new LaunchDarkly\Client\Model\ContextSearch())
    ->setFilter("*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]")
    ->setSort("-ts")
    ->setLimit(10)
    ->setContinuationToken("QAGFKH1313KUGI2351");

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->searchContexts(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        context_search: $context_search,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ContextsApi#searchContexts: {$e->getMessage()}";
}
