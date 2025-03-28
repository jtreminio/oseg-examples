import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UserSettingsApi(configuration).getUserFlagSetting(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
  "featureFlagKey_string", // featureFlagKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserSettingsApi#getUserFlagSetting:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
