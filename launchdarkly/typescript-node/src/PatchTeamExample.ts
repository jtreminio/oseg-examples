import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

const teamPatchInput: models.TeamPatchInput = {
  instructions: [
    {
      "kind": "updateDescription",
      "value": "New description for the team"
    }
  ],
  comment: "Optional comment about the update",
};

apiCaller.patchTeam(
  "teamKey_string", // teamKey
  teamPatchInput,
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#patchTeam:");
  console.log(error.body);
});
