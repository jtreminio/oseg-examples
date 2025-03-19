import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsApi();
apiCaller.setApiKey(api.MetricsApiApiKeys.ApiKey, "YOUR_API_KEY");

const metricPost: models.MetricPost = {
  key: "metric-key-123abc",
  kind: models.MetricPost.KindEnum.Custom,
  isActive: true,
  isNumeric: false,
  eventKey: "trackedClick",
};

apiCaller.postMetric(
  "projectKey_string", // projectKey
  metricPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsApi#postMetric:");
  console.log(error.body);
});
