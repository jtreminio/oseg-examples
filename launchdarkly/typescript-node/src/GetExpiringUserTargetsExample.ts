import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExpiringUserTargets(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlags#getExpiringUserTargets:");
  console.log(error.body);
});
