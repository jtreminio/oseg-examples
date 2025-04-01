import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
  // apiKey: "YOUR_API_KEY",
});

new api.UserApi(configuration).loginUser(
  "my_username", // username
  "my_secret_password", // password
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#loginUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
