import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteWorkflow(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // workflowId
).catch(error => {
  console.log("Exception when calling Workflows#deleteWorkflow:");
  console.log(error.body);
});
