import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const aIConfigPatch = new models.AIConfigPatch();
aIConfigPatch.description = "description";
aIConfigPatch.name = "name";
aIConfigPatch.tags = [
  "tags",
  "tags",
];

apiCaller.patchAIConfig(
  undefined, // lDAPIVersion
  undefined, // projectKey
  undefined, // configKey
  aIConfigPatch,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBeta#patchAIConfig:");
  console.log(error.body);
});
