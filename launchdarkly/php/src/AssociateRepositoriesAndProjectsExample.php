<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$mappings_1 = (new LaunchDarkly\Client\Model\InsightsRepositoryProject())
    ->setRepositoryKey("launchdarkly/LaunchDarkly-Docs")
    ->setProjectKey("default");

$mappings = [
    $mappings_1,
];

$insights_repository_project_mappings = (new LaunchDarkly\Client\Model\InsightsRepositoryProjectMappings())
    ->setMappings($mappings);

try {
    $response = (new LaunchDarkly\Client\Api\InsightsRepositoriesBetaApi(config: $config))->associateRepositoriesAndProjects(
        insights_repository_project_mappings: $insights_repository_project_mappings,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsRepositoriesBeta#associateRepositoriesAndProjects: {$e->getMessage()}";
}
