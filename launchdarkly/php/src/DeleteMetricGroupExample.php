<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\MetricsBetaApi(config: $config))->deleteMetricGroup(
        project_key: null,
        metric_group_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling MetricsBetaApi#deleteMetricGroup: {$e->getMessage()}";
}
