import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CustomRolesApi();
apiCaller.setApiKey(api.CustomRolesApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1 = new models.PatchOperation();
patch1.op = "add";
patch1.path = "/policy/0";

const patch = [
  patch1,
];

const patchWithComment = new models.PatchWithComment();
patchWithComment.patch = patch;

apiCaller.patchCustomRole(
  undefined, // customRoleKey
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomRoles#patchCustomRole:");
  console.log(error.body);
});
