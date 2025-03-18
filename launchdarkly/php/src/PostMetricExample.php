<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$metric_post = (new LaunchDarkly\Client\Model\MetricPost())
    ->setKey("metric-key-123abc")
    ->setKind(LaunchDarkly\Client\Model\MetricPost::KIND_CUSTOM)
    ->setIsActive(true)
    ->setIsNumeric(false)
    ->setEventKey("trackedClick");

try {
    $response = (new LaunchDarkly\Client\Api\MetricsApi(config: $config))->postMetric(
        project_key: "projectKey_string",
        metric_post: $metric_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling MetricsApi#postMetric: {$e->getMessage()}";
}
