import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.MetricsApi(configuration).getMetric(
  "projectKey_string", // projectKey
  "metricKey_string", // metricKey
  undefined, // expand
  undefined, // versionId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsApi#getMetric:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
