import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getApprovalRequests().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Approvals#getApprovalRequests:");
  console.log(error.body);
});
