import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#deleteFeatureFlag:");
  console.log(error.body);
});
