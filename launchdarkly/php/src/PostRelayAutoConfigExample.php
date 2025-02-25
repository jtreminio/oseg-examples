<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$policy_1 = (new LaunchDarkly\Client\Model\Statement())
    ->setEffect(LaunchDarkly\Client\Model\Statement::EFFECT_ALLOW)
    ->setResources([
        "proj/*:env/*",
    ])
    ->setNotResources(null)
    ->setActions([
        "*",
    ])
    ->setNotActions(null);

$policy = [
    $policy_1,
];

$relay_auto_config_post = (new LaunchDarkly\Client\Model\RelayAutoConfigPost())
    ->setName("Sample Relay Proxy config for all proj and env")
    ->setPolicy($policy);

try {
    $response = (new LaunchDarkly\Client\Api\RelayProxyConfigurationsApi(config: $config))->postRelayAutoConfig(
        relay_auto_config_post: $relay_auto_config_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling RelayProxyConfigurations#postRelayAutoConfig: {$e->getMessage()}";
}
