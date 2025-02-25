import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowsApi();
apiCaller.setApiKey(api.WorkflowsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getCustomWorkflow(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // workflowId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Workflows#getCustomWorkflow:");
  console.log(error.body);
});
