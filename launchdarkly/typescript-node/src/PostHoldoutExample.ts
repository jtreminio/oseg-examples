import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const metrics1 = new models.MetricInput();
metrics1.key = "metric-key-123abc";
metrics1.isGroup = true;
metrics1.primary = true;

const metrics = [
  metrics1,
];

const holdoutPostRequest = new models.HoldoutPostRequest();
holdoutPostRequest.name = "holdout-one-name";
holdoutPostRequest.key = "holdout-key";
holdoutPostRequest.description = "My holdout-one description";
holdoutPostRequest.randomizationunit = "user";
holdoutPostRequest.holdoutamount = "10";
holdoutPostRequest.primarymetrickey = "metric-key-123abc";
holdoutPostRequest.prerequisiteflagkey = "flag-key-123abc";
holdoutPostRequest.maintainerId = undefined;
holdoutPostRequest.attributes = [
  "country",
  "device",
  "os",
];
holdoutPostRequest.metrics = metrics;

apiCaller.postHoldout(
  undefined, // projectKey
  undefined, // environmentKey
  holdoutPostRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBetaApi#postHoldout:");
  console.log(error.body);
});
