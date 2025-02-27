import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationsBetaApi();
apiCaller.setApiKey(api.IntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/on";

const patchOperation = [
  patchOperation1,
];

apiCaller.updateIntegrationConfiguration(
  undefined, // integrationConfigurationId
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationsBetaApi#updateIntegrationConfiguration:");
  console.log(error.body);
});
