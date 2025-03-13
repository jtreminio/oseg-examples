<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_operation_1 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("replace")
    ->setPath("/name");

$patch_operation = [
    $patch_operation_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\MetricsBetaApi(config: $config))->patchMetricGroup(
        project_key: "projectKey_string",
        metric_group_key: "metricGroupKey_string",
        patch_operation: $patch_operation,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling MetricsBetaApi#patchMetricGroup: {$e->getMessage()}";
}
