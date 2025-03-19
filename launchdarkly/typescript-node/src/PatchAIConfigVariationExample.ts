import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const messages1: models.Message = {
  content: "content",
  role: "role",
};

const messages2: models.Message = {
  content: "content",
  role: "role",
};

const messages = [
  messages1,
  messages2,
];

const aIConfigVariationPatch: models.AIConfigVariationPatch = {
  modelConfigKey: "modelConfigKey",
  name: "name",
  published: true,
  model: {},
  messages: messages,
};

apiCaller.patchAIConfigVariation(
  models.AIConfigVariationPatch.LDAPIVersionEnum.Beta, // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  "variationKey_string", // variationKey
  aIConfigVariationPatch,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#patchAIConfigVariation:");
  console.log(error.body);
});
