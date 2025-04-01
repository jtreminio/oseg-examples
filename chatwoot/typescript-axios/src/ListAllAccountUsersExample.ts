import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

new api.AccountUsersApi(configuration).listAllAccountUsers(
  0, // accountId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountUsersApi#listAllAccountUsers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
