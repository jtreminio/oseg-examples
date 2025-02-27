import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const source = new models.SourceFlag();
source.key = "environment-key-123abc";
source.version = 1;

const createCopyFlagConfigApprovalRequestRequest = new models.CreateCopyFlagConfigApprovalRequestRequest();
createCopyFlagConfigApprovalRequestRequest.description = "copy flag settings to another environment";
createCopyFlagConfigApprovalRequestRequest.comment = "optional comment";
createCopyFlagConfigApprovalRequestRequest.notifyMemberIds = [
  "1234a56b7c89d012345e678f",
];
createCopyFlagConfigApprovalRequestRequest.notifyTeamKeys = [
  "example-reviewer-team",
];
createCopyFlagConfigApprovalRequestRequest.includedActions = [
  models.CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum.UpdateOn,
];
createCopyFlagConfigApprovalRequestRequest.excludedActions = [
  models.CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum.UpdateOn,
];
createCopyFlagConfigApprovalRequestRequest.source = source;

apiCaller.postFlagCopyConfigApprovalRequest(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  createCopyFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postFlagCopyConfigApprovalRequest:");
  console.log(error.body);
});
