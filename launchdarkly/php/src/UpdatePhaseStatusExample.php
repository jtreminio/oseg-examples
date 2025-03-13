<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$audiences_1_release_guardian_configuration = (new LaunchDarkly\Client\Model\ReleaseGuardianConfigurationInput())
    ->setMonitoringWindowMilliseconds(60000)
    ->setRolloutWeight(50)
    ->setRollbackOnRegression(true)
    ->setRandomizationUnit("user");

$audiences_1 = (new LaunchDarkly\Client\Model\ReleaserAudienceConfigInput())
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setReleaseGuardianConfiguration($audiences_1_release_guardian_configuration);

$audiences = [
    $audiences_1,
];

$update_phase_status_input = (new LaunchDarkly\Client\Model\UpdatePhaseStatusInput())
    ->setAudiences($audiences);

try {
    $response = (new LaunchDarkly\Client\Api\ReleasesBetaApi(config: $config))->updatePhaseStatus(
        project_key: "projectKey_string",
        flag_key: "flagKey_string",
        phase_id: "phaseId_string",
        update_phase_status_input: $update_phase_status_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasesBetaApi#updatePhaseStatus: {$e->getMessage()}";
}
