import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteModelConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "modelConfigKey_string", // modelConfigKey
).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#deleteModelConfig:");
  console.log(error.body);
});
