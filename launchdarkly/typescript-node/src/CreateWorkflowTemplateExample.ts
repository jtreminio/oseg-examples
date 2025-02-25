import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowTemplatesApi();
apiCaller.setApiKey(api.WorkflowTemplatesApiApiKeys.ApiKey, "YOUR_API_KEY");

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
stages1.executeConditionsInSequence = true;
stages1.action = stages1Action;
stages1.conditions = stages1Conditions;

const stages = [
  stages1,
];

const createWorkflowTemplateInput = new models.CreateWorkflowTemplateInput();
createWorkflowTemplateInput.key = undefined;
createWorkflowTemplateInput.name = undefined;
createWorkflowTemplateInput.description = undefined;
createWorkflowTemplateInput.workflowId = undefined;
createWorkflowTemplateInput.projectKey = undefined;
createWorkflowTemplateInput.environmentKey = undefined;
createWorkflowTemplateInput.flagKey = undefined;
createWorkflowTemplateInput.stages = stages;

apiCaller.createWorkflowTemplate(
  createWorkflowTemplateInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowTemplates#createWorkflowTemplate:");
  console.log(error.body);
});
