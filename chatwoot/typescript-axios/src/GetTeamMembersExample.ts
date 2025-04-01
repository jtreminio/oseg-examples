import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.TeamsApi(configuration).getTeamMembers(
  0, // accountId
  0, // teamId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#getTeamMembers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
