import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const membersPatchInput: api.MembersPatchInput = {
  instructions: [
    {
      "kind": "replaceMembersRoles",
      "memberIDs": [
        "1234a56b7c89d012345e678f",
        "507f1f77bcf86cd799439011"
      ],
      "value": "reader"
    }
  ],
  comment: "Optional comment about the update",
};

new api.AccountMembersBetaApi(configuration).patchMembers(
  membersPatchInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountMembersBetaApi#patchMembers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
