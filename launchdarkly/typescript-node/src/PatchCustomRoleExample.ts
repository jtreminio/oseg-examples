import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CustomRolesApi();
apiCaller.setApiKey(api.CustomRolesApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1: models.PatchOperation = {
  op: "add",
  path: "/policy/0",
};

const patch = [
  patch1,
];

const patchWithComment: models.PatchWithComment = {
  patch: patch,
};

apiCaller.patchCustomRole(
  "customRoleKey_string", // customRoleKey
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomRolesApi#patchCustomRole:");
  console.log(error.body);
});
