import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/config/topic";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchDestination(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinationsApi#patchDestination:");
  console.log(error.body);
});
