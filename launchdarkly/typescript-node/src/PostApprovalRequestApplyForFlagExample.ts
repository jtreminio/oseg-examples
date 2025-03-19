import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const postApprovalRequestApplyRequest: models.PostApprovalRequestApplyRequest = {
  comment: "Looks good, thanks for updating",
};

apiCaller.postApprovalRequestApplyForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  postApprovalRequestApplyRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestApplyForFlag:");
  console.log(error.body);
});
