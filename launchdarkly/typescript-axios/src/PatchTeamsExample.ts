import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const teamsPatchInput: api.TeamsPatchInput = {
  instructions: [
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
  ],
  comment: "Optional comment about the update",
};

new api.TeamsBetaApi(configuration).patchTeams(
  teamsPatchInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsBetaApi#patchTeams:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
