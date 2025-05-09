import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteAIConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "configKey_string", // configKey
).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#deleteAIConfig:");
  console.log(error.body);
});
