import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.MetricsBetaApi(configuration).deleteMetricGroup(
  "projectKey_string", // projectKey
  "metricGroupKey_string", // metricGroupKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsBetaApi#deleteMetricGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
