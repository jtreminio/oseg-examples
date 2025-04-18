<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\WorkflowTemplatesApi(config: $config))->deleteWorkflowTemplate(
        template_key: "templateKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling WorkflowTemplatesApi#deleteWorkflowTemplate: {$e->getMessage()}";
}
