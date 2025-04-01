import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).getModelConfig(
  "beta", // lDAPIVersion
  "default", // projectKey
  "default", // modelConfigKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#getModelConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
