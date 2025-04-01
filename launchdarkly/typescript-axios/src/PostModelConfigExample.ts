import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const modelConfigPost: api.ModelConfigPost = {
  id: "id",
  key: "key",
  name: "name",
  icon: "icon",
  provider: "provider",
  tags: [
    "tags",
    "tags",
  ],
  params: {},
  customParams: {},
};

new api.AIConfigsBetaApi(configuration).postModelConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  modelConfigPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#postModelConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
