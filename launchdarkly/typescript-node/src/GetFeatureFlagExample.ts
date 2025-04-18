import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  undefined, // env
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#getFeatureFlag:");
  console.log(error.body);
});
