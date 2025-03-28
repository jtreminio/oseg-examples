import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const createApprovalRequestRequest: api.CreateApprovalRequestRequest = {
  resourceId: "proj/projKey:env/envKey:flag/flagKey",
  description: "Requesting to update targeting",
  instructions: [],
  comment: "optional comment",
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
};

new api.ApprovalsApi(configuration).postApprovalRequest(
  createApprovalRequestRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequest:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
