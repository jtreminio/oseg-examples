import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const messages1: api.Message = {
  content: "content",
  role: "role",
};

const messages2: api.Message = {
  content: "content",
  role: "role",
};

const messages = [
  messages1,
  messages2,
];

const aIConfigVariationPatch: api.AIConfigVariationPatch = {
  modelConfigKey: "modelConfigKey",
  name: "name",
  published: true,
  model: {},
  messages: messages,
};

new api.AIConfigsBetaApi(configuration).patchAIConfigVariation(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  "variationKey_string", // variationKey
  aIConfigVariationPatch,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#patchAIConfigVariation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
