<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\IntegrationDeliveryConfigurationsBetaApi(config: $config))->getIntegrationDeliveryConfigurations();

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationDeliveryConfigurationsBeta#getIntegrationDeliveryConfigurations: {$e->getMessage()}";
}
