import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const holdoutPatchInput: api.HoldoutPatchInput = {
  instructions: [
    {
      "kind": "updateName",
      "value": "Updated holdout name"
    }
  ],
  comment: "Optional comment describing the update",
};

new api.HoldoutsBetaApi(configuration).patchHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutKey_string", // holdoutKey
  holdoutPatchInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HoldoutsBetaApi#patchHoldout:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
