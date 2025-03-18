import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteWorkflow(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "workflowId_string", // workflowId
).catch(error => {
  console.log("Exception when calling WorkflowsApi#deleteWorkflow:");
  console.log(error.body);
});
