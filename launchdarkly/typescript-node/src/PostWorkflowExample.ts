import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

const stages1Action: models.ActionInput = {
};

const stages1Conditions1: models.ConditionInput = {
  scheduleKind: "relative",
  waitDuration: 2,
  waitDurationUnit: "calendarDay",
  kind: "schedule",
};

const stages1Conditions = [
  stages1Conditions1,
];

const stages1: models.StageInput = {
  name: "10% rollout on day 1",
  action: stages1Action,
  conditions: stages1Conditions,
};

const stages = [
  stages1,
];

const customWorkflowInput: models.CustomWorkflowInput = {
  name: "Progressive rollout starting in two days",
  description: "Turn flag on for 10% of customers each day",
  stages: stages,
};

apiCaller.postWorkflow(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  customWorkflowInput,
  undefined, // templateKey
  undefined, // dryRun
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowsApi#postWorkflow:");
  console.log(error.body);
});
