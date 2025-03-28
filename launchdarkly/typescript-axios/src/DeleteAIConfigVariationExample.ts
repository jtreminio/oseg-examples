import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).deleteAIConfigVariation(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  "variationKey_string", // variationKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#deleteAIConfigVariation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
