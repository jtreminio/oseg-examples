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

const aIConfigVariationPost: api.AIConfigVariationPost = {
  key: "key",
  name: "name",
  model: {},
  modelConfigKey: "modelConfigKey",
  messages: messages,
};

new api.AIConfigsBetaApi(configuration).postAIConfigVariation(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  aIConfigVariationPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#postAIConfigVariation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
