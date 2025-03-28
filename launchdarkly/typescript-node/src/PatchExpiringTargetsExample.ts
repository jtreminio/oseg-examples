import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchFlagsRequest: models.PatchFlagsRequest = {
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

apiCaller.patchExpiringTargets(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  patchFlagsRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#patchExpiringTargets:");
  console.log(error.body);
});
