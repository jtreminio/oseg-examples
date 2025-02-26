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
        action=stages_1_action,
        conditions=stages_1_conditions,
    )

    stages = [
        stages_1,
    ]

    custom_workflow_input = models.CustomWorkflowInput(
        name="Progressive rollout starting in two days",
        description="Turn flag on for 10% of customers each day",
        stages=stages,
    )

    try:
        response = api.WorkflowsApi(api_client).post_workflow(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            custom_workflow_input=custom_workflow_input,
            template_key=None,
            dry_run=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling WorkflowsApi#post_workflow: %s\n" % e)
