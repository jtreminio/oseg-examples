import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.TeamsApi(configuration).postTeamMembers(
  "teamKey_string", // teamKey
  undefined, // file
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling TeamsApi#postTeamMembers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
