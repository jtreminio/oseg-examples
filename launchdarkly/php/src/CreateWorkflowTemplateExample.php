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
    ->setExecuteConditionsInSequence(true)
    ->setAction($stages_1_action)
    ->setConditions($stages_1_conditions);

$stages = [
    $stages_1,
];

$create_workflow_template_input = (new LaunchDarkly\Client\Model\CreateWorkflowTemplateInput())
    ->setKey(null)
    ->setName(null)
    ->setDescription(null)
    ->setWorkflowId(null)
    ->setProjectKey(null)
    ->setEnvironmentKey(null)
    ->setFlagKey(null)
    ->setStages($stages);

try {
    $response = (new LaunchDarkly\Client\Api\WorkflowTemplatesApi(config: $config))->createWorkflowTemplate(
        create_workflow_template_input: $create_workflow_template_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling WorkflowTemplatesApi#createWorkflowTemplate: {$e->getMessage()}";
}
