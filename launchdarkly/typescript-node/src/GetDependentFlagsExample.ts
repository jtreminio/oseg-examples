import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsBetaApi();
apiCaller.setApiKey(api.FeatureFlagsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDependentFlags(
  undefined, // projectKey
  undefined, // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsBetaApi#getDependentFlags:");
  console.log(error.body);
});
