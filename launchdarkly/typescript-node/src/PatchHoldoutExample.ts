import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const holdoutPatchInput = new models.HoldoutPatchInput();
holdoutPatchInput.instructions =   [
  {
    "kind": "updateName",
    "value": "Updated holdout name"
  }
];
holdoutPatchInput.comment = "Optional comment describing the update";

apiCaller.patchHoldout(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // holdoutKey
  holdoutPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBeta#patchHoldout:");
  console.log(error.body);
});
