import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersBetaApi();
apiCaller.setApiKey(api.AccountMembersBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const membersPatchInput = new models.MembersPatchInput();
membersPatchInput.instructions =   [
  {
    "kind": "replaceMembersRoles",
    "memberIDs": [
      "1234a56b7c89d012345e678f",
      "507f1f77bcf86cd799439011"
    ],
    "value": "reader"
  }
];
membersPatchInput.comment = "Optional comment about the update";

apiCaller.patchMembers(
  membersPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembersBeta#patchMembers:");
  console.log(error.body);
});
