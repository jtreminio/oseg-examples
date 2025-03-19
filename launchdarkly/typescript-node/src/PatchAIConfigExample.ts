import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const aIConfigPatch: models.AIConfigPatch = {
  description: "description",
  name: "name",
  tags: [
    "tags",
    "tags",
  ],
};

apiCaller.patchAIConfig(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  aIConfigPatch,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#patchAIConfig:");
  console.log(error.body);
});
