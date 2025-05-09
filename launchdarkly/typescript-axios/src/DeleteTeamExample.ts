import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.TeamsApi(configuration).deleteTeam(
  "teamKey_string", // teamKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#deleteTeam:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
