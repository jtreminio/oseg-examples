import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

const accountCreateUpdatePayload: api.AccountCreateUpdatePayload = {
};

new api.AccountsApi(configuration).createAnAccount(
  accountCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountsApi#createAnAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
