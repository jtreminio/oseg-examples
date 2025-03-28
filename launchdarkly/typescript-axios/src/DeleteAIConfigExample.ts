import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).deleteAIConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "configKey_string", // configKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#deleteAIConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
