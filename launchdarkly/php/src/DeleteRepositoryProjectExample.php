<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\InsightsRepositoriesBetaApi(config: $config))->deleteRepositoryProject(
        repository_key: "repositoryKey_string",
        project_key: "projectKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsRepositoriesBetaApi#deleteRepositoryProject: {$e->getMessage()}";
}
