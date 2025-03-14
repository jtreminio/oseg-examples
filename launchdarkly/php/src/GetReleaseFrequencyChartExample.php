<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\InsightsChartsBetaApi(config: $config))->getReleaseFrequencyChart(
        project_key: null,
        environment_key: null,
        application_key: null,
        has_experiments: null,
        global: null,
        group_by: null,
        from: null,
        to: null,
        bucket_type: null,
        bucket_ms: null,
        expand: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsChartsBetaApi#getReleaseFrequencyChart: {$e->getMessage()}";
}
