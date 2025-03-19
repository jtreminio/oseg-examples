<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$client_side_availability = (new LaunchDarkly\Client\Model\ClientSideAvailabilityPost())
    ->setUsingEnvironmentId(true)
    ->setUsingMobileKey(true);

$feature_flag_body = (new LaunchDarkly\Client\Model\FeatureFlagBody())
    ->setName("My Flag")
    ->setKey("flag-key-123abc")
    ->setClientSideAvailability($client_side_availability);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->postFeatureFlag(
        project_key: "projectKey_string",
        feature_flag_body: $feature_flag_body,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#postFeatureFlag: {$e->getMessage()}";
}
