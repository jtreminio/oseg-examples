import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.RelayProxyConfigurationsApi();
apiCaller.setApiKey(api.RelayProxyConfigurationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1 = new models.PatchOperation();
patch1.op = "replace";
patch1.path = "/policy/0";

const patch = [
  patch1,
];

const patchWithComment = new models.PatchWithComment();
patchWithComment.patch = patch;

apiCaller.patchRelayAutoConfig(
  undefined, // id
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling RelayProxyConfigurationsApi#patchRelayAutoConfig:");
  console.log(error.body);
});
