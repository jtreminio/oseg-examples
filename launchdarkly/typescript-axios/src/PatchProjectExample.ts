import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "add",
  path: "/tags/0",
};

const patchOperation = [
  patchOperation1,
];

new api.ProjectsApi(configuration).patchProject(
  "projectKey_string", // projectKey
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#patchProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
