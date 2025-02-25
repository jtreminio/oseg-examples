<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$post_deployment_event_input = (new LaunchDarkly\Client\Model\PostDeploymentEventInput())
    ->setProjectKey("default")
    ->setEnvironmentKey("production")
    ->setApplicationKey("billing-service")
    ->setVersion("a90a8a2")
    ->setEventType(LaunchDarkly\Client\Model\PostDeploymentEventInput::EVENT_TYPE_STARTED)
    ->setApplicationName("Billing Service")
    ->setApplicationKind(LaunchDarkly\Client\Model\PostDeploymentEventInput::APPLICATION_KIND_SERVER)
    ->setVersionName("v1.0.0")
    ->setEventTime(1706701522000)
    ->setEventMetadata(json_decode(<<<'EOD'
        {
            "buildSystemVersion": "v1.2.3"
        }
    EOD, true))
    ->setDeploymentMetadata(json_decode(<<<'EOD'
        {
            "buildNumber": "1234"
        }
    EOD, true));

try {
    (new LaunchDarkly\Client\Api\InsightsDeploymentsBetaApi(config: $config))->createDeploymentEvent(
        post_deployment_event_input: $post_deployment_event_input,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsDeploymentsBeta#createDeploymentEvent: {$e->getMessage()}";
}
