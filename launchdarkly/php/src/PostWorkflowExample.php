<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$stages_1_action = (new LaunchDarkly\Client\Model\ActionInput());

$stages_1_conditions_1 = (new LaunchDarkly\Client\Model\ConditionInput())
    ->setScheduleKind("relative")
    ->setExecutionDate(null)
    ->setWaitDuration(2)
    ->setWaitDurationUnit("calendarDay")
    ->setExecuteNow(null)
    ->setDescription(null)
    ->setKind("schedule")
    ->setNotifyMemberIds(null)
    ->setNotifyTeamKeys(null);

$stages_1_conditions = [
    $stages_1_conditions_1,
];

$stages_1 = (new LaunchDarkly\Client\Model\StageInput())
    ->setName("10% rollout on day 1")
    ->setExecuteConditionsInSequence(null)
    ->setAction($stages_1_action)
    ->setConditions($stages_1_conditions);

$stages = [
    $stages_1,
];

$custom_workflow_input = (new LaunchDarkly\Client\Model\CustomWorkflowInput())
    ->setName("Progressive rollout starting in two days")
    ->setMaintainerId(null)
    ->setDescription("Turn flag on for 10% of customers each day")
    ->setTemplateKey(null)
    ->setStages($stages);

try {
    $response = (new LaunchDarkly\Client\Api\WorkflowsApi(config: $config))->postWorkflow(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        custom_workflow_input: $custom_workflow_input,
        template_key: null,
        dry_run: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling WorkflowsApi#postWorkflow: {$e->getMessage()}";
}
