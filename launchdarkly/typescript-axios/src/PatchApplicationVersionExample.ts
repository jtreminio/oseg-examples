import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/supported",
};

const patchOperation = [
  patchOperation1,
];

new api.ApplicationsBetaApi(configuration).patchApplicationVersion(
  "applicationKey_string", // applicationKey
  "versionKey_string", // versionKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#patchApplicationVersion:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
