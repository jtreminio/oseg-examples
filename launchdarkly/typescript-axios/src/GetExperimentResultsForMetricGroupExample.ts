import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ExperimentsApi(configuration).getExperimentResultsForMetricGroup(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  "metricGroupKey_string", // metricGroupKey
  undefined, // iterationId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#getExperimentResultsForMetricGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
