import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const postApprovalRequestReviewRequest: api.PostApprovalRequestReviewRequest = {
  kind: api.PostApprovalRequestReviewRequestKindEnum.Approve,
  comment: "Looks good, thanks for updating",
};

new api.ApprovalsApi(configuration).postApprovalRequestReviewForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  postApprovalRequestReviewRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestReviewForFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
