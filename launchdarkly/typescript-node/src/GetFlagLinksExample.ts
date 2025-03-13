import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagLinksBetaApi();
apiCaller.setApiKey(api.FlagLinksBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFlagLinks(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagLinksBetaApi#getFlagLinks:");
  console.log(error.body);
});
