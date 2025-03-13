import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const holdoutPatchInput = new models.HoldoutPatchInput();
holdoutPatchInput.instructions = [
  {
    "kind": "updateName",
    "value": "Updated holdout name"
  }
];
holdoutPatchInput.comment = "Optional comment describing the update";

apiCaller.patchHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutKey_string", // holdoutKey
  holdoutPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBetaApi#patchHoldout:");
  console.log(error.body);
});
