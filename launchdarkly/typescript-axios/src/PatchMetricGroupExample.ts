import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/name",
};

const patchOperation = [
  patchOperation1,
];

new api.MetricsBetaApi(configuration).patchMetricGroup(
  "projectKey_string", // projectKey
  "metricGroupKey_string", // metricGroupKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsBetaApi#patchMetricGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
