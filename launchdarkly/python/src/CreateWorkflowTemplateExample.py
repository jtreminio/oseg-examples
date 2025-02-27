import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    stages_1_action = models.ActionInput(
    )

    stages_1_conditions_1 = models.ConditionInput(
        scheduleKind="relative",
        waitDuration=2,
        waitDurationUnit="calendarDay",
        kind="schedule",
    )

    stages_1_conditions = [
        stages_1_conditions_1,
    ]

    stages_1 = models.StageInput(
        name="10% rollout on day 1",
        executeConditionsInSequence=True,
        action=stages_1_action,
        conditions=stages_1_conditions,
    )

    stages = [
        stages_1,
    ]

    create_workflow_template_input = models.CreateWorkflowTemplateInput(
        key=None,
        name=None,
        description=None,
        workflowId=None,
        projectKey=None,
        environmentKey=None,
        flagKey=None,
        stages=stages,
    )

    try:
        response = api.WorkflowTemplatesApi(api_client).create_workflow_template(
            create_workflow_template_input=create_workflow_template_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling WorkflowTemplatesApi#create_workflow_template: %s\n" % e)
