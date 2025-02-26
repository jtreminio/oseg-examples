import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

const memberTeamsPostInput = new models.MemberTeamsPostInput();
memberTeamsPostInput.teamKeys = [
  "team1",
  "team2",
];

apiCaller.postMemberTeams(
  undefined, // id
  memberTeamsPostInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembersApi#postMemberTeams:");
  console.log(error.body);
});
