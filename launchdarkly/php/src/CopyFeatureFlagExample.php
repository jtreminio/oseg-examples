<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$source = (new LaunchDarkly\Client\Model\FlagCopyConfigEnvironment())
    ->setKey("source-env-key-123abc")
    ->setCurrentVersion(1);

$target = (new LaunchDarkly\Client\Model\FlagCopyConfigEnvironment())
    ->setKey("target-env-key-123abc")
    ->setCurrentVersion(1);

$flag_copy_config_post = (new LaunchDarkly\Client\Model\FlagCopyConfigPost())
    ->setComment("optional comment")
    ->setIncludedActions(null)
    ->setExcludedActions(null)
    ->setSource($source)
    ->setTarget($target);

try {
    $response = (new LaunchDarkly\Client\Api\FeatureFlagsApi(config: $config))->copyFeatureFlag(
        project_key: null,
        feature_flag_key: null,
        flag_copy_config_post: $flag_copy_config_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FeatureFlagsApi#copyFeatureFlag: {$e->getMessage()}";
}
