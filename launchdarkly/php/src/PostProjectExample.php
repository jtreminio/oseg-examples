<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$project_post = (new LaunchDarkly\Client\Model\ProjectPost())
    ->setName("My Project")
    ->setKey("project-key-123abc")
    ->setIncludeInSnippetByDefault(null)
    ->setTags(null);

try {
    $response = (new LaunchDarkly\Client\Api\ProjectsApi(config: $config))->postProject(
        project_post: $project_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ProjectsApi#postProject: {$e->getMessage()}";
}
