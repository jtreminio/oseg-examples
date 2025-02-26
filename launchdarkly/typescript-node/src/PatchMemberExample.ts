import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "add";
patchOperation1.path = "/role";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchMember(
  undefined, // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembersApi#patchMember:");
  console.log(error.body);
});
