import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

const userCreateUpdatePayload: api.UserCreateUpdatePayload = {
};

new api.UsersApi(configuration).updateAUser(
  0, // id
  userCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UsersApi#updateAUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
