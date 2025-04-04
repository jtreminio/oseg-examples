import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.PersistentStoreIntegrationsBetaApi();
apiCaller.setApiKey(api.PersistentStoreIntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const integrationDeliveryConfigurationPost: models.IntegrationDeliveryConfigurationPost = {
  config: {
    "optional": "example value for optional formVariables property for sample-integration",
    "required": "example value for required formVariables property for sample-integration"
  },
  on: false,
  name: "Example persistent store integration",
  tags: [
    "example-tag",
  ],
};

apiCaller.createBigSegmentStoreIntegration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  integrationDeliveryConfigurationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#createBigSegmentStoreIntegration:");
  console.log(error.body);
});
