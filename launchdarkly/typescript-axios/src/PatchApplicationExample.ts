import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/description",
};

const patchOperation = [
  patchOperation1,
];

new api.ApplicationsBetaApi(configuration).patchApplication(
  "applicationKey_string", // applicationKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#patchApplication:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
