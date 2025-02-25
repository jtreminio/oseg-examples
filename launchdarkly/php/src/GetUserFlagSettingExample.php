<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\UserSettingsApi(config: $config))->getUserFlagSetting(
        project_key: null,
        environment_key: null,
        user_key: null,
        feature_flag_key: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling UserSettings#getUserFlagSetting: {$e->getMessage()}";
}
