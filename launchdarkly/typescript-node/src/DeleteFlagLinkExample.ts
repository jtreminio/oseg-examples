import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagLinksBetaApi();
apiCaller.setApiKey(api.FlagLinksBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFlagLink(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
).catch(error => {
  console.log("Exception when calling FlagLinksBetaApi#deleteFlagLink:");
  console.log(error.body);
});
