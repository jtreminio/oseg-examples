<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$randomization_units_1 = (new LaunchDarkly\Client\Model\RandomizationUnitInput())
    ->setRandomizationUnit("user")
    ->setStandardRandomizationUnit(LaunchDarkly\Client\Model\RandomizationUnitInput::STANDARD_RANDOMIZATION_UNIT_ORGANIZATION)
    ->setDefault(null);

$randomization_units = [
    $randomization_units_1,
];

$randomization_settings_put = (new LaunchDarkly\Client\Model\RandomizationSettingsPut())
    ->setRandomizationUnits($randomization_units);

try {
    $response = (new LaunchDarkly\Client\Api\ExperimentsApi(config: $config))->putExperimentationSettings(
        project_key: "the-project-key",
        randomization_settings_put: $randomization_settings_put,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Experiments#putExperimentationSettings: {$e->getMessage()}";
}
