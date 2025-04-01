import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const teamPatchInput: api.TeamPatchInput = {
  instructions: [
    {
      "kind": "updateDescription",
      "value": "New description for the team"
    }
  ],
  comment: "Optional comment about the update",
};

new api.TeamsApi(configuration).patchTeam(
  "teamKey_string", // teamKey
  teamPatchInput,
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#patchTeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
