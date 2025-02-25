import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CustomRolesApi();
apiCaller.setApiKey(api.CustomRolesApiApiKeys.ApiKey, "YOUR_API_KEY");

const policy1 = new models.StatementPost();
policy1.effect = models.StatementPost.EffectEnum.Allow;
policy1.resources = [
  "proj/*:env/production:flag/*",
];
policy1.actions = [
  "updateOn",
];

const policy = [
  policy1,
];

const customRolePost = new models.CustomRolePost();
customRolePost.name = "Ops team";
customRolePost.key = "role-key-123abc";
customRolePost.description = "An example role for members of the ops team";
customRolePost.basePermissions = "reader";
customRolePost.policy = policy;

apiCaller.postCustomRole(
  customRolePost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomRoles#postCustomRole:");
  console.log(error.body);
});
