import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CustomRolesApi();
apiCaller.setApiKey(api.CustomRolesApiApiKeys.ApiKey, "YOUR_API_KEY");

const policy1: models.StatementPost = {
  effect: models.StatementPost.EffectEnum.Allow,
  resources: [
    "proj/*:env/production:flag/*",
  ],
  actions: [
    "updateOn",
  ],
};

const policy = [
  policy1,
];

const customRolePost: models.CustomRolePost = {
  name: "Ops team",
  key: "role-key-123abc",
  description: "An example role for members of the ops team",
  basePermissions: "reader",
  policy: policy,
};

apiCaller.postCustomRole(
  customRolePost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomRolesApi#postCustomRole:");
  console.log(error.body);
});
