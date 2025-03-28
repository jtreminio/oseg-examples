import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ExperimentsApi(configuration).getExperimentResults(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  "metricKey_string", // metricKey
  undefined, // iterationId
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#getExperimentResults:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
