import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const integrationDeliveryConfigurationPost = new models.IntegrationDeliveryConfigurationPost();
integrationDeliveryConfigurationPost.config = {
  "optional": "example value for optional formVariables property for sample-integration",
  "required": "example value for required formVariables property for sample-integration"
};
integrationDeliveryConfigurationPost.on = false;
integrationDeliveryConfigurationPost.name = "Sample integration";
integrationDeliveryConfigurationPost.tags = [
  "example-tag",
];

apiCaller.createIntegrationDeliveryConfiguration(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // integrationKey
  integrationDeliveryConfigurationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#createIntegrationDeliveryConfiguration:");
  console.log(error.body);
});
