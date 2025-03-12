import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const createFlagConfigApprovalRequestRequest = new models.CreateFlagConfigApprovalRequestRequest();
createFlagConfigApprovalRequestRequest.description = "Requesting to update targeting";
createFlagConfigApprovalRequestRequest.instructions = [];
createFlagConfigApprovalRequestRequest.comment = "optional comment";
createFlagConfigApprovalRequestRequest.executionDate = 1706701522000;
createFlagConfigApprovalRequestRequest.operatingOnId = "6297ed79dee7dc14e1f9a80c";
createFlagConfigApprovalRequestRequest.notifyMemberIds = [
  "1234a56b7c89d012345e678f",
];
createFlagConfigApprovalRequestRequest.notifyTeamKeys = [
  "example-reviewer-team",
];
createFlagConfigApprovalRequestRequest.integrationConfig = undefined;

apiCaller.postApprovalRequestForFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  createFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestForFlag:");
  console.log(error.body);
});
