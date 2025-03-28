import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const teamPostInput: api.TeamPostInput = {
  key: "team-key-123abc",
  name: "Example team",
  description: "An example team",
  customRoleKeys: [
    "example-role1",
    "example-role2",
  ],
  memberIDs: [
    "12ab3c45de678910fgh12345",
  ],
};

new api.TeamsApi(configuration).postTeam(
  teamPostInput,
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#postTeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
