import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteIntegrationDeliveryConfiguration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "id_string", // id
).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#deleteIntegrationDeliveryConfiguration:");
  console.log(error.body);
});
