<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$boolean_defaults = (new LaunchDarkly\Client\Model\BooleanFlagDefaults())
    ->setTrueDisplayName("True")
    ->setFalseDisplayName("False")
    ->setTrueDescription("serve true")
    ->setFalseDescription("serve false")
    ->setOnVariation(0)
    ->setOffVariation(1);

$default_client_side_availability = (new LaunchDarkly\Client\Model\DefaultClientSideAvailability())
    ->setUsingMobileKey(true)
    ->setUsingEnvironmentId(true);

$upsert_flag_defaults_payload = (new LaunchDarkly\Client\Model\UpsertFlagDefaultsPayload())
    ->setTemporary(true)
    ->setTags([
        "tag-1",
        "tag-2",
    ])
    ->setBooleanDefaults($boolean_defaults)
    ->setDefaultClientSideAvailability($default_client_side_availability);

try {
    $response = (new LaunchDarkly\Client\Api\ProjectsApi(config: $config))->putFlagDefaultsByProject(
        project_key: null,
        upsert_flag_defaults_payload: $upsert_flag_defaults_payload,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ProjectsApi#putFlagDefaultsByProject: {$e->getMessage()}";
}
