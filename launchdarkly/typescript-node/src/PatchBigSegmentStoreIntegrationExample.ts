import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.PersistentStoreIntegrationsBetaApi();
apiCaller.setApiKey(api.PersistentStoreIntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/exampleField";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchBigSegmentStoreIntegration(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // integrationKey
  undefined, // integrationId
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersistentStoreIntegrationsBeta#patchBigSegmentStoreIntegration:");
  console.log(error.body);
});
