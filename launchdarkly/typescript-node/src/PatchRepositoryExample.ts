import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/defaultBranch";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchRepository(
  undefined, // repo
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CodeReferencesApi#patchRepository:");
  console.log(error.body);
});
