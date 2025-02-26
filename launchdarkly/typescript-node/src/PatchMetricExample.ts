import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsApi();
apiCaller.setApiKey(api.MetricsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/name";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchMetric(
  undefined, // projectKey
  undefined, // metricKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsApi#patchMetric:");
  console.log(error.body);
});
