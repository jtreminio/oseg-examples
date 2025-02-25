import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/name";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchMetricGroup(
  undefined, // projectKey
  undefined, // metricGroupKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBeta#patchMetricGroup:");
  console.log(error.body);
});
