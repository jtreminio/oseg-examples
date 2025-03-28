import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UsersApi(configuration).deleteUser(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UsersApi#deleteUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
