<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$client_side_availability = (new LaunchDarkly\Client\Model\ClientSideAvailabilityPost())
    ->setUsingEnvironmentId(true)
    ->setUsingMobileKey(true);

$feature_flag_body = (new LaunchDarkly\Client\Model\FeatureFlagBody())
    ->setName("My Flag")
    ->setKey("flag-key-123abc")
    ->setDescription(null)
    ->setIncludeInSnippet(null)
    ->setTemporary(null)
    ->setPurpose(null)
    ->setMaintainerId(null)
    ->setMaintainerTeamKey(null)
    ->setTags(null)
    ->setCustomProperties(null)
    ->setClientSideAvailability($client_side_availability);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->postFeatureFlag(
        project_key: null,
        feature_flag_body: $feature_flag_body,
        clone: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlags#postFeatureFlag: {$e->getMessage()}";
}
