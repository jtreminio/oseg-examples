<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$value_put = (new LaunchDarkly\Client\Model\ValuePut())
    ->setComment("make sure this context experiences a specific variation");

try {
    (new LaunchDarkly\Client\Api\ContextSettingsApi(config: $config))->putContextFlagSetting(
        project_key: null,
        environment_key: null,
        context_kind: null,
        context_key: null,
        feature_flag_key: null,
        value_put: $value_put,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ContextSettings#putContextFlagSetting: {$e->getMessage()}";
}
