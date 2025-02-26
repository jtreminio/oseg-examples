<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$metrics_1 = (new LaunchDarkly\Client\Model\MetricInput())
    ->setKey("metric-key-123abc")
    ->setIsGroup(true)
    ->setPrimary(true);

$metrics = [
    $metrics_1,
];

$holdout_post_request = (new LaunchDarkly\Client\Model\HoldoutPostRequest())
    ->setName("holdout-one-name")
    ->setKey("holdout-key")
    ->setDescription("My holdout-one description")
    ->setRandomizationunit("user")
    ->setHoldoutamount("10")
    ->setPrimarymetrickey("metric-key-123abc")
    ->setPrerequisiteflagkey("flag-key-123abc")
    ->setMaintainerId(null)
    ->setAttributes([
        "country",
        "device",
        "os",
    ])
    ->setMetrics($metrics);

try {
    $response = (new LaunchDarkly\Client\Api\HoldoutsBetaApi(config: $config))->postHoldout(
        project_key: null,
        environment_key: null,
        holdout_post_request: $holdout_post_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling HoldoutsBetaApi#postHoldout: {$e->getMessage()}";
}
