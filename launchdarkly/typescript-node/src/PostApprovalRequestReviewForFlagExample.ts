import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const postApprovalRequestReviewRequest: models.PostApprovalRequestReviewRequest = {
  kind: models.PostApprovalRequestReviewRequest.KindEnum.Approve,
  comment: "Looks good, thanks for updating",
};

apiCaller.postApprovalRequestReviewForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  postApprovalRequestReviewRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestReviewForFlag:");
  console.log(error.body);
});
