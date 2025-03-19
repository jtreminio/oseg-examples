import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const source: models.SourceFlag = {
  key: "environment-key-123abc",
  version: 1,
};

const createCopyFlagConfigApprovalRequestRequest: models.CreateCopyFlagConfigApprovalRequestRequest = {
  description: "copy flag settings to another environment",
  comment: "optional comment",
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
  includedActions: [
    models.CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum.UpdateOn,
  ],
  excludedActions: [
    models.CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum.UpdateOn,
  ],
  source: source,
};

apiCaller.postFlagCopyConfigApprovalRequest(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  createCopyFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postFlagCopyConfigApprovalRequest:");
  console.log(error.body);
});
