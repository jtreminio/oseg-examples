<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$stages_1_action = (new LaunchDarkly\Client\Model\ActionInput());

$stages_1_conditions_1 = (new LaunchDarkly\Client\Model\ConditionInput())
    ->setScheduleKind("relative")
    ->setWaitDuration(2)
    ->setWaitDurationUnit("calendarDay")
    ->setKind("schedule");

$stages_1_conditions = [
    $stages_1_conditions_1,
];

$stages_1 = (new LaunchDarkly\Client\Model\StageInput())
    ->setName("10% rollout on day 1")
    ->setAction($stages_1_action)
    ->setConditions($stages_1_conditions);

$stages = [
    $stages_1,
];

$custom_workflow_input = (new LaunchDarkly\Client\Model\CustomWorkflowInput())
    ->setName("Progressive rollout starting in two days")
    ->setDescription("Turn flag on for 10% of customers each day")
    ->setStages($stages);

try {
    $response = (new LaunchDarkly\Client\Api\WorkflowsApi(config: $config))->postWorkflow(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        custom_workflow_input: $custom_workflow_input,
        template_key: null,
        dry_run: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling WorkflowsApi#postWorkflow: {$e->getMessage()}";
}
