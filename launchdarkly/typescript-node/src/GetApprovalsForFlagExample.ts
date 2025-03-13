import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getApprovalsForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#getApprovalsForFlag:");
  console.log(error.body);
});
