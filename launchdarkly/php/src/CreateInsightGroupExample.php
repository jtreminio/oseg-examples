<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$post_insight_group_params = (new LaunchDarkly\Client\Model\PostInsightGroupParams())
    ->setName("Production - All Apps")
    ->setKey("default-production-all-apps")
    ->setProjectKey("default")
    ->setEnvironmentKey("production")
    ->setApplicationKeys([
        "billing-service",
        "inventory-service",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\InsightsScoresBetaApi(config: $config))->createInsightGroup(
        post_insight_group_params: $post_insight_group_params,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsScoresBetaApi#createInsightGroup: {$e->getMessage()}";
}
