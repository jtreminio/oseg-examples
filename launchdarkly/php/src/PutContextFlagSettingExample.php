<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$value_put = (new LaunchDarkly\Client\Model\ValuePut())
    ->setComment("make sure this context experiences a specific variation");

try {
    (new LaunchDarkly\Client\Api\ContextSettingsApi(config: $config))->putContextFlagSetting(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        context_kind: "contextKind_string",
        context_key: "contextKey_string",
        feature_flag_key: "featureFlagKey_string",
        value_put: $value_put,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ContextSettingsApi#putContextFlagSetting: {$e->getMessage()}";
}
