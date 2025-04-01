import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/config/topic",
};

const patchOperation = [
  patchOperation1,
];

new api.DataExportDestinationsApi(configuration).patchDestination(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling DataExportDestinationsApi#patchDestination:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
