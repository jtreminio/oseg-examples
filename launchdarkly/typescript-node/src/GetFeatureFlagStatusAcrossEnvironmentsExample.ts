import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFeatureFlagStatusAcrossEnvironments(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // env
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlags#getFeatureFlagStatusAcrossEnvironments:");
  console.log(error.body);
});
