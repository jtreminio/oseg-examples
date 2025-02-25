<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\MetricsApi(config: $config))->deleteMetric(
        project_key: null,
        metric_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Metrics#deleteMetric: {$e->getMessage()}";
}
