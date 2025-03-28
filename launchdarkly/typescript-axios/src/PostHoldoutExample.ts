import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const metrics1: api.MetricInput = {
  key: "metric-key-123abc",
  isGroup: true,
  primary: true,
};

const metrics = [
  metrics1,
];

const holdoutPostRequest: api.HoldoutPostRequest = {
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

new api.HoldoutsBetaApi(configuration).postHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  holdoutPostRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HoldoutsBetaApi#postHoldout:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
