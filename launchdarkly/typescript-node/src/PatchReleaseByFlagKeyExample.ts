import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/phases/0/complete",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchReleaseByFlagKey(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBetaApi#patchReleaseByFlagKey:");
  console.log(error.body);
});
