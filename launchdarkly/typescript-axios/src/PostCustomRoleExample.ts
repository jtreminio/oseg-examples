import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const policy1: api.StatementPost = {
  effect: api.StatementPostEffectEnum.Allow,
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

const customRolePost: api.CustomRolePost = {
  name: "Ops team",
  key: "role-key-123abc",
  description: "An example role for members of the ops team",
  basePermissions: "reader",
  policy: policy,
};

new api.CustomRolesApi(configuration).postCustomRole(
  customRolePost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CustomRolesApi#postCustomRole:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
