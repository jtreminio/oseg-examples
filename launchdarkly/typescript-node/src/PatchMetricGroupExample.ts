import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/name",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchMetricGroup(
  "projectKey_string", // projectKey
  "metricGroupKey_string", // metricGroupKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBetaApi#patchMetricGroup:");
  console.log(error.body);
});
