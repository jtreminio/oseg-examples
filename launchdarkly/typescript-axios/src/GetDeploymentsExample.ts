import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsDeploymentsBetaApi(configuration).getDeployments(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
  undefined, // limit
  undefined, // expand
  undefined, // from
  undefined, // to
  undefined, // after
  undefined, // before
  undefined, // kind
  undefined, // status
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#getDeployments:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
