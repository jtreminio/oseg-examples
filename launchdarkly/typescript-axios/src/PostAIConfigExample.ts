import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const aIConfigPost: api.AIConfigPost = {
  key: "key",
  name: "name",
  description: "",
  tags: [
    "tags",
    "tags",
  ],
};

new api.AIConfigsBetaApi(configuration).postAIConfig(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  aIConfigPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#postAIConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
