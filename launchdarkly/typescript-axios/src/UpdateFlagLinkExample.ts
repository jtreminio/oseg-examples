import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/title",
};

const patchOperation = [
  patchOperation1,
];

new api.FlagLinksBetaApi(configuration).updateFlagLink(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagLinksBetaApi#updateFlagLink:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
