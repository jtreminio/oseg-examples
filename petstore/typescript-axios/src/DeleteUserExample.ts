import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UserApi(configuration).deleteUser(
  "my_username", // username
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#deleteUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
