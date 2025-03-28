import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.IntegrationsBetaApi(configuration).getAllIntegrationConfigurations(
  "integrationKey_string", // integrationKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationsBetaApi#getAllIntegrationConfigurations:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
