import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const source: api.SourceFlag = {
  key: "environment-key-123abc",
  version: 1,
};

const createCopyFlagConfigApprovalRequestRequest: api.CreateCopyFlagConfigApprovalRequestRequest = {
  description: "copy flag settings to another environment",
  comment: "optional comment",
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
  includedActions: [
    api.CreateCopyFlagConfigApprovalRequestRequestIncludedActionsEnum.UpdateOn,
  ],
  excludedActions: [
    api.CreateCopyFlagConfigApprovalRequestRequestExcludedActionsEnum.UpdateOn,
  ],
  source: source,
};

new api.ApprovalsApi(configuration).postFlagCopyConfigApprovalRequest(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  createCopyFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#postFlagCopyConfigApprovalRequest:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
