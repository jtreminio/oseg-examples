import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const addNewAgentToTeamRequest: api.AddNewAgentToTeamRequest = {
  user_ids: [
  ],
};

new api.TeamsApi(configuration).addNewAgentToTeam(
  0, // accountId
  0, // teamId
  addNewAgentToTeamRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#addNewAgentToTeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
