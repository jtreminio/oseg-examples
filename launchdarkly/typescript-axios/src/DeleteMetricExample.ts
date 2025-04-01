import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.MetricsApi(configuration).deleteMetric(
  "projectKey_string", // projectKey
  "metricKey_string", // metricKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsApi#deleteMetric:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
