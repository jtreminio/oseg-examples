import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApplicationsBetaApi();
apiCaller.setApiKey(api.ApplicationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/description",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchApplication(
  "applicationKey_string", // applicationKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApplicationsBetaApi#patchApplication:");
  console.log(error.body);
});
