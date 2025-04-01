import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patch1: api.PatchOperation = {
  op: "replace",
  path: "/description",
};

const patch = [
  patch1,
];

const patchWithComment: api.PatchWithComment = {
  patch: patch,
};

new api.FeatureFlagsApi(configuration).patchFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  patchWithComment,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#patchFeatureFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
