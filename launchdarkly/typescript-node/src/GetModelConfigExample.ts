import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getModelConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "default", // modelConfigKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#getModelConfig:");
  console.log(error.body);
});
