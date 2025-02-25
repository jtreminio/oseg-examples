<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\FlagImportConfigurationsBetaApi(config: $config))->getFlagImportConfiguration(
        project_key: null,
        integration_key: null,
        integration_id: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagImportConfigurationsBeta#getFlagImportConfiguration: {$e->getMessage()}";
}
