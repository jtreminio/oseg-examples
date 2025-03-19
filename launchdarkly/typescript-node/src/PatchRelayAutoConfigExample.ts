import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.RelayProxyConfigurationsApi();
apiCaller.setApiKey(api.RelayProxyConfigurationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1: models.PatchOperation = {
  op: "replace",
  path: "/policy/0",
};

const patch = [
  patch1,
];

const patchWithComment: models.PatchWithComment = {
  patch: patch,
};

apiCaller.patchRelayAutoConfig(
  "id_string", // id
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling RelayProxyConfigurationsApi#patchRelayAutoConfig:");
  console.log(error.body);
});
