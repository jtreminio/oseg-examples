import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.IntegrationsBetaApi(configuration).deleteIntegrationConfiguration(
  "integrationConfigurationId_string", // integrationConfigurationId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationsBetaApi#deleteIntegrationConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
