import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const teamCreateUpdatePayload: api.TeamCreateUpdatePayload = {
};

new api.TeamsApi(configuration).createATeam(
  0, // accountId
  teamCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#createATeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
