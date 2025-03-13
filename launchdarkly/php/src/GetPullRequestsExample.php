<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\InsightsPullRequestsBetaApi(config: $config))->getPullRequests(
        project_key: null,
        environment_key: null,
        application_key: null,
        status: null,
        query: null,
        limit: null,
        expand: null,
        sort: null,
        from: null,
        to: null,
        after: null,
        before: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsPullRequestsBetaApi#getPullRequests: {$e->getMessage()}";
}
