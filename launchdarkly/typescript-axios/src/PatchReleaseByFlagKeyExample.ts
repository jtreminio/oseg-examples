import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/phases/0/complete",
};

const patchOperation = [
  patchOperation1,
];

new api.ReleasesBetaApi(configuration).patchReleaseByFlagKey(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasesBetaApi#patchReleaseByFlagKey:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
