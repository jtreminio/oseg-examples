import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/phases/0/complete";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchReleaseByFlagKey(
  undefined, // projectKey
  undefined, // flagKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBeta#patchReleaseByFlagKey:");
  console.log(error.body);
});
