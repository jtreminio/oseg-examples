import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UserApi(configuration).logoutUser().catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#logoutUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
