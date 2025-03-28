import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

const userCreateUpdatePayload: api.UserCreateUpdatePayload = {
};

new api.UsersApi(configuration).createAUser(
  userCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UsersApi#createAUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
