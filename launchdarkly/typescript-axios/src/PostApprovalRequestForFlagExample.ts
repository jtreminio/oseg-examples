import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const createFlagConfigApprovalRequestRequest: api.CreateFlagConfigApprovalRequestRequest = {
  description: "Requesting to update targeting",
  instructions: [],
  comment: "optional comment",
  executionDate: 1706701522000,
  operatingOnId: "6297ed79dee7dc14e1f9a80c",
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
};

new api.ApprovalsApi(configuration).postApprovalRequestForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  createFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestForFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
