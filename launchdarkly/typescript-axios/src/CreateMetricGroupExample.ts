import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const metrics1: api.MetricInMetricGroupInput = {
  key: "metric-key-123abc",
  nameInGroup: "Step 1",
};

const metrics = [
  metrics1,
];

const metricGroupPost: api.MetricGroupPost = {
  key: "metric-group-key-123abc",
  name: "My metric group",
  kind: api.MetricGroupPostKindEnum.Funnel,
  maintainerId: "569fdeadbeef1644facecafe",
  tags: [
    "ops",
  ],
  description: "Description of the metric group",
  metrics: metrics,
};

new api.MetricsBetaApi(configuration).createMetricGroup(
  "projectKey_string", // projectKey
  metricGroupPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsBetaApi#createMetricGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
