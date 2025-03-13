import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsBetaApi();
apiCaller.setApiKey(api.ApprovalsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.patchFlagConfigApprovalRequest(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsBetaApi#patchFlagConfigApprovalRequest:");
  console.log(error.body);
});
