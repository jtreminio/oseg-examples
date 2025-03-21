import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAIConfigVariation(
  "beta", // lDAPIVersion
  "default", // projectKey
  "default", // configKey
  "default", // variationKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#getAIConfigVariation:");
  console.log(error.body);
});
