import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApprovalsApi();
apiCaller.setApiKey(api.ApprovalsApiApiKeys.ApiKey, "YOUR_API_KEY");

const createApprovalRequestRequest: models.CreateApprovalRequestRequest = {
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

apiCaller.postApprovalRequest(
  createApprovalRequestRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApprovalsApi#postApprovalRequest:");
  console.log(error.body);
});
