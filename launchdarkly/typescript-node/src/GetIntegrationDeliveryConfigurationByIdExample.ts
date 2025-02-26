import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getIntegrationDeliveryConfigurationById(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // integrationKey
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#getIntegrationDeliveryConfigurationById:");
  console.log(error.body);
});
