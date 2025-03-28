import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchFlagsRequest: api.PatchFlagsRequest = {
  instructions: [
    {
      "kind": "addExpireUserTargetDate",
      "userKey": "sandy",
      "value": 1686412800000,
      "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
    }
  ],
  comment: "optional comment",
};

new api.FeatureFlagsApi(configuration).patchExpiringTargets(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  patchFlagsRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#patchExpiringTargets:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
