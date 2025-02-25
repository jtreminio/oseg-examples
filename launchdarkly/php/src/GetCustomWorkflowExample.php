<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\WorkflowsApi(config: $config))->getCustomWorkflow(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        workflow_id: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Workflows#getCustomWorkflow: {$e->getMessage()}";
}
