import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

const deleteAnAccountUserRequest: api.DeleteAnAccountUserRequest = {
  user_id: 0,
};

new api.AccountUsersApi(configuration).deleteAnAccountUser(
  0, // accountId
  deleteAnAccountUserRequest, // data
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountUsersApi#deleteAnAccountUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
