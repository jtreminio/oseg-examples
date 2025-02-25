import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFeatureFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
).catch(error => {
  console.log("Exception when calling FeatureFlags#deleteFeatureFlag:");
  console.log(error.body);
});
