import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const memberTeamsPostInput: api.MemberTeamsPostInput = {
  teamKeys: [
    "team1",
    "team2",
  ],
};

new api.AccountMembersApi(configuration).postMemberTeams(
  "id_string", // id
  memberTeamsPostInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountMembersApi#postMemberTeams:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
