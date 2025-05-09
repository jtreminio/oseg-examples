import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AIConfigsBetaApi(configuration).getAIConfigMetricsByVariation(
  "beta", // lDAPIVersion
  "projectKey_string", // projectKey
  "configKey_string", // configKey
  123, // from
  456, // to
  "env_string", // env
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AIConfigsBetaApi#getAIConfigMetricsByVariation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
