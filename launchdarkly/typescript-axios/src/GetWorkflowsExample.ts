import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.WorkflowsApi(configuration).getWorkflows(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  undefined, // status
  undefined, // sort
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WorkflowsApi#getWorkflows:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
