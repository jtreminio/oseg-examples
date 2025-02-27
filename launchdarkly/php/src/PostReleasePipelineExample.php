<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$phases_1_audiences_1_configuration_release_guardian_configuration = (new LaunchDarkly\Client\Model\ReleaseGuardianConfiguration())
    ->setMonitoringWindowMilliseconds(60000)
    ->setRolloutWeight(50)
    ->setRollbackOnRegression(true)
    ->setRandomizationUnit("user");

$phases_1_audiences_1_configuration = (new LaunchDarkly\Client\Model\AudienceConfiguration())
    ->setReleaseStrategy("the-release-strategy")
    ->setRequireApproval(true)
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setReleaseGuardianConfiguration($phases_1_audiences_1_configuration_release_guardian_configuration);

$phases_1_audiences_1 = (new LaunchDarkly\Client\Model\AudiencePost())
    ->setEnvironmentKey("the-environment-key")
    ->setName("Some name")
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

$create_release_pipeline_input = (new LaunchDarkly\Client\Model\CreateReleasePipelineInput())
    ->setKey("standard-pipeline")
    ->setName("Standard Pipeline")
    ->setDescription("Standard pipeline to roll out to production")
    ->setIsProjectDefault(false)
    ->setIsLegacy(false)
    ->setTags([
        "example-tag",
    ])
    ->setPhases($phases);

try {
    $response = (new LaunchDarkly\Client\Api\ReleasePipelinesBetaApi(config: $config))->postReleasePipeline(
        project_key: "the-project-key",
        create_release_pipeline_input: $create_release_pipeline_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasePipelinesBetaApi#postReleasePipeline: {$e->getMessage()}";
}
