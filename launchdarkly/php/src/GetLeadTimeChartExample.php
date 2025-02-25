<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\InsightsChartsBetaApi(config: $config))->getLeadTimeChart(
        project_key: null,
        environment_key: null,
        application_key: null,
        from: null,
        to: null,
        bucket_type: null,
        bucket_ms: null,
        group_by: null,
        expand: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsChartsBeta#getLeadTimeChart: {$e->getMessage()}";
}
