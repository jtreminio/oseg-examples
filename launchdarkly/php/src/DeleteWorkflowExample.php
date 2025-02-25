<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\WorkflowsApi(config: $config))->deleteWorkflow(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        workflow_id: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Workflows#deleteWorkflow: {$e->getMessage()}";
}
