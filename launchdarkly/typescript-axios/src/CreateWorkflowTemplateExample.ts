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
  executeConditionsInSequence: true,
  action: stages1Action,
  conditions: stages1Conditions,
};

const stages = [
  stages1,
];

const createWorkflowTemplateInput: api.CreateWorkflowTemplateInput = {
  key: "key_string",
  stages: stages,
};

new api.WorkflowTemplatesApi(configuration).createWorkflowTemplate(
  createWorkflowTemplateInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WorkflowTemplatesApi#createWorkflowTemplate:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
