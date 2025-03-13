import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getCustomWorkflow(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "workflowId_string", // workflowId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowsApi#getCustomWorkflow:");
  console.log(error.body);
});
