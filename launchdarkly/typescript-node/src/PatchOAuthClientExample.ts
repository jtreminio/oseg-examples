import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OAuth2ClientsApi();
apiCaller.setApiKey(api.OAuth2ClientsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/name";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchOAuthClient(
  undefined, // clientId
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling OAuth2Clients#patchOAuthClient:");
  console.log(error.body);
});
