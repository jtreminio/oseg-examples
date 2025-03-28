import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/exampleField",
};

const patchOperation = [
  patchOperation1,
];

new api.PersistentStoreIntegrationsBetaApi(configuration).patchBigSegmentStoreIntegration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#patchBigSegmentStoreIntegration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
