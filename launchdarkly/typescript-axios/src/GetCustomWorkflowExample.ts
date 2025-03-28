import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.WorkflowsApi(configuration).getCustomWorkflow(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "workflowId_string", // workflowId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WorkflowsApi#getCustomWorkflow:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
