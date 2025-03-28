import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const postApprovalRequestApplyRequest: api.PostApprovalRequestApplyRequest = {
  comment: "Looks good, thanks for updating",
};

new api.ApprovalsApi(configuration).postApprovalRequestApply(
  "id_string", // id
  postApprovalRequestApplyRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestApply:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
