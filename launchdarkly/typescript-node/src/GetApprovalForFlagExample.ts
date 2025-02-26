import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getApprovalForFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#getApprovalForFlag:");
  console.log(error.body);
});
