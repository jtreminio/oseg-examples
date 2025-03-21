import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagImportConfigurationsBetaApi();
apiCaller.setApiKey(api.FlagImportConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/exampleField",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchFlagImportConfiguration(
  "projectKey_string", // projectKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagImportConfigurationsBetaApi#patchFlagImportConfiguration:");
  console.log(error.body);
});
