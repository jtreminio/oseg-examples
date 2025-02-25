<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

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
        project_key: null,
        environment_key: null,
        integration_key: null,
        integration_delivery_configuration_post: $integration_delivery_configuration_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationDeliveryConfigurationsBeta#createIntegrationDeliveryConfiguration: {$e->getMessage()}";
}
