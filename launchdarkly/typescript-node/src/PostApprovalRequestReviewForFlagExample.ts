import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const postApprovalRequestReviewRequest = new models.PostApprovalRequestReviewRequest();
postApprovalRequestReviewRequest.kind = models.PostApprovalRequestReviewRequest.KindEnum.Approve;
postApprovalRequestReviewRequest.comment = "Looks good, thanks for updating";

apiCaller.postApprovalRequestReviewForFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // id
  postApprovalRequestReviewRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestReviewForFlag:");
  console.log(error.body);
});
