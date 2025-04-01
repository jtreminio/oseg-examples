import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).deleteModelConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "modelConfigKey_string", // modelConfigKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#deleteModelConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
