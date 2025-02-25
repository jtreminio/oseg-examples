import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const metrics1 = new models.MetricInMetricGroupInput();
metrics1.key = "metric-key-123abc";
metrics1.nameInGroup = "Step 1";

const metrics = [
  metrics1,
];

const metricGroupPost = new models.MetricGroupPost();
metricGroupPost.key = "metric-group-key-123abc";
metricGroupPost.name = "My metric group";
metricGroupPost.kind = models.MetricGroupPost.KindEnum.Funnel;
metricGroupPost.maintainerId = "569fdeadbeef1644facecafe";
metricGroupPost.tags = [
  "ops",
];
metricGroupPost.description = "Description of the metric group";
metricGroupPost.metrics = metrics;

apiCaller.createMetricGroup(
  undefined, // projectKey
  metricGroupPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBeta#createMetricGroup:");
  console.log(error.body);
});
