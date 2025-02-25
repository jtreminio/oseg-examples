<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\InsightsDeploymentsBetaApi(config: $config))->getDeployments(
        project_key: null,
        environment_key: null,
        application_key: null,
        limit: null,
        expand: null,
        from: null,
        to: null,
        after: null,
        before: null,
        kind: null,
        status: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsDeploymentsBeta#getDeployments: {$e->getMessage()}";
}
