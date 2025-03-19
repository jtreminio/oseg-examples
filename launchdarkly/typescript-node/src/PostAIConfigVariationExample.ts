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

const aIConfigVariationPost: models.AIConfigVariationPost = {
  key: "key",
  name: "name",
  model: {},
  modelConfigKey: "modelConfigKey",
  messages: messages,
};

apiCaller.postAIConfigVariation(
  models.AIConfigVariationPost.LDAPIVersionEnum.Beta, // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  aIConfigVariationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#postAIConfigVariation:");
  console.log(error.body);
});
