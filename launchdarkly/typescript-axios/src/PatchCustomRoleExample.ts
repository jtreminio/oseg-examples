import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patch1: api.PatchOperation = {
  op: "add",
  path: "/policy/0",
};

const patch = [
  patch1,
];

const patchWithComment: api.PatchWithComment = {
  patch: patch,
};

new api.CustomRolesApi(configuration).patchCustomRole(
  "customRoleKey_string", // customRoleKey
  patchWithComment,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CustomRolesApi#patchCustomRole:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
