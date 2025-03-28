import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const stages1Action: api.ActionInput = {
};

const stages1Conditions1: api.ConditionInput = {
  scheduleKind: "relative",
  waitDuration: 2,
  waitDurationUnit: "calendarDay",
  kind: "schedule",
};

const stages1Conditions = [
  stages1Conditions1,
];

const stages1: api.StageInput = {
  name: "10% rollout on day 1",
  action: stages1Action,
  conditions: stages1Conditions,
};

const stages = [
  stages1,
];

const customWorkflowInput: api.CustomWorkflowInput = {
  name: "Progressive rollout starting in two days",
  description: "Turn flag on for 10% of customers each day",
  stages: stages,
};

new api.WorkflowsApi(configuration).postWorkflow(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  customWorkflowInput,
  undefined, // templateKey
  undefined, // dryRun
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WorkflowsApi#postWorkflow:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
