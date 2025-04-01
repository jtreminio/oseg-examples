import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).getAIConfig(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#getAIConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
