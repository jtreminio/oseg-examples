import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.TeamsApi(configuration).getTeamRoles(
  "teamKey_string", // teamKey
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#getTeamRoles:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
