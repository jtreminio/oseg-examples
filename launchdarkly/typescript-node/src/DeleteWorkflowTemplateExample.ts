import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowTemplatesApi();
apiCaller.setApiKey(api.WorkflowTemplatesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteWorkflowTemplate(
  "templateKey_string", // templateKey
).catch(error => {
  console.log("Exception when calling WorkflowTemplatesApi#deleteWorkflowTemplate:");
  console.log(error.body);
});
