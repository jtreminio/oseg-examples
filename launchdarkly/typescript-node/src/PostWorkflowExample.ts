import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

const stages1Action = new models.ActionInput();

const stages1Conditions1 = new models.ConditionInput();
stages1Conditions1.scheduleKind = "relative";
stages1Conditions1.waitDuration = 2;
stages1Conditions1.waitDurationUnit = "calendarDay";
stages1Conditions1.kind = "schedule";

const stages1Conditions = [
  stages1Conditions1,
];

const stages1 = new models.StageInput();
stages1.name = "10% rollout on day 1";
stages1.action = stages1Action;
stages1.conditions = stages1Conditions;

const stages = [
  stages1,
];

const customWorkflowInput = new models.CustomWorkflowInput();
customWorkflowInput.name = "Progressive rollout starting in two days";
customWorkflowInput.description = "Turn flag on for 10% of customers each day";
customWorkflowInput.stages = stages;

apiCaller.postWorkflow(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  customWorkflowInput,
  undefined, // templateKey
  undefined, // dryRun
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowsApi#postWorkflow:");
  console.log(error.body);
});
