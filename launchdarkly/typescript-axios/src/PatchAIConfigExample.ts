import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const aIConfigPatch: api.AIConfigPatch = {
  description: "description",
  name: "name",
  tags: [
    "tags",
    "tags",
  ],
};

new api.AIConfigsBetaApi(configuration).patchAIConfig(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  aIConfigPatch,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#patchAIConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
