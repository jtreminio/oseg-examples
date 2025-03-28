import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.IntegrationDeliveryConfigurationsBetaApi(configuration).deleteIntegrationDeliveryConfiguration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "id_string", // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#deleteIntegrationDeliveryConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
