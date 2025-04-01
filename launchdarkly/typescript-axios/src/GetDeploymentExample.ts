import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsDeploymentsBetaApi(configuration).getDeployment(
  "deploymentID_string", // deploymentID
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#getDeployment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
