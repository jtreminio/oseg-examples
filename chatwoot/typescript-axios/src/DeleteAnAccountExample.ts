import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

new api.AccountsApi(configuration).deleteAnAccount(
  0, // accountId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountsApi#deleteAnAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
