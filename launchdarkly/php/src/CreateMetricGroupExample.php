<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$metrics_1 = (new LaunchDarkly\Client\Model\MetricInMetricGroupInput())
    ->setKey("metric-key-123abc")
    ->setNameInGroup("Step 1");

$metrics = [
    $metrics_1,
];

$metric_group_post = (new LaunchDarkly\Client\Model\MetricGroupPost())
    ->setKey("metric-group-key-123abc")
    ->setName("My metric group")
    ->setKind(LaunchDarkly\Client\Model\MetricGroupPost::KIND_FUNNEL)
    ->setMaintainerId("569fdeadbeef1644facecafe")
    ->setTags([
        "ops",
    ])
    ->setDescription("Description of the metric group")
    ->setMetrics($metrics);

try {
    $response = (new LaunchDarkly\Client\Api\MetricsBetaApi(config: $config))->createMetricGroup(
        project_key: "projectKey_string",
        metric_group_post: $metric_group_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling MetricsBetaApi#createMetricGroup: {$e->getMessage()}";
}
