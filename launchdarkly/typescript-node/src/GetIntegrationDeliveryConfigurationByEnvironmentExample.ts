import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getIntegrationDeliveryConfigurationByEnvironment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#getIntegrationDeliveryConfigurationByEnvironment:");
  console.log(error.body);
});
