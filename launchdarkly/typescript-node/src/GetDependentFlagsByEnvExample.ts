import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsBetaApi();
apiCaller.setApiKey(api.FeatureFlagsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDependentFlagsByEnv(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsBetaApi#getDependentFlagsByEnv:");
  console.log(error.body);
});
