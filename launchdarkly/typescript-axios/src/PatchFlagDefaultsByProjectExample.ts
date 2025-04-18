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

new api.ProjectsApi(configuration).patchFlagDefaultsByProject(
  "projectKey_string", // projectKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#patchFlagDefaultsByProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
