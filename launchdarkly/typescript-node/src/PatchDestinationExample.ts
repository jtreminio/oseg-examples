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
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinations#patchDestination:");
  console.log(error.body);
});
