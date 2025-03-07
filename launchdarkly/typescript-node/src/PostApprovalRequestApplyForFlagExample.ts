import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const postApprovalRequestApplyRequest = new models.PostApprovalRequestApplyRequest();
postApprovalRequestApplyRequest.comment = "Looks good, thanks for updating";

apiCaller.postApprovalRequestApplyForFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // id
  postApprovalRequestApplyRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestApplyForFlag:");
  console.log(error.body);
});
