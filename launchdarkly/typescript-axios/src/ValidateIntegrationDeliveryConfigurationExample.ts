import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.IntegrationDeliveryConfigurationsBetaApi(configuration).validateIntegrationDeliveryConfiguration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "id_string", // id
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#validateIntegrationDeliveryConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
