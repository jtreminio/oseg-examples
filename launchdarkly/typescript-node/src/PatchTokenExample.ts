import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccessTokensApi();
apiCaller.setApiKey(api.AccessTokensApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/role",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchToken(
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccessTokensApi#patchToken:");
  console.log(error.body);
});
