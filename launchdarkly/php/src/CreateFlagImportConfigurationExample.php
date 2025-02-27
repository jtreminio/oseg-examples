<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$flag_import_configuration_post = (new LaunchDarkly\Client\Model\FlagImportConfigurationPost())
    ->setConfig(json_decode(<<<'EOD'
        {
            "environmentId": "The ID of the environment in the external system",
            "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
            "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
            "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
            "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
            "workspaceApiKey": "An API key with read permissions in the external feature management system",
            "workspaceId": "The ID of the workspace in the external system"
        }
    EOD, true))
    ->setName("Sample configuration")
    ->setTags([
        "example-tag",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\FlagImportConfigurationsBetaApi(config: $config))->createFlagImportConfiguration(
        project_key: null,
        integration_key: null,
        flag_import_configuration_post: $flag_import_configuration_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration: {$e->getMessage()}";
}
