import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsBetaApi();
apiCaller.setApiKey(api.ApprovalsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.patchApprovalRequest(
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsBetaApi#patchApprovalRequest:");
  console.log(error.body);
});
