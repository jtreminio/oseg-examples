import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteIntegrationDeliveryConfiguration(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // integrationKey
  undefined, // id
).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBeta#deleteIntegrationDeliveryConfiguration:");
  console.log(error.body);
});
