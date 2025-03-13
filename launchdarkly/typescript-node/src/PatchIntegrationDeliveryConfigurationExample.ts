import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationDeliveryConfigurationsBetaApi();
apiCaller.setApiKey(api.IntegrationDeliveryConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/on";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchIntegrationDeliveryConfiguration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationDeliveryConfigurationsBetaApi#patchIntegrationDeliveryConfiguration:");
  console.log(error.body);
});
