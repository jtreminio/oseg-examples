<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$integration_delivery_configuration_post = (new LaunchDarkly\Client\Model\IntegrationDeliveryConfigurationPost())
    ->setConfig(json_decode(<<<'EOD'
        {
            "optional": "example value for optional formVariables property for sample-integration",
            "required": "example value for required formVariables property for sample-integration"
        }
    EOD, true))
    ->setOn(false)
    ->setName("Sample integration")
    ->setTags([
        "example-tag",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\IntegrationDeliveryConfigurationsBetaApi(config: $config))->createIntegrationDeliveryConfiguration(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        integration_key: "integrationKey_string",
        integration_delivery_configuration_post: $integration_delivery_configuration_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationDeliveryConfigurationsBetaApi#createIntegrationDeliveryConfiguration: {$e->getMessage()}";
}
