import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const metrics1: models.MetricInMetricGroupInput = {
  key: "metric-key-123abc",
  nameInGroup: "Step 1",
};

const metrics = [
  metrics1,
];

const metricGroupPost: models.MetricGroupPost = {
  key: "metric-group-key-123abc",
  name: "My metric group",
  kind: models.MetricGroupPost.KindEnum.Funnel,
  maintainerId: "569fdeadbeef1644facecafe",
  tags: [
    "ops",
  ],
  description: "Description of the metric group",
  metrics: metrics,
};

apiCaller.createMetricGroup(
  "projectKey_string", // projectKey
  metricGroupPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBetaApi#createMetricGroup:");
  console.log(error.body);
});
