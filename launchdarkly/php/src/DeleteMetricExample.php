<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\MetricsApi(config: $config))->deleteMetric(
        project_key: "projectKey_string",
        metric_key: "metricKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling MetricsApi#deleteMetric: {$e->getMessage()}";
}
