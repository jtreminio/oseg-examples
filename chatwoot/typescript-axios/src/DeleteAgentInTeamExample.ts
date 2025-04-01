import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const deleteAgentInTeamRequest: api.DeleteAgentInTeamRequest = {
  user_ids: [
  ],
};

new api.TeamsApi(configuration).deleteAgentInTeam(
  0, // accountId
  0, // teamId
  deleteAgentInTeamRequest, // data
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#deleteAgentInTeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
