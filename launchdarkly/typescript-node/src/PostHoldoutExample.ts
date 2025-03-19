import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const metrics1: models.MetricInput = {
  key: "metric-key-123abc",
  isGroup: true,
  primary: true,
};

const metrics = [
  metrics1,
];

const holdoutPostRequest: models.HoldoutPostRequest = {
  name: "holdout-one-name",
  key: "holdout-key",
  description: "My holdout-one description",
  randomizationunit: "user",
  holdoutamount: "10",
  primarymetrickey: "metric-key-123abc",
  prerequisiteflagkey: "flag-key-123abc",
  attributes: [
    "country",
    "device",
    "os",
  ],
  metrics: metrics,
};

apiCaller.postHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  holdoutPostRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBetaApi#postHoldout:");
  console.log(error.body);
});
