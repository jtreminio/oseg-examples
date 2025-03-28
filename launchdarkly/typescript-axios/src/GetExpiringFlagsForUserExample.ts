import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UserSettingsApi(configuration).getExpiringFlagsForUser(
  "projectKey_string", // projectKey
  "userKey_string", // userKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserSettingsApi#getExpiringFlagsForUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
