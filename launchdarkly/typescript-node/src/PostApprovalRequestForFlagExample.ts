import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const createFlagConfigApprovalRequestRequest: models.CreateFlagConfigApprovalRequestRequest = {
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

apiCaller.postApprovalRequestForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  createFlagConfigApprovalRequestRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequestForFlag:");
  console.log(error.body);
});
