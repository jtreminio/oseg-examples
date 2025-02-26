import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsBetaApi();
apiCaller.setApiKey(api.TeamsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const teamsPatchInput = new models.TeamsPatchInput();
teamsPatchInput.instructions =   [
  {
    "kind": "addMembersToTeams",
    "memberIDs": [
      "1234a56b7c89d012345e678f"
    ],
    "teamKeys": [
      "example-team-1",
      "example-team-2"
    ]
  }
];
teamsPatchInput.comment = "Optional comment about the update";

apiCaller.patchTeams(
  teamsPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsBetaApi#patchTeams:");
  console.log(error.body);
});
