<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\IntegrationDeliveryConfigurationsBetaApi(config: $config))->deleteIntegrationDeliveryConfiguration(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        integration_key: "integrationKey_string",
        id: "id_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationDeliveryConfigurationsBetaApi#deleteIntegrationDeliveryConfiguration: {$e->getMessage()}";
}
