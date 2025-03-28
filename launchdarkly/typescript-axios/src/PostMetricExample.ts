import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const metricPost: api.MetricPost = {
  key: "metric-key-123abc",
  kind: api.MetricPostKindEnum.Custom,
  isActive: true,
  isNumeric: false,
  eventKey: "trackedClick",
};

new api.MetricsApi(configuration).postMetric(
  "projectKey_string", // projectKey
  metricPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsApi#postMetric:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
