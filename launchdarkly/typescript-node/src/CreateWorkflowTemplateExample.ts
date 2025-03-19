import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowTemplatesApi();
apiCaller.setApiKey(api.WorkflowTemplatesApiApiKeys.ApiKey, "YOUR_API_KEY");

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
  executeConditionsInSequence: true,
  action: stages1Action,
  conditions: stages1Conditions,
};

const stages = [
  stages1,
];

const createWorkflowTemplateInput: models.CreateWorkflowTemplateInput = {
  key: "key_string",
  stages: stages,
};

apiCaller.createWorkflowTemplate(
  createWorkflowTemplateInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowTemplatesApi#createWorkflowTemplate:");
  console.log(error.body);
});
