import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagLinksBetaApi();
apiCaller.setApiKey(api.FlagLinksBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/title",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.updateFlagLink(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagLinksBetaApi#updateFlagLink:");
  console.log(error.body);
});
