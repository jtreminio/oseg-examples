import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteAIConfigVariation(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  "variationKey_string", // variationKey
).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#deleteAIConfigVariation:");
  console.log(error.body);
});
