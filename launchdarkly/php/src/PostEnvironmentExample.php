<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$environment_post = (new LaunchDarkly\Client\Model\EnvironmentPost())
    ->setName("My Environment")
    ->setKey("environment-key-123abc")
    ->setColor("DADBEE");

try {
    $response = (new LaunchDarkly\Client\Api\EnvironmentsApi(config: $config))->postEnvironment(
        project_key: "projectKey_string",
        environment_post: $environment_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling EnvironmentsApi#postEnvironment: {$e->getMessage()}";
}
