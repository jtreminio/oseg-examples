import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

const createAnAccountUserRequest: api.CreateAnAccountUserRequest = {
  role: "role_string",
  user_id: 0,
};

new api.AccountUsersApi(configuration).createAnAccountUser(
  0, // accountId
  createAnAccountUserRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountUsersApi#createAnAccountUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
