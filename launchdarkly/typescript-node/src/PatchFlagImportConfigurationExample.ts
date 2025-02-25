import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagImportConfigurationsBetaApi();
apiCaller.setApiKey(api.FlagImportConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/exampleField";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchFlagImportConfiguration(
  undefined, // projectKey
  undefined, // integrationKey
  undefined, // integrationId
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagImportConfigurationsBeta#patchFlagImportConfiguration:");
  console.log(error.body);
});
