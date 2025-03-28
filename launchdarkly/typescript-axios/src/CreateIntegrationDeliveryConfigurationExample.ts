import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const integrationDeliveryConfigurationPost: api.IntegrationDeliveryConfigurationPost = {
  config: {
    "optional": "example value for optional formVariables property for sample-integration",
    "required": "example value for required formVariables property for sample-integration"
  },
  on: false,
  name: "Sample integration",
  tags: [
    "example-tag",
  ],
};

new api.IntegrationDeliveryConfigurationsBetaApi(configuration).createIntegrationDeliveryConfiguration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  integrationDeliveryConfigurationPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#createIntegrationDeliveryConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
