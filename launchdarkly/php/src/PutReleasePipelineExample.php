<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$phases_1_audiences_1_configuration_release_guardian_configuration = (new LaunchDarkly\Client\Model\ReleaseGuardianConfiguration())
    ->setMonitoringWindowMilliseconds(60000)
    ->setRolloutWeight(50)
    ->setRollbackOnRegression(true)
    ->setRandomizationUnit("user");

$phases_1_audiences_1_configuration = (new LaunchDarkly\Client\Model\AudienceConfiguration())
    ->setReleaseStrategy("releaseStrategy_string")
    ->setRequireApproval(true)
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setReleaseGuardianConfiguration($phases_1_audiences_1_configuration_release_guardian_configuration);

$phases_1_audiences_1 = (new LaunchDarkly\Client\Model\AudiencePost())
    ->setEnvironmentKey("environmentKey_string")
    ->setName("name_string")
    ->setSegmentKeys([
    ])
    ->setConfiguration($phases_1_audiences_1_configuration);

$phases_1_audiences = [
    $phases_1_audiences_1,
];

$phases_1 = (new LaunchDarkly\Client\Model\CreatePhaseInput())
    ->setName("Phase 1 - Testing")
    ->setAudiences($phases_1_audiences);

$phases = [
    $phases_1,
];

$update_release_pipeline_input = (new LaunchDarkly\Client\Model\UpdateReleasePipelineInput())
    ->setName("Standard Pipeline")
    ->setDescription("Standard pipeline to roll out to production")
    ->setTags([
        "example-tag",
    ])
    ->setPhases($phases);

try {
    $response = (new LaunchDarkly\Client\Api\ReleasePipelinesBetaApi(config: $config))->putReleasePipeline(
        project_key: "projectKey_string",
        pipeline_key: "pipelineKey_string",
        update_release_pipeline_input: $update_release_pipeline_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasePipelinesBetaApi#putReleasePipeline: {$e->getMessage()}";
}
